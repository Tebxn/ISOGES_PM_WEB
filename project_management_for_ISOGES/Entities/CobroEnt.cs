using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class CobroEnt
    {
        public int TipoCobro { get; set; }
        public DateTime Fecha { get; set; }
        public bool EstadoCobro { get; set; }
        public float Monto { get; set; }
    }
}