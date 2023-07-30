using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    //Version estable 20/07/2023
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
            UsuarioResponse entidadEnviada = new UsuarioResponse();
            entidadEnviada.ObjectSingle = entidad;
            var resp = model.IniciarSesion(entidadEnviada);

            if (resp.ObjectSingle.Estado)
            {
                Session["IdUsuario"] = resp.ObjectSingle.IdUsuario;
                Session["CorreoElectronico"] = resp.ObjectSingle.CorreoElectronico;
                Session["NombreUsuario"] = resp.ObjectSingle.Nombre;
                Session["Apellido1"] = resp.ObjectSingle.Apellido1;
                Session["NombreTipoUsuario"] = resp.ObjectSingle.NombreTipoUsuario;
                Session["PassIsTemp"] = resp.ObjectSingle.PassIsTemp;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MsjPantalla = resp.ReturnMessage.ToString();
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