using Desafio_Pluft.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.ViewModels
{
    public class ClienteViewModel
    {
        public CadastrarUsuarioViewModel UsuarioViewModel { get; set; }

        public Clientes Cliente{ get; set; }
    }
}
