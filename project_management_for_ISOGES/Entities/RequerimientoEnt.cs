using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class RequerimientoEnt
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaConclusion { get; set; }
        public int EmpleadoAsignado { get; set; }
        public bool Estado { get; set; }
    }
}