using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IEstabelecimentoRepository
    {

        /// <summary>
        /// Cadastra um estabelecimento
        /// </summary>
        /// <param name="estabelecimnetos"></param>
        void CadastrarDados(Estabelecimentos estabelecimnetos);


        /// <summary>
        /// Atualiza os dados de um estabelecimento
        /// </summary>
        /// <param name="novoEstabelecimento"></param>
        /// <param name="estabelecimentoCadastrado"></param>
        void AtualizarDados(Estabelecimentos novoEstabelecimento, Estabelecimentos estabelecimentoCadastrado);

        /// <summary>
        /// Busca um estabelecimento por Id
        /// </summary>
        /// <param name="IdEstabelecimento"></param>
        /// <returns></returns>
        Estabelecimentos BuscarEstabelecimentosPorId(int IdEstabelecimento);


        /// <summary>
        /// Lista Todos os estabelecimentos
        /// </summary>
        /// <returns></returns>
        List<Estabelecimentos> ListarTodas();
    }
}
