using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class ProyectoEnt 
    {
        public string NombreProyecto { get; set; }
        public long IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public long Cliente { get; set; }
        public string NombreCliente { get; set; }
        public bool Estado { get; set; }
        public float MontoEstimado { get; set; }
    }

}