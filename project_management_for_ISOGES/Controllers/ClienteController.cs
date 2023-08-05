using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ClienteModel model = new ClienteModel();

        [HttpGet]
        public ActionResult ConsultarClientes()
        {
            var resp = model.ConsultarClientes();
            return View(resp);
        }

        [HttpGet]
        public ActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCliente(Entities.ClienteEnt entidad)
        {
            ClienteModel model = new ClienteModel();
            model.CrearCliente(entidad);

            return RedirectToAction("ConsultarClientes", "Cliente");
        }

        [HttpGet]
        public ActionResult EliminarCliente(long q)
        {
            Entities.ClienteEnt entidad = new Entities.ClienteEnt();

            entidad.IdCliente = q;

            var resp = model.EliminarCliente(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Cliente Inactivado";
                return RedirectToAction("ConsultarClientes", "Cliente");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido Inactivar el estado del cliente";
                return View("ConsultarClientes", "Cliente");
            }
        }

        [HttpGet]
        public ActionResult EditarCliente(long q)
        {
            var resp = model.ConsultarClientePorId(q);

            return View(resp);
        }

        [HttpPost]
        public ActionResult EditarCliente(Entities.ClienteEnt entidad)
        {
            var resp = model.EditarCliente(entidad);



            return RedirectToAction("ConsultarClientes", "Cliente");
        }

    }
}