using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class EstadoCobroEnt
    {
        public long IdEstadoCobro { get; set; }
        public string NombreEstado { get; set; }
    }

    public class EstadoCobroResponse : Response
    {
        public EstadoCobroEnt ObjectSingle { get; set; } = new EstadoCobroEnt();
        public List<EstadoCobroEnt> ObjectList { get; set; } = new List<EstadoCobroEnt>();
    }
}