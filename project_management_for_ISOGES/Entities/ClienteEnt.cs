using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class ClienteEnt
    {
        public long IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Identificacion { get; set; }
        public bool Estado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}