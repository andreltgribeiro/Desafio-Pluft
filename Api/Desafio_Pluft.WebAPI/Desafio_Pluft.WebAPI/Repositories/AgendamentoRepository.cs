using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Desafio_Pluft.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository

    {
        public void Atualizar(Agendamentos novoAgendamento, Agendamentos agendamentoCadastrado)
        {
            agendamentoCadastrado.DataAgendamento = (novoAgendamento.DataAgendamento != agendamentoCadastrado.DataAgendamento ? novoAgendamento.DataAgendamento : agendamentoCadastrado.DataAgendamento);

            if (novoAgendamento.DataAgendamento != null)
            {
                agendamentoCadastrado.DataAgendamento = novoAgendamento.DataAgendamento;
            }

            if (novoAgendamento.IdStatus != 0)
            {
                agendamentoCadastrado.IdStatus = novoAgendamento.IdStatus;
            }

            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Agendamentos.Update(agendamentoCadastrado);
                ctx.SaveChanges();
            }
        }

        public Agendamentos BuscarPorId(int id)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Agendamentos.Find(id);
            }
        }

        public void Cadastrar(Agendamentos agendamento, List<int> produtos)
        {
            List<Agendamentos> agenda = new List<Agendamentos>();

            

            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Agendamentos.Add(agendamento);
                ctx.SaveChanges();
                foreach (var item in produtos)
                {
                    ctx.ProdutoAgendamentos.Add(new ProdutoAgendamentos()
                    {
                        IdAgendamento = agendamento.Id,
                        IdProdutos = item

                    });
                }
                ctx.SaveChanges();
            }
        }

        public List<Agendamentos> ListarporIdCliente(int idCliente)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                Clientes clienteBuscado = ctx.Clientes.Where(p => p.IdUsuario == idCliente).FirstOrDefault();

                return ctx.Agendamentos.Include(x => x.IdClienteNavigation.IdUsuarioNavigation).Include(x=>x.IdStatusNavigation).Include(x => x.ProdutoAgendamentos).Include(x => x.IdClienteNavigation).Where(x => x.IdCliente == clienteBuscado.Id).ToList();
            }
        }

        public List<Agendamentos> ListarporIdLojista(int idLojista)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                Lojistas lojistaBuscado = ctx.Lojistas.Where(p => p.IdUsuario == idLojista).FirstOrDefault();

                return ctx.Agendamentos.Include(x => x.IdLojistaNavigation.IdUsuarioNavigation).Include(x => x.ProdutoAgendamentos).Where(x => x.IdLojista == lojistaBuscado.Id).ToList();
            }
        }

        public List<Agendamentos> ListarTodos()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Agendamentos
                        .Include(x => x.IdLojistaNavigation.IdUsuarioNavigation)
                        .Include(x => x.IdClienteNavigation)
                        .Include(x => x.IdStatusNavigation)
                        .Include(x => x.ProdutoAgendamentos)
                        .ToList();
            }
        }


    }
}
