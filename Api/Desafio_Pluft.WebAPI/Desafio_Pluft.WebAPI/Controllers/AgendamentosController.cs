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
        private IProdutoAgendamentoRepository ProdutoAgendamentoRepository { get; set; }

        public AgendamentosController()
        {
            AgendamentoRepository = new AgendamentoRepository();
            ClienteRepository = new ClienteRepository();
            LojistaRepository = new LojistaRepository();
            UsuarioRepository = new UsuarioRepository();
            ProdutoAgendamentoRepository = new ProdutoAgendamentoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")] //Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult Listar()
        {
            try
            {
                List<Agendamentos> agendamentos = AgendamentoRepository.ListarTodos();// Cria uma lista do tipo Agendamentos Arrmazenando Todos os agendamentos cadastrados
                List<ProdutoAgendamentos> produtosgendamentos = ProdutoAgendamentoRepository.ListarProdutoComAgendamento();// Cria uma lista do tipo ProdutoAgendamentos Arrmazenando Todos os ProdutoAgendamentos cadastrados

                var produtoagendamento = from c in produtosgendamentos //Determina como será apresentado o Json que será enviado como resultado 
                                         select new
                                       {
                                             IdAgendamento = c.IdAgendamentoNavigation.Id,
                                             IdProduto = c.IdProdutosNavigation.Id,
                                             IdNomeProduto = c.IdProdutosNavigation.Titulo

                                       };

                var retorno = from c in agendamentos //Determina como será apresentado o Json que será enviado como resultado 
                              select new
                                       {
                                           Id = c.Id,
                                           clienteCpf = c.IdClienteNavigation.Cpf,
                                           clienteRG = c.IdClienteNavigation.Rg,
                                           nomecliente = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                           clienteEndereco = c.IdClienteNavigation.Endereco,
                                           nomeLojista = c.IdLojistaNavigation.IdUsuarioNavigation.Nome,
                                           dataAgendamento = c.DataAgendamento,
                                           dataCriacao = c.DataCriacao,
                                           statusAgendamento = c.IdStatusNavigation.Nome,
                                           idProdutoAgendamento = produtoagendamento
                                       };
                return Ok(retorno); // retorna 200 Ok 
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Cliente")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult Cadastrar(Agendamentos agendamento, List<int> produtos)
        {
            try
            {
                AgendamentoRepository.Cadastrar(agendamento, produtos); //Utiliza o método Cadastrar e passa o agendamento e um coleção de int informado pelo Post e armazena no Banco de dados

                return Ok();//retorna 200 OK
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }


        [HttpGet("meusagendamentos")]
        [Authorize(Roles = "Cliente")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult ListarPorLogado()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value); //Busca o Id do usuário pelo token informado no header da solicitação
                string usuarioTipo = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value.ToString(); //Busca o Tipo do usuário pelo token informado no header da solicitação

                if (usuarioTipo == "Lojista") // Verifica se a pessoa logado é do tipo Lojista
                {
                    Usuarios procurado = UsuarioRepository.BuscarPorId(usuarioId); // Busca um usuário por Id

                    List<Agendamentos> agendamento = AgendamentoRepository.ListarporIdLojista(usuarioId); //Cria uma lista de Agendamentos que possui os agendamentos do lojista logado

                    var retorno = from c in agendamento //Determina como será apresentado o Json que será enviado como resultado
                                  select new
                                           {
                                               id = c.Id,
                                               nomecliente = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               clienteCpf = c.IdClienteNavigation.Cpf,
                                               clienteRG = c.IdClienteNavigation.Rg,
                                               clienteEnd = c.IdClienteNavigation.Endereco,
                                               nomeLojista = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               dataAgendamento = c.DataAgendamento,
                                               dataCriacao = c.DataCriacao,
                                               statusConsulta = c.IdStatusNavigation.Nome
                                           };

                    return Ok(retorno); // retorna 200 Ok 
                }
                else if (usuarioTipo == "Cliente") // Verifica se a pessoa logado é do tipo Cliente
                {
                    Usuarios procurado = UsuarioRepository.BuscarPorId(usuarioId); // Busca um usuário por Id

                    List<Agendamentos> agendamento = AgendamentoRepository.ListarporIdCliente(usuarioId); //Cria uma lista de Agendamentos que possui os agendamentos do Cliente logado

                    var retorno = from c in agendamento //Determina como será apresentado o Json que será enviado como resultado
                                  select new
                                           {
                                               id = c.Id,
                                               nomecliente = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               clienteCpf = c.IdClienteNavigation.Cpf,
                                               clienteRG = c.IdClienteNavigation.Rg,
                                               clienteEnd = c.IdClienteNavigation.Endereco,
                                               nomeLojista = c.IdClienteNavigation.IdUsuarioNavigation.Nome,
                                               dataAgendamento = c.DataAgendamento,
                                               dataCriacao = c.DataCriacao,
                                               StatusAgendamento = c.IdStatusNavigation.Nome
                                           };

                    return Ok(retorno); // retorna 200 Ok 
                }
                else // caso a pessoa logada não seja nem um lojista nem um cliente retorna 400 BadRequest
                {
                    return BadRequest(); // Retorna BadRequest 400
                }

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