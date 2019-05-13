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
        [Authorize(Roles = "Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult ListarLojistas()
        {
            try //Tenta realizar a ação abaixo
            {
                List<Lojistas> lojistas = LojistaRepository.ListarLojistas(); //Cria um lista do tipo Lojistas que contém todos os lojistas do sistema


                var resultado = from m in lojistas //Determina como será apresentado o Json que será enviado como resultado
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
                return Ok(resultado); //Retornando Status 200 com o resultado já formatado
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpGet("clientes")]
        [Authorize(Roles = "Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult ListarClientes()
        {
            try //Tenta realizar a ação abaixo
            {
                List<Clientes> Clientes = ClienteRepository.ListarTodos(); //Cria uma lista de clientes com todos os clientes do sistema

                var resultado = from p in Clientes //Determina como será apresentado o Json que será enviado como resultado
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
                return Ok(resultado);//Retornando Status 200 com o resultado já formatado
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpPost("administrador")]
        [Authorize(Roles = "Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult CadastrarAdministrador(AdministradorStandaloneViewModel usuarioModel)
        {
            try //Tenta realizar a ação abaixo
            {
                CadastrarUsuarioViewModel usuario = UsuarioRepository.RetornarUsuarioViewModel(usuarioModel); //Cadastra um usuário utilizando ViewModel

                UsuarioRepository.CadastrarUsuario(usuario); // Utiliza o método 'CadastrarUsuario' para cadastrar o usuário informado

                return Ok();
            }
            catch (Exception ex) //Caso não consiga realizar a ação retorna status 400 com a mensagem do erro
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpPost("lojistas")]
        [Authorize(Roles = "Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult CadastrarLojista(LojistaStandaloneViewModel lojistaModel)
        {
            try // tenta realizar a ação abaixo
            {
                LojistaViewModel lojista = LojistaRepository.RetornarLojistaViewModel(lojistaModel); // Cria um objeti chamado lojista do tipo LojistaViewMOdel

                UsuarioRepository.CadastrarLojista(lojista); // Utiliza o método Cadastrar Lojista para passar o objeto lojista e cadastra-lo no sistema

                return Ok(); // rtorna 200 Ok
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpPost("cliente")]
        [Authorize(Roles = "Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult CadastrarCliente(ClienteStandaloneViewModel clientemModel)
        {
            try // Tenta realizar as ações abaixo
            {
                LoginViewModel login = new LoginViewModel(); //Instancia Login view Model armazenando numa variável chamada login

                ClienteViewModel cliente = ClienteRepository.RetornarClienteViewModel(clientemModel); // cria uma variável do tipo ClienteViewModel com o nome cliente

                Usuarios usuario = UsuarioRepository.BuscarPorEmail(login); // cria uma variável do tipo Usuários e usa o metodo BuscarPorEmail para encontrar as credenciais no banco de dados

                if (cliente.Cliente.DataNascimento.Date > DateTime.Now.Date) // Verifica se a data de nascimento informada no formulário de cadastro não é maior do que a data atual
                {
                    return BadRequest(); //retorna 400 Bad Request
                }

                UsuarioRepository.CadastrarCliente(cliente); // Cadastra o cliente usando o método CadastrarCliente

                return Ok(); //retorna 200 Ok
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