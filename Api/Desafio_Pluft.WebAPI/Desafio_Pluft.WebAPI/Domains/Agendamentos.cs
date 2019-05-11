using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class Agendamentos
    {
        public Agendamentos()
        {
            ProdutoAgendamentos = new HashSet<ProdutoAgendamentos>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEstabelecimento { get; set; }
        public int? IdStatus { get; set; }
        public int? IdLojista { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAgendamento { get; set; }

        public Clientes IdClienteNavigation { get; set; }
        public Estabelecimentos IdEstabelecimentoNavigation { get; set; }
        public Lojistas IdLojistaNavigation { get; set; }
        public StatusAgendamento IdStatusNavigation { get; set; }
        public ICollection<ProdutoAgendamentos> ProdutoAgendamentos { get; set; }
    }
}
