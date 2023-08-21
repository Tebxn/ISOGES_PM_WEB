using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class TipoCobroEnt
    {  public int IdTipoCobro { get; set; }
       public string NombreTipoCobro { get; set; }

    }

    public class TipoCobroResponse : Response
    {
        public TipoCobroEnt ObjectSingle { get; set; } = new TipoCobroEnt();
        public List<TipoCobroEnt> ObjectList { get; set; } = new List<TipoCobroEnt>();
    }
}