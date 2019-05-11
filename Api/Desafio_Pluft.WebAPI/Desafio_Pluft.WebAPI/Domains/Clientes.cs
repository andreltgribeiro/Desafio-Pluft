using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class Clientes
    {
        public Clientes()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
