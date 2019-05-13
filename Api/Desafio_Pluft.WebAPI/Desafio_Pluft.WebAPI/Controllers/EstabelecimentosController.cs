using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EstabelecimentosController : ControllerBase
    {
        private IEstabelecimentoRepository EstabelecimentoRepository { get; set; }

        public EstabelecimentosController()
        {
            EstabelecimentoRepository = new EstabelecimentoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Lojista")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult Cadastrar(Estabelecimentos estabelecimento)
        {
            try
            {
                EstabelecimentoRepository.CadastrarDados(estabelecimento); //Utiliza o método CadastrarDados e passa o estabelecimento informado pelo Post e armazena no Banco de dados
                return Ok(); //retorna 200 OK
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Lojista, Cliente, Administrador")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult ListarTodas()
        {
            try
            {
                List<Estabelecimentos> estabelecimentos = EstabelecimentoRepository.ListarTodas(); // Cria uma lista do tipo Estabelecimentos Arrmazenando Todos os estabelecimentos cadastrados

                var resultado = from m in estabelecimentos //Determina como será apresentado o Json que será enviado como resultado 
                                select new
                                {

                                    id = m.Id,
                                    nome = m.Nome,
                                    cnpj = m.Cnpj,
                                    tipoestabelecimento = m.IdTipoEstabelecNavigation.Tipo,
                                    endereco = m.Endereco,
                                    horarioFuncionamento = m.HorarioFuncionamento,
                                    vagas = m.Vagas,
                                    agendamentos = m.Agendamentos,
                                    produtos = m.Produtos
                                };
                return Ok(resultado); // retorna 200 Ok 
            }
            catch (Exception ex) //Armazena um erro caso as instruções acima não consigam ser executadas armazenando na variável ex do tipo 
            {
                return BadRequest(new //Criando e retornando a mensagem de erro que será enviada
                {
                    mensagem = "Erro: " + ex // Inserindo erro na mensagem
                });
            }
        }

        [Authorize(Roles = "Administrador, Lojista")]//Determina qual tipo de usuário pode utilizar esse Método
        [HttpPut]
        public IActionResult Atualizar(Estabelecimentos novoEstabelecimento)
        {
            try //Tenta Executar os comandos abaixo
            {
                Estabelecimentos estabelecimentoCadastrado = EstabelecimentoRepository.BuscarEstabelecimentosPorId(novoEstabelecimento.Id);//Cria uma variável do tipo Estabelecimentos e utiliza o étodo BuscarEstabelecimentosPorId para encontrar um Estabelecimento com o id correspondente

                if (estabelecimentoCadastrado == null) // Verifica se o estabelecimento buscado é nulo
                {
                    return NotFound(); //Retorna 404 NOT FOUND
                }

                EstabelecimentoRepository.AtualizarDados(novoEstabelecimento, estabelecimentoCadastrado); // Usa o método AtualizarDados para comparar as diferenças do Estabelecimento cadastrado com o que novo e armazena as informações no DB

                return Ok(); //Retorna 200 Ok
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