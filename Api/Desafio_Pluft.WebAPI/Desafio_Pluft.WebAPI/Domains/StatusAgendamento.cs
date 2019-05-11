using System;
using System.Collections.Generic;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class StatusAgendamento
    {
        public StatusAgendamento()
        {
            Agendamentos = new HashSet<Agendamentos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Agendamentos> Agendamentos { get; set; }
    }
}
