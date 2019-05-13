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
        public IActionResult ListarTodos()
        {
            try
            {
                List<Produtos> produtos = ProdutosRepository.ListarTodos();

                var resultado = from c in produtos
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

                return Ok(resultado);
            }
            catch 
            {

                return BadRequest();
            }
        }

        [Authorize(Roles = "Administrador, Lojista")]
        [HttpPut]
        public IActionResult Atualizar(Produtos novoproduto)
        {
            try
            {
                Produtos produtoCadastrado = ProdutosRepository.BuscarPorId(novoproduto.Id);

                if (produtoCadastrado == null)
                {
                    return NotFound();
                }

                ProdutosRepository.AtualizarDados(produtoCadastrado, novoproduto );

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Lojista")]
        public IActionResult Cadastrar(Produtos produtos)
        {
            try
            {
                ProdutosRepository.CadastrarProduto(produtos);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}