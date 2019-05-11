using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdEstabelecimento { get; set; }
    }
}
