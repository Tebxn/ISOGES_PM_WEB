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
        public ActionResult EliminarCliente(long id)
        {
            ClienteEnt entidad = new ClienteEnt();
            entidad.IdCliente = id;

            var resp = model.EliminarClientePorId(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Cliente Eliminado";
                return RedirectToAction("ConsultarClientes", "Cliente");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido eliminar el cliente deseado";
                return View("ConsultarClientes", "Cliente");
            }
        }

        //FALTA EN EL API METODO EDITAR CLIENTE :(

        [HttpGet]
        public ActionResult EditarUsuario(long q)
        {
            var resp = model.ConsultaClientePorId(q);

            return View(resp);
        }
    }
}