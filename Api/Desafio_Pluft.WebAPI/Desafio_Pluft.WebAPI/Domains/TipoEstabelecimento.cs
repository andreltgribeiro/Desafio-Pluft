using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class TipoEstabelecimento
    {
        public TipoEstabelecimento()
        {
            Estabelecimentos = new HashSet<Estabelecimentos>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<Estabelecimentos> Estabelecimentos { get; set; }
    }
}
