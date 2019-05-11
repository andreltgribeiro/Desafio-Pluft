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
        Lojistas BuscarPorLojistaPorIdUsuario(int Idusuario);

        List<Estabelecimentos> ListarEstabelecimentos();

        LojistaViewModel RetornarLojistaViewModel(LojistaStandaloneViewModel lojistaModel);

        List<Lojistas> ListarLojistas();
    }
}
