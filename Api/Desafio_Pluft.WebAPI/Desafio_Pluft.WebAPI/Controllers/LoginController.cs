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
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorEmailESenha(login); //usa o Método BuscarPorEmailESenha para encontrar o usuário informado pelo Post

                if (usuarioProcurado == null) //Verifica se o usuário de retorno é igual a nulo
                {
                    return NotFound(); // retorna 404 NOT FOUND
                }

                var claims = new[] // cria uma variável que armazena as claims do JWT
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioProcurado.Email), //Define que o email do usuário procurado é igual a claim Email
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioProcurado.Id.ToString()), // Armazena o Id do usuário procurado em uma claim do JWT
                    new Claim(ClaimTypes.Role, usuarioProcurado.IdTipoUsuarioNavigation.Tipo), // Armazena o nome do tipo de usuário em uma claim padrão do jwt
                    new Claim("permissao", usuarioProcurado.IdTipoUsuarioNavigation.Tipo), // Armazena o nome do tipo de usuário em uma claim personalizada do jwt
                    new Claim("nomeuser", usuarioProcurado.Nome) // Armazena o nome do  usuário em uma claim personalizada do jwt
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Desafio-Pluft-chave-autenticacao")); //Determina a chave de autenticação da API e armazena em uma variável

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Encriptografa a chave de autenticação

                var token = new JwtSecurityToken( //cria o token do jwt
                    issuer: "DesafioPluft.WebApi", // Determina a chave do emissor
                    audience: "DesafioPluft.WebApi", //Determina a chave que deve chegar do público
                    claims: claims, // armazena as claims  em outra variável
                    expires: DateTime.Now.AddMinutes(30), // Determina por quanto tempo a chave de autenticação é válida
                    signingCredentials: creds // Armazena as credenciais em uma variável
                );

                return Ok(new //retorna 200 OK com o Token já Encriptografado
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }
    }
}