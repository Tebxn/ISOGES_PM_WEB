using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class EstadoCobroController : Controller
    {
        EstadoCobroModel model = new EstadoCobroModel();

        [HttpGet]
        public ActionResult ConsultarEstadoCobros()
        {
            var resp = model.ConsultarEstadoCobros();
            return View(resp);
        }
    }
    
}