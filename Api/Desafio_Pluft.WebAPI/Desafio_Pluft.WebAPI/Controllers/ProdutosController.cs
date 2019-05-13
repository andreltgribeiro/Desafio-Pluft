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
    public class ProdutosController : ControllerBase
    {
        private IProdutoRepository ProdutosRepository { get; set; }

        public ProdutosController()
        {
            ProdutosRepository = new ProdutoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador, Lojista, Cliente")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult ListarTodos()
        {
            try //Tenta Executar os comandos abaixo
            {
                List<Produtos> produtos = ProdutosRepository.ListarTodos(); // Cria uma lista do tipo Produtos Arrmazenando Todos os produtos cadastrados

                var resultado = from c in produtos //Determina como será apresentado o Json que será enviado como resultado 
                                select new
                                {
                                    Id = c.Id,
                                    Titulo = c.Titulo,
                                    Descricao = c.Descricao,
                                    qtdEstoque = c.QtdEstoque,
                                    IdEstabelecimento = c.IdEstabelecNavigation.Id,
                                    Estabelecimento = c.IdEstabelecNavigation.Nome,
                                    Preco = c.Preco
                                };

                return Ok(resultado); //Retorna 200 Ok passando a variável resultado
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
        public IActionResult Atualizar(Produtos novoproduto)
        {
            try //Tenta Executar os comandos abaixo
            {
                Produtos produtoCadastrado = ProdutosRepository.BuscarPorId(novoproduto.Id); //Cria uma variável do tipo Produtos e utiliza o étodo BuscarPorId para encontrar um produto com o id correspondente

                if (produtoCadastrado == null) //Verifica se o Produto Buscado não é nulo
                {
                    return NotFound(); // Retorna Not Found 404
                }

                ProdutosRepository.AtualizarDados(produtoCadastrado, novoproduto ); // Usa o método AtualizarDados para comparar as diferenças do produto cadastrado com o que novo e armazena as informações no DB

                return Ok();//Retorna 200 Ok
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
        [Authorize(Roles = "Administrador, Lojista")]//Determina qual tipo de usuário pode utilizar esse Método
        public IActionResult Cadastrar(Produtos produtos)
        {
            try//Tenta Executar os comandos abaixo
            {
                ProdutosRepository.CadastrarProduto(produtos); //Utiliza o método CadastrarProduto e passa o produto informado pelo Post e armazena no Banco de dados
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