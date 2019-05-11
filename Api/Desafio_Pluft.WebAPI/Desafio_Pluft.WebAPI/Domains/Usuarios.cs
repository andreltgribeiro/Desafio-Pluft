using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Clientes = new HashSet<Clientes>();
            Lojistas = new HashSet<Lojistas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? IdEstabelecimento { get; set; }
        public int? IdTipoUsuario { get; set; }

        public Estabelecimentos IdEstabelecimentoNavigation { get; set; }
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<Lojistas> Lojistas { get; set; }
    }
}
