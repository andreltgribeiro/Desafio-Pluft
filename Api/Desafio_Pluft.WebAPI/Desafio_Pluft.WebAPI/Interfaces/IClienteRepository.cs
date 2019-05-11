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
        Clientes BuscarClientePorIdUsuario(int idUsuario);

        ClienteViewModel RetornarClienteViewModel(ClienteStandaloneViewModel ClienteModel);

        List<Clientes> ListarTodos();
    }
}
