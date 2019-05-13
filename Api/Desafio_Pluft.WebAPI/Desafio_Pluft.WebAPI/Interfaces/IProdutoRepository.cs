using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Lista Todos os Produtos
        /// </summary>
        /// <returns></returns>
        List<Produtos> ListarTodos();

        /// <summary>
        /// Busca um produto pro ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Produtos BuscarPorId(int id);


        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <param name="produto"></param>
        void CadastrarProduto(Produtos produto);


        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produtoCadastrado"></param>
        /// <param name="novoProduto"></param>
        void AtualizarDados(Produtos produtoCadastrado, Produtos novoProduto);
    }
}
