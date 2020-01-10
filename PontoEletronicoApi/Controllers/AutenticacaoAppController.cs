using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PontoEletronico.JwtConfigurations;
using PontoEletronico.Models;
using PontoEletronico.Models.TokenConfiguration;
using PontoEletronico.Servico;
using PontoEletronico.Servico.Interface;

namespace PontoEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoAppController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenJwtServico _tokenJwtServico;
        public AutenticacaoAppController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ITokenJwtServico tokenJwtServico)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenJwtServico = tokenJwtServico;
        }

        [HttpPost]
        public async Task<object> Login(UserApp user,[FromServices]SigningConfigurations signingConfigurations, [FromServices]TokenConfiguration tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (!string.IsNullOrEmpty(user.email))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = await _userManager.FindByEmailAsync(user.email);
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = await _signInManager.CheckPasswordSignInAsync(userIdentity, user.password, false);
                    if (resultadoLogin.Succeeded)
                    {
                        credenciaisValidas = true;
                    }
                }
            }

            if (credenciaisValidas)
            {
                return _tokenJwtServico.CriarTokenJwt(user, signingConfigurations,tokenConfigurations);
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

        [HttpGet]
        [Authorize("Bearer")]
        public object TestarToken()
        {
            return new { Nome = "Passou", Senha = "Sim" };
        }
    }
}