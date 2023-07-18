using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        UsuarioModel model = new UsuarioModel();

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt entidad)
        {
            var resp = model.IniciarSesion(entidad);

            if (resp != null)
            {
                
                Session["NombreUsuario"] = resp.Nombre;
                Session["Apellido1"] = resp.Apellido1;
                Session["NombreTipoUsuario"] = resp.NombreTipoUsuario;
                return RedirectToAction("Index");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }

    }
}