﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class UsuarioEnt // Empleado
    {
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Identificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public int TipoUsuario { get; set; }
        public bool Estado { get; set; }
        public string Contrasena { get; set; }
        public string Puesto { get; set; }
        public string NombreTipoUsuario { get; set; }
    }
}