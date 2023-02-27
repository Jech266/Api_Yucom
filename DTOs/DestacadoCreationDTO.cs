using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yucom.DTOs
{
    public class DestacadoCreationDTO
    {
        public int Id { get; set; }
        public List<EventoDestacado> eventoDestacado { get; set; }
    }
}