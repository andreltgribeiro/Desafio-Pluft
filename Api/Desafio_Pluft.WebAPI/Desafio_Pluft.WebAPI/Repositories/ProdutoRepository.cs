using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public List<Produtos> ListarTodos()
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Produtos.Include(x=>x.IdEstabelecNavigation).ToList();
            }
        }

        public Produtos BuscarPorId(int id)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                return ctx.Produtos.Find(id);
            }
        }

        public void CadastrarProduto(Produtos produto)
        {
            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
            }
        }

        public void AtualizarDados(Produtos produtoCadastrado, Produtos produtoNovo)
        {
            if(produtoNovo.Preco != 0)
            {
                produtoCadastrado.Preco = produtoNovo.Preco;
            }

            if (produtoNovo.Titulo != null)
            {
                produtoCadastrado.Titulo = produtoNovo.Titulo;
            }
            if (produtoNovo.QtdEstoque != 0)
            {
                produtoCadastrado.QtdEstoque = produtoNovo.QtdEstoque;
            }
            if (produtoNovo.Descricao != null)
            {
                produtoCadastrado.Descricao = produtoNovo.Descricao;
            }

            using (DesafioPluftContext ctx = new DesafioPluftContext())
            {
                ctx.Produtos.Update(produtoCadastrado);
                ctx.SaveChanges();
            }

        }
    }
}
