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
            var respEstados = model.ConsultarEstadosProyecto();

            var clientes = new List<SelectListItem>();
            var estados = new List<SelectListItem>();

            foreach (var item in respClientes)
            {
                clientes.Add(new SelectListItem { Value = item.IdCliente .ToString(), Text = item.NombreCliente.ToString() });
            }

            foreach (var item in respEstados)
            {
                estados.Add(new SelectListItem { Value = item.IdEstadoProyecto.ToString(), Text = item.NombreEstado.ToString() });
            }
            ViewBag.ComboClientes = clientes;
            ViewBag.ComboEstados = estados;

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
        public ActionResult EditarProyecto(long q)
        {
            var resp = model.ConsultarProyectoPorId(q);
            var respClientes = model.ConsultarClientes();
            var respEstados = model.ConsultarEstadosProyecto();

            var clientes = new List<SelectListItem>();
            var estados = new List<SelectListItem>();

            foreach (var item in respClientes)
            {
                clientes.Add(new SelectListItem { Value = item.IdCliente.ToString(), Text = item.NombreCliente.ToString() });
            }

            foreach (var item in respEstados)
            {
                estados.Add(new SelectListItem { Value = item.IdEstadoProyecto.ToString(), Text = item.NombreEstado.ToString() });
            }

            ViewBag.ComboClientes = clientes;
            ViewBag.ComboEstados = estados;

            return View(resp);
        }

        [HttpPost]
        public ActionResult EditarProyecto(Entities.ProyectoEnt entidad)
        {
            var resp = model.EditarProyecto(entidad);

            

            return RedirectToAction("ConsultarProyectos", "Proyecto");
        }

        [HttpGet]
        public ActionResult InactivarProyecto(long q)
        {
            Entities.ProyectoEnt entidad = new Entities.ProyectoEnt();

            entidad.IdProyecto = q;

            var resp = model.InactivarProyecto(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Proyecto Inactivo";
                return RedirectToAction("ConsultarProyectos", "Proyecto");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido Inactivar el estado del proyecto";
                return View("ConsultarProyectos", "Proyecto");
            }
        }

        [HttpGet]
        public ActionResult ListadoProyectos()
        {
            var resp = model.ConsultarProyectos();
            return View(resp);
        }


    }
}