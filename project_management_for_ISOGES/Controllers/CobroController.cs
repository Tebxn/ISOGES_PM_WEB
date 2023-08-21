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

        [HttpGet]
        public ActionResult CrearCobro()
        {
            var respProyectos = model.ConsultarProyectos();
            var respTipos = model.ConsultarTipoCobros();
            var respEstadosCobros = model.ConsultarEstadoCobros();



            var proyectos = new List<SelectListItem>();
            var tipoCobros = new List<SelectListItem>();
            var estadoCobros = new List<SelectListItem>();
            foreach (var item in respProyectos)
            {
                proyectos.Add(new SelectListItem { Value = item.IdProyecto.ToString(), Text = item.NombreProyecto.ToString() });
            }

            foreach (var item in respTipos)
            {
                tipoCobros.Add(new SelectListItem { Value = item.IdTipoCobro.ToString(), Text = item.NombreTipoCobro.ToString() });
            }

            foreach (var item in respEstadosCobros)
            {
                estadoCobros.Add(new SelectListItem { Value = item.IdEstadoCobro.ToString(), Text = item.NombreEstado.ToString() });
            }

            ViewBag.ComboProyectos = proyectos;
            ViewBag.ComboTipoCobros = tipoCobros;
            ViewBag.ComboEstadoCobros = estadoCobros;

            return View();
        }

        [HttpPost]
        public ActionResult CrearCobro(Entities.CobroEnt entidad)
        {
            CobroModel model = new CobroModel();
            model.CrearCobro(entidad);

            return RedirectToAction("CobrosMain", "Cobro");
        }

    }
    
}