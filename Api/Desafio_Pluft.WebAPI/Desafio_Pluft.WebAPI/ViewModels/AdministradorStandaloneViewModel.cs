using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.ViewModels
{
    public class AdministradorStandaloneViewModel
    {
        
        #region CadastrarUsuarioViewModel
        public int IdUsuarioViewModel { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdAgendamento { get; set; }
        public int? IdEstabelecimento { get; set; }
        #endregion
    }
}
