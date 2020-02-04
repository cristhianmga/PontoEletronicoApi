using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using PontoEletronico.Data;
using PontoEletronico.JwtConfigurations;
using PontoEletronico.Models;
using PontoEletronico.Models.TokenConfiguration;
using PontoEletronico.Servico.Base;
using PontoEletronico.Servico.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace PontoEletronico.Servico
{
    public class TokenJwtServico : ITokenJwtServico
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfiguration _tokenConfigurations;
        private readonly BaseServico servico;
        public TokenJwtServico(SigningConfigurations signingConfigurations, TokenConfiguration tokenConfiguration, ApplicationDbContext context)
        {
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfiguration;
            servico = new BaseServico(context);
        }

        public JwtSecurityToken ReadToken(StringValues token)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(token.ToString().Split(new char[0])[1]);

        }

        public object CriarTokenJwt(UserApp user)
        {
            bool credenciaisValidas = false;
            if (user != null && !string.IsNullOrWhiteSpace(user.cpf))
            {
                var usuarioBase = servico.ObterTodos<Funcionario>().Where(x => x.Cpf == user.cpf).FirstOrDefault();
                credenciaisValidas = (usuarioBase != null &&
                    user.cpf == usuarioBase.Cpf &&
                    user.senha == usuarioBase.Senha);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.cpf, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.cpf)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}
