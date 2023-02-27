using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yucom.Entity
{
    public class EventoSede
    {
        public int EventoId { get; set; }
        public int SedeId { get; set; }
        public int Orden { get; set; }
        public Evento evento { get; set;}
        public Sede sede {get; set; }
    }
}