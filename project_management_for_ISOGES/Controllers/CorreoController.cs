using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_management_for_ISOGES.Models;

namespace project_management_for_ISOGES.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        CorreoModel model = new CorreoModel();


        [HttpGet]
        public ActionResult ConsultarCorreos()
        {
            var resp = model.ConsultarCorreos();
            return View(resp);
        }

        [HttpGet]
        public ActionResult CrearCorreo()
        {
            var respClientes = model.ConsultarClientes();


            var clientes = new List<SelectListItem>();
            foreach (var item in respClientes)
            {
                clientes.Add(new SelectListItem { Value = item.IdCliente.ToString(), Text = item.CorreoElectronico.ToString() });
            }


            ViewBag.ComboClientes = clientes;

            return View();
        }

        [HttpPost]
        public ActionResult CrearCorreo(Entities.CorreoEnt entidad)
        {
            CorreoModel model = new CorreoModel();
            model.CrearCorreo(entidad);

            return RedirectToAction("ConsultarCorreos", "Correo");
        }

        [HttpGet]
        public ActionResult EliminarCorreo(long q)
        {
            Entities.CorreoEnt entidad = new Entities.CorreoEnt();

            entidad.IdCorreo = q;

            var resp = model.EliminarCorreo(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Proyecto Inactivo";
                return RedirectToAction("ConsultarCorreos", "Correo");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido Inactivar el estado del proyecto";
                return View("ConsultarCorreos", "Correo");
            }
        }

    }
}