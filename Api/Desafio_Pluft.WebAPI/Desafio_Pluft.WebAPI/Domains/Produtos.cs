using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class Produtos
    {
        public Produtos()
        {
            ProdutoAgendamentos = new HashSet<ProdutoAgendamentos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QtdEstoque { get; set; }
        public int? IdEstabelec { get; set; }

        public Estabelecimentos IdEstabelecNavigation { get; set; }
        public ICollection<ProdutoAgendamentos> ProdutoAgendamentos { get; set; }
    }
}
