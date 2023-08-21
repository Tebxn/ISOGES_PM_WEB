using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class Requerimiento_ProyectoEnt
    {
        public long IdProyecto { get; set; }
        public long IdRequerimiento { get; set; }
        public long EmpleadoAsignado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public bool Estado { get; set; }


        //Apartado para campos necesarios para Proyecto
        public string NombreProyecto { get; set; }
        public string DescripcionProyecto { get; set; }
        public float MontoEstimadoProyecto { get; set; }
        public string NombreClienteProyecto { get; set; }

        //Apartado para campos necesarios para Proyecto
        public string NombreRequerimiento { get; set; }
        public string CodigoRequerimiento { get; set; }
        public string URLRequerimiento { get; set; }
        public string DescripcionRequerimiento { get; set; }
        public string NombreEmpleadoAsignado { get; set; }

    }
}