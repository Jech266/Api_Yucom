using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yucom.Validaciones;

namespace Yucom.DTOs
{
    public class EventosCreationDTO
    {
        [PrimeraLetra]
        public string Nombre { get; set; }
        public string Descripcion {get; set; }
        public string Fotografia { get; set; }
        public DateTime Fecha { get; set; }
        public List<int> SedesIds { get; set; }
        public List<int> PresentadoresIds { get; set; }
    }
}