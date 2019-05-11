using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Pluft.WebAPI.ViewModels
{
    public class LojistaStandaloneViewModel
    {
        public int IdUsuarioViewModel { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdEstabelecimento { get; set; }


        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }
    }
}
