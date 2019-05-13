using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IClienteRepository
    {

        /// <summary>
        /// Busca Cliente Por Id
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        Clientes BuscarClientePorIdUsuario(int idUsuario);



        /// <summary>
        /// Retorna cliente view model
        /// </summary>
        /// <param name="ClienteModel"></param>
        /// <returns></returns>
        ClienteViewModel RetornarClienteViewModel(ClienteStandaloneViewModel ClienteModel);


        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns></returns>
        List<Clientes> ListarTodos();
    }
}
