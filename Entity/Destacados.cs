using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yucom.DTOs;

namespace Yucom.Entity
{
    public class Destacados
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public List<EventoDestacado> eventoDestacados { get; set; }
    }
}