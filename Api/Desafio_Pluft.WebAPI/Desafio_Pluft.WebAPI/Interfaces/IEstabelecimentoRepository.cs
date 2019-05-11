using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        void CadastrarDados(Estabelecimentos estabelecimnetos);

        void AtualizarDados(Estabelecimentos novoEstabelecimento, Estabelecimentos estabelecimentoCadastrado);

        Estabelecimentos BuscarEstabelecimentosPorId(int IdEstabelecimento);

        List<Estabelecimentos> ListarTodas();
    }
}
