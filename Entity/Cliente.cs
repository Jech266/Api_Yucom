using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yucom.Validaciones;

namespace Yucom.Entity
{
    public class Cliente
    {
        public int Id {get; set;}
        public string usuario  { get; set; }
        public string estadoPago { get; set; }
    }
}