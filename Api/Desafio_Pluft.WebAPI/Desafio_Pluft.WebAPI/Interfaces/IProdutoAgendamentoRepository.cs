using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    interface IProdutoAgendamentoRepository
    {
        List<ProdutoAgendamentos> ListarProdutoComAgendamento();
    }
}
