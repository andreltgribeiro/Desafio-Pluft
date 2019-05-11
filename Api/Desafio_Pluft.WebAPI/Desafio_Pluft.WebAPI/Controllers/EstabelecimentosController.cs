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
        [Authorize(Roles = "Administrador, Lojista")]
        public IActionResult Cadastrar(Estabelecimentos estabelecimento)
        {
            try
            {
                EstabelecimentoRepository.CadastrarDados(estabelecimento);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListarTodas()
        {
            try
            {

                return Ok(EstabelecimentoRepository.ListarTodas());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Administrador, Lojista")]
        [HttpPut]
        public IActionResult Atualizar(Estabelecimentos novoEstabelecimento)
        {
            try
            {
                Estabelecimentos estabelecimentoCadastrado = EstabelecimentoRepository.BuscarEstabelecimentosPorId(novoEstabelecimento.Id);

                if (estabelecimentoCadastrado == null)
                {
                    return NotFound();
                }

                EstabelecimentoRepository.AtualizarDados(novoEstabelecimento, estabelecimentoCadastrado);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}