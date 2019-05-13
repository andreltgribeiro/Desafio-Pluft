using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produtos> ListarTodos();

        Produtos BuscarPorId(int id);

        void CadastrarProduto(Produtos produto);

        void AtualizarDados(Produtos produtoCadastrado, Produtos novoProduto);
    }
}
