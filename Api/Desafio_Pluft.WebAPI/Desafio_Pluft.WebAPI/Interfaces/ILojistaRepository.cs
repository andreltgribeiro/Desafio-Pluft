using Desafio_Pluft.WebAPI.Domains;
using Desafio_Pluft.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.Interfaces
{
    public interface ILojistaRepository
    {

        /// <summary>
        /// Busca um Lojista pelo id de usuário
        /// </summary>
        /// <param name="Idusuario"></param>
        /// <returns></returns>
        Lojistas BuscarPorLojistaPorIdUsuario(int Idusuario);

        /// <summary>
        /// Retorna LojistaViewModel
        /// </summary>
        /// <param name="lojistaModel"></param>
        /// <returns></returns>
        LojistaViewModel RetornarLojistaViewModel(LojistaStandaloneViewModel lojistaModel);


        /// <summary>
        /// Lista Todos os Lojistas
        /// </summary>
        /// <returns></returns>
        List<Lojistas> ListarLojistas();
    }
}
