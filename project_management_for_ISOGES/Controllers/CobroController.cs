using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class CobroController : Controller
    {
        CobroModel model = new CobroModel();
        ProyectoModel modelProyecto = new ProyectoModel();

        [HttpGet]
        public ActionResult CobrosMain()
        {
            var resp = model.ListadoCobros();
            return View(resp);
        }

        [HttpGet]
        public ActionResult ConsultarCobrosPorProyecto(long q)
        {
            var resp = model.ConsultarCobrosPorProyecto(q);
            if (resp != null) 
            {
                return View(resp);
            }

            ViewBag.MsjError = "Aún no existen cobros asociados a este proyecto";
            
            return RedirectToAction("CobrosMain", "Cobro");
        }
    }
    
}