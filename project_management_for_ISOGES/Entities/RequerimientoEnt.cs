using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class RequerimientoEnt
    {
        public long IdRequerimiento { get; set; }
        public string CodigoRequerimiento { get; set; }
        public string NombreRequerimiento { get; set; }
        public string DescripcionRequerimiento { get; set; }
        public string URLRequerimiento { get; set; }
        public bool Estado { get; set; }
    }
}