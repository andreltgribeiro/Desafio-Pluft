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
    public class LojistaRepository : ILojistaRepository
    {
        public Lojistas BuscarPorLojistaPorIdUsuario(int Idusuario)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Lojistas.Find(Idusuario);
            }
        }

        public List<Estabelecimentos> ListarEstabelecimentos()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Estabelecimentos.ToList();
            }
        }

        public List<Lojistas> ListarLojistas()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Lojistas.Include(x => x.IdUsuarioNavigation).Include(y => y.IdUsuarioNavigation.IdEstabelecimentoNavigation).Where(x => x.IdUsuarioNavigation.IdTipoUsuario == 3).ToList();
            }
        }

        public LojistaViewModel RetornarLojistaViewModel(LojistaStandaloneViewModel lojistaModel)
        {
            LojistaViewModel lojista = new LojistaViewModel()
            {
                UsuarioViewModel = new CadastrarUsuarioViewModel()
                {
                    Nome = lojistaModel.Nome,
                    Email = lojistaModel.Email,
                    Senha = lojistaModel.Senha,
                    Telefone = lojistaModel.Telefone,
                    DataCriacao = DateTime.Now,
                    IdTipoUsuario = lojistaModel.IdTipoUsuario,
                    IdEstabelecimento = lojistaModel.IdEstabelecimento
                },

                Lojista = new Lojistas()
                {
                    IdUsuario = lojistaModel.IdUsuario,
                    Rg = lojistaModel.Rg,
                    Cpf = lojistaModel.Cpf,
                    DataNascimento = lojistaModel.DataNascimento,
                    Endereco = lojistaModel.Endereco

                }
            };

            return lojista;
        }
    }
}
