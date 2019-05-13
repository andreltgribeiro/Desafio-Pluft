using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        /// <summary>
        /// Lista Todos os agendamentos
        /// </summary>
        /// <returns>Lista com todos os agendamentos</returns>
        List<Agendamentos> ListarTodos();

        /// <summary>
        /// Atualiza um Agendamento com as informções passadas.
        /// </summary>
        /// <param name="agendamento">Dados de um Agendamento.</param>
        void Atualizar(Agendamentos novoAgendamento, Agendamentos agendamentoCadastrado);

        /// <summary>
        /// Cadastra um Agendamento.
        /// </summary>
        /// <param name="agendamento">Um objeto do tipo agendamento.</param>
        void Cadastrar(Agendamentos agendamento, List<int> produtos);

        /// <summary>
        /// Lista os agendamentos que possuem o Id do Cliente passado por parâmetro;
        /// </summary>
        /// <param name="id">Id do Cliente</param>
        /// <returns>Uma lista de Agendamentos.</returns>
        List<Agendamentos> ListarporIdCliente(int idCliente);

        /// <summary>
        /// Lista os agendamentos que possuem o Id do Lojista passado por parâmetro;
        /// </summary>
        /// <param name="id">Id do Lojista.</param>
        /// <returns>Uma lista de Agendamentos.</returns>
        List<Agendamentos> ListarporIdLojista(int idLojista);

        /// <summary>
        /// Busca um usuário pelo ID.
        /// </summary>
        /// <param name="id">Id do agendamento.</param>
        /// <returns>um agendamento.</returns>
        Agendamentos BuscarPorId(int id);

        
    }
}
