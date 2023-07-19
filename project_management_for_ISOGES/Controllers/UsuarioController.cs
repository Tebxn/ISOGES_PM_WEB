using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
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
        public ActionResult CrearUsuario()
        {
            var respRoles = model.ConsultarTiposUsuarios();
            var respPuestos = model.ConsultarPuestos();

            var roles = new List<SelectListItem>();
            foreach (var item in respRoles)
            {
                roles.Add(new SelectListItem { Value = item.IdTipoUsuario.ToString(), Text = item.NombreTipo.ToString() });
            }

            var puestos = new List<SelectListItem>();
            foreach (var item in respPuestos)
            {
                puestos.Add(new SelectListItem { Value = item.IdPuesto.ToString(), Text = item.NombrePuesto.ToString() });
            }

            ViewBag.ComboRoles = roles;
            ViewBag.ComboPuestos = puestos;

            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuario(Entities.UsuarioEnt entidad)
        {
            UsuarioModel model = new UsuarioModel();
            model.CrearUsuario(entidad);

            return RedirectToAction("ConsultarUsuarios", "Usuario");
        }

        [HttpGet]
        public ActionResult InactivarUsuario(long q)
        {
            UsuarioEnt entidad = new UsuarioEnt();
            entidad.IdUsuario = q;

            var resp = model.InactivarUsuario(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Usuario Inactivo";
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido Inactivar el estado del usuario";
                return View("ConsultarUsuarios", "Usuario");
            }
        }

        [HttpGet]
        public ActionResult EditarUsuario(long q)
        {
            var resp = model.ConsultaUsuarioPorId(q);
            var respRoles = model.ConsultarTiposUsuarios();
            var respPuestos = model.ConsultarPuestos();

            var roles = new List<SelectListItem>();
            foreach (var item in respRoles)
            {
                roles.Add(new SelectListItem { Value = item.IdTipoUsuario.ToString(), Text = item.NombreTipo.ToString() });
            }

            var puestos = new List<SelectListItem>();
            foreach (var item in respPuestos)
            {
                puestos.Add(new SelectListItem { Value = item.IdPuesto.ToString(), Text = item.NombrePuesto.ToString() });
            }

            ViewBag.ComboRoles = roles;
            ViewBag.ComboPuestos = puestos;
            return View(resp);
        }
    }
}