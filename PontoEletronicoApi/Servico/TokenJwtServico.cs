using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PontoEletronico.JwtConfigurations;
using PontoEletronico.Models;
using PontoEletronico.Models.TokenConfiguration;
using PontoEletronico.Servico.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PontoEletronico.Servico
{
    public class TokenJwtServico : ITokenJwtServico
    {
        public object CriarTokenJwt(UserApp user, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.email)
                    }
                );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
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
    }
}
