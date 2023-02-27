using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yucom.Entity;
using Yucom.Validaciones;

namespace Yucom.DTOs
{
    public class EventoDTO
    {
        [PrimeraLetra]
        public string Nombre { get; set; }
        public string Descripcion {get; set; }
        public string Fotografia {get; set; }
        public DateTime Fecha { get; set; }
        public List<SedeCreationDTO> sede {get; set; }
        public List<PresentadorCreationDTO> presentadorCreationDTOs { get; set; }
    }
}