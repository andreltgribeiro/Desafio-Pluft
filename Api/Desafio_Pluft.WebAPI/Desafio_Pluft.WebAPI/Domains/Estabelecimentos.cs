using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class Estabelecimentos
    {
        public Estabelecimentos()
        {
            Agendamentos = new HashSet<Agendamentos>();
            Produtos = new HashSet<Produtos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int? IdTipoEstabelec { get; set; }
        public string Endereco { get; set; }
        public string HorarioFuncionamento { get; set; }
        public string Vagas { get; set; }

        public TipoEstabelecimento IdTipoEstabelecNavigation { get; set; }
        public ICollection<Agendamentos> Agendamentos { get; set; }
        public ICollection<Produtos> Produtos { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
