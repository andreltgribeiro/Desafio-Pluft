using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Desafio_Pluft.WebAPI.Repositories;
using Desafio_Pluft.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Pluft.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }
        private IClienteRepository ClienteRepository { get; set; }
        private ILojistaRepository LojistaRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
            ClienteRepository = new ClienteRepository();
            LojistaRepository = new LojistaRepository();
        }

        [HttpGet("lojistas")]
        [Authorize]
        public IActionResult ListarLojistas()
        {
            try
            {
                List<Lojistas> lojistas = LojistaRepository.ListarLojistas();

                Lojistas lojista = new Lojistas();

                var resultado = from m in lojistas
                                select new
                                {

                                    id = m.Id,
                                    Cpf = m.Cpf,
                                    DataNascimento = m.DataNascimento,
                                    Nome = m.IdUsuarioNavigation.Nome,
                                    Email = m.IdUsuarioNavigation.Email,
                                    Telefone = m.IdUsuarioNavigation.Telefone,
                                    Endereco = m.Endereco,
                                    Estabelecimento = m.IdUsuarioNavigation.IdEstabelecimentoNavigation.Nome
                                };
                return Ok(resultado);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("estabelecimentos")]
        [Authorize(Roles = "Lojista")]
        public IActionResult ListasEstabelecimentos()
        {
            try
            {
                return Ok(LojistaRepository.ListarEstabelecimentos());
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpGet("clientes")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarClientes()
        {
            try
            {
                List<Clientes> Clientes = ClienteRepository.ListarTodos();

                var resultado = from p in Clientes
                                select new
                                {
                                    id = p.Id,
                                    idUsuario = p.IdUsuario,
                                    rg = p.Rg,
                                    cpf = p.Cpf,
                                    dataNascimento = p.DataNascimento,
                                    endereco = p.Endereco,
                                    nome = p.IdUsuarioNavigation.Nome,
                                    telefone = p.IdUsuarioNavigation.Telefone,
                                    email = p.IdUsuarioNavigation.Email

                                };
                return Ok(resultado);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("administrador")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarAdministrador(AdministradorStandaloneViewModel usuarioModel)
        {
            try
            {
                CadastrarUsuarioViewModel usuario = UsuarioRepository.RetornarUsuarioViewModel(usuarioModel);

                UsuarioRepository.CadastrarUsuario(usuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost("lojistas")]
        [Authorize]
        public IActionResult CadastrarLojista(LojistaStandaloneViewModel lojistaModel)
        {
            try
            {
                LojistaViewModel lojista = LojistaRepository.RetornarLojistaViewModel(lojistaModel);

                UsuarioRepository.CadastrarLojista(lojista);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost("cliente")]
        [Authorize]
        public IActionResult CadastrarCliente(ClienteStandaloneViewModel clientemModel)
        {
            try
            {
                LoginViewModel login = new LoginViewModel();

                ClienteViewModel cliente = ClienteRepository.RetornarClienteViewModel(clientemModel);

                Usuarios usuario = UsuarioRepository.BuscarPorEmail(login);

                if (cliente.Cliente.DataNascimento.Date > DateTime.Now.Date)
                {
                    return BadRequest();
                }

                UsuarioRepository.CadastrarCliente(cliente);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}