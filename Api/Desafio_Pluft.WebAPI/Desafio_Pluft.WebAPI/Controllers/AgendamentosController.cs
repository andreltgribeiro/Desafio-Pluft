using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Desafio_Pluft.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Pluft.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {

        private IAgendamentoRepository AgendamentoRepository { get; set; }
        private IClienteRepository ClienteRepository { get; set; }
        private IUsuarioRepository UsuarioRepository { get; set; }
        private ILojistaRepository LojistaRepository { get; set; }

        public AgendamentosController()
        {
            AgendamentoRepository = new AgendamentoRepository();
            ClienteRepository = new ClienteRepository();
            LojistaRepository = new LojistaRepository();
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Lojista, Cliente")]
        public IActionResult Listar()
        {
            try
            {
                List<Agendamentos> agendamentos = AgendamentoRepository.ListarTodos();

                var retorno = from c in agendamentos
                                       select new
                                       {
                                           Id = c.Id,
                                           clienteCpf = c.IdClienteNavigation.Cpf,
                                           clienteRG = c.IdClienteNavigation.Rg,
                                           clienteEndereco = c.IdClienteNavigation.Endereco,
                                           nomeLojista = c.IdLojistaNavigation.IdUsuarioNavigation.Nome,
                                           dataAgendamento = c.DataAgendamento,
                                           dataCriacao = c.DataCriacao,
                                           statusAgendamento = c.IdStatusNavigation.Nome
                                       };
                return Ok(retorno);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Cliente")]
        public IActionResult Cadastrar(Agendamentos agendamento)
        {
            try
            {
                AgendamentoRepository.Cadastrar(agendamento);

                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }





        [HttpGet("meusagendamentos")]
        [Authorize]
        public IActionResult ListarPorLogado()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string usuarioTipo = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value.ToString();

                if (usuarioTipo == "Lojista")
                {
                    Usuarios procurado = UsuarioRepository.BuscarPorId(usuarioId);

                    List<Agendamentos> agendamento = AgendamentoRepository.ListarporIdLojista(usuarioId);

                    var retorno = from c in agendamento
                                           select new
                                           {
                                               id = c.Id,
                                               clienteCpf = c.IdClienteNavigation.Cpf,
                                               clienteRG = c.IdClienteNavigation.Rg,
                                               clienteEnd = c.IdClienteNavigation.Endereco,
                                               nomeLojista = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               dataAgendamento = c.DataAgendamento,
                                               dataCriacao = c.DataCriacao,
                                               statusConsulta = c.IdStatusNavigation.Nome
                                           };

                    return Ok(retorno);
                }
                else if (usuarioTipo == "Cliente")
                {
                    Usuarios procurado = UsuarioRepository.BuscarPorId(usuarioId);

                    List<Agendamentos> agendamento = AgendamentoRepository.ListarporIdCliente(usuarioId);

                    var retorno = from c in agendamento
                                           select new
                                           {
                                               id = c.Id,
                                               clienteCpf = c.IdClienteNavigation.Cpf,
                                               clienteRG = c.IdClienteNavigation.Rg,
                                               clienteEnd = c.IdClienteNavigation.Endereco,
                                               nomeLojista = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               dataAgendamento = c.DataAgendamento,
                                               dataCriacao = c.DataCriacao,
                                               statusConsulta = c.IdStatusNavigation.Nome
                                           };

                    return Ok(retorno);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                return BadRequest();
            }
        }


    }
}