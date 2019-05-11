using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class ProdutoAgendamentos
    {
        public int Id { get; set; }
        public int? IdAgendamento { get; set; }
        public int? IdProdutos { get; set; }

        public Agendamentos IdAgendamentoNavigation { get; set; }
        public Produtos IdProdutosNavigation { get; set; }
    }
}
