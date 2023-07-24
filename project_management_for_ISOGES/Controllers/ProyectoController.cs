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

        [HttpGet]
        public ActionResult CrearProyecto()
        {
            var respClientes = model.ConsultarClientes();
            

            var clientes = new List<SelectListItem>();
            foreach (var item in respClientes)
            {
                clientes.Add(new SelectListItem { Value = item.IdCliente .ToString(), Text = item.Nombre.ToString() });
            }


            ViewBag.ComboClientes = clientes;

            return View();
        }

        [HttpPost]
        public ActionResult CrearProyecto(Entities.ProyectoEnt entidad)
        {
            ProyectoModel model = new ProyectoModel();
            model.CrearProyecto(entidad);

            return RedirectToAction("ConsultarProyectos", "Proyecto");
        }

        [HttpGet]
        public ActionResult EditarProyectoClientes()
        {
            var respClientes = model.ConsultarClientes();


            var clientes = new List<SelectListItem>();
            foreach (var item in respClientes)
            {
                clientes.Add(new SelectListItem { Value = item.IdCliente.ToString(), Text = item.Nombre.ToString() });
            }


            ViewBag.ComboClientes = clientes;

            return View();
        }


        [HttpGet]
        public ActionResult EditarProyecto(long q)
        {
            var resp = model.ConsultarProyectoPorId(q);

            return View(resp);
        }

        [HttpPost]
        public ActionResult EditarProyecto(Entities.ProyectoEnt entidad)
        {
            var resp = model.EditarProyecto(entidad);

            

            return RedirectToAction("ConsultarProyectos", "Proyecto");
        }



     

     

    }
}