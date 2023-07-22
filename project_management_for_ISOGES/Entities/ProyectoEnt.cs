﻿using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class ProyectoEnt 
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cliente { get; set; }
        public bool Estado { get; set; }
        public float MontoEstimado { get; set; }
    }

    public class ProyectoResponse : Response
    {
        public ProyectoEnt ObjectSingle { get; set; } = new ProyectoEnt();
        public List<ProyectoEnt> ObjectList { get; set; } = new List<ProyectoEnt>();
    }
}