using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Repositories
{
    public class ProdutoAgendamentoRepository : IProdutoAgendamentoRepository
    {
        public List<ProdutoAgendamentos> ListarProdutoComAgendamento()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.ProdutoAgendamentos.Include(x => x.IdProdutosNavigation).Include(x => x.IdAgendamentoNavigation).ToList();
            }
        }
    }
}
