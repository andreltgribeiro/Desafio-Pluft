using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository

    {
        public void AtualizarDados(Estabelecimentos novoEstabelecimento, Estabelecimentos estabelecimentoCadastrado)
        {
            estabelecimentoCadastrado.Endereco = novoEstabelecimento.Endereco ?? estabelecimentoCadastrado.Endereco;

            estabelecimentoCadastrado.HorarioFuncionamento = novoEstabelecimento.HorarioFuncionamento ?? estabelecimentoCadastrado.HorarioFuncionamento;

            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Estabelecimentos.Update(novoEstabelecimento);
                ctx.SaveChanges();
            }
        }


        
        public Estabelecimentos BuscarEstabelecimentosPorId(int IdEstabelecimento)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Estabelecimentos.Find(IdEstabelecimento);
            }
        }


        
        public void CadastrarDados(Estabelecimentos estabelecimnetos)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Estabelecimentos.Add(estabelecimnetos);
                ctx.SaveChanges();
            }
        }



        public List<Estabelecimentos> ListarTodas()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Estabelecimentos.Include(x => x.IdTipoEstabelecNavigation).ToList();
            }
        }
    }
}
