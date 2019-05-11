using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Desafio_Pluft.WebAPI.Repositories;
using Desafio_Pluft.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Desafio_Pluft.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorEmailESenha(login);

                if (usuarioProcurado == null)
                {
                    return NotFound();
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioProcurado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioProcurado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioProcurado.IdTipoUsuarioNavigation.Tipo),
                    new Claim("permissao", usuarioProcurado.IdTipoUsuarioNavigation.Tipo),
                    new Claim("nomeuser", usuarioProcurado.Nome)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Desafio-Pluft-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "DesafioPluft.WebApi",
                    audience: "DesafioPluft.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}