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
using System.Security.Cryptography.X509Certificates;

namespace project_management_for_ISOGES.Controllers
{
    public class AgendaController : Controller
    {
        Requerimiento_ProyectoModel model = new Requerimiento_ProyectoModel();

        [HttpGet]
        public ActionResult ConsultarAgenda()
        {
            var datos = model.ConsultarAgenda(long.Parse(Session["IdUsuario"].ToString()));
            return View(datos);
        }

        [HttpGet]
        public ActionResult CambiarEstadoAgenda(long q, long q2)
        {
            Requerimiento_ProyectoEnt entidad = new Requerimiento_ProyectoEnt();
            entidad.IdRequerimiento = q2;
            entidad.IdProyecto = q;
            entidad.EmpleadoAsignado = long.Parse(Session["IdUsuario"].ToString()); 

            var resp = model.CambiarEstadoAgenda(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Tarea actualizada";
                return RedirectToAction("ConsultarAgenda", "Agenda");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido completar la tarea";
                return RedirectToAction("ConsultarAgenda", "Agenda");
            }
        }
    }
}