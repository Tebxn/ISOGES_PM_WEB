using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class RequerimientosController : Controller
    {
        RequerimientoModel model = new RequerimientoModel();

        [HttpGet]
        public ActionResult ConsultarRequerimientos()
        {
            var resp = model.ConsultarRequerimientos();
            return View(resp);
        }

        [HttpGet]
        public ActionResult CrearRequerimiento() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearRequerimiento(Entities.RequerimientoEnt entidad)
        {
            RequerimientoModel model = new RequerimientoModel();
            model.CrearRequerimiento(entidad);

            return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
        }

        [HttpDelete]
        public ActionResult EliminarRequerimiento(long q)
        {
            RequerimientoEnt entidad = new RequerimientoEnt();
            entidad.IdRequerimiento = q;

            var resp = model.EliminarRequerimiento(q);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Requerimiento Eliminado";
                return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido eliminar el requerimiento";
                return View("ConsultarRequerimientos", "Requerimientos");
            }
        }

        [HttpGet]
        public ActionResult EditarRequerimiento(long q)
        {
            var resp = model.ConsultaRequerimientoPorId(q);
            
            return View(resp);
        }

        [HttpPost]
        public ActionResult EditarRequerimiento(RequerimientoEnt entidad)
        {
            var resp = model.EditarRequerimiento(entidad);

            return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
        }
    }
}