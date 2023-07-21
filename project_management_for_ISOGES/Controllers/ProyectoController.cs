using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class ProyectoController : Controller 
    {
        ProyectoModel model = new ProyectoModel();

        [HttpGet]
        public ActionResult ConsultarProyectos()
        {
            var resp = model.ConsultarProyectos();
            return View(resp);
        }


    }
}