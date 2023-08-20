using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class ProyectoEnt
    {
        public long IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public long Cliente { get; set; }
        public string NombreCliente { get; set; }
        public bool Estado { get; set; }
        public double MontoEstimado { get; set; }
        public long EstadoGeneral { get; set; }
        public String NombreEstado { get; set; }

    }

    public class ProyectoResponse : Response
    {
        public ProyectoEnt ObjectSingle { get; set; } = new ProyectoEnt();
        public List<ProyectoEnt> ObjectList { get; set; } = new List<ProyectoEnt>();
    }

}