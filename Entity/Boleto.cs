using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yucom.Entity
{
    public class Boleto
    {
        public int Id {get; set; }
        public string Tipo { get; set; }
        public int Asientos { get; set; }
        public string Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEvento { get; set; }
        public Evento evento { get; set; }
    }
}