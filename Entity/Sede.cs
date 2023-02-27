using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Yucom.Validaciones;

namespace Yucom.Entity
{
    public class Sede
    {
        public int Id {get; set;}
        [PrimeraLetra]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 12)]
        [Required]
        public string RFC { get; set; }
        public string Imagenes { get; set; }
        public string Descripcion { get; set; }
        public bool Status {get; set; }
        public List<EventoSede> eventoSedes {get; set; }
 
    }
}


