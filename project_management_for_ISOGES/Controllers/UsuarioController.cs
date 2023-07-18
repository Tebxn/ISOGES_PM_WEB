using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        [HttpGet]
        public ActionResult ConsultarUsuarios()
        {
            var resp = model.ConsultarUsuarios();
            return View(resp);
        }

        [HttpGet]
        public ActionResult CrearUsuario() => View();

        [HttpPost]
        public ActionResult CrearUsuario(Entities.UsuarioEnt entidad)
        {
            UsuarioModel model = new UsuarioModel();
            model.CrearUsuario(entidad);

            return RedirectToAction("ConsultarUsuarios", "Usuario");
        }
    }
}