using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        ChartModel modelChart = new ChartModel();
        UtilitiesModel util = new UtilitiesModel();

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
            string anioActual = util.ConseguirAnioActual();

            List<string> listaAnios = new List<string>();
            listaAnios = modelChart.ConseguirListaAnios();

            double totalIngresosAnioActual = modelChart.ConseguirTotalIngresosAnioActual();
            string totalIngresosAnioFormat = totalIngresosAnioActual.ToString("₡0,0.00");

            List<double> listaIngresosPorMes = new List<double>();
            listaIngresosPorMes = modelChart.ListarIngresosMensuales(anioActual);

            List<double> montosPorAnio = new List<double>();
            montosPorAnio = modelChart.CargarListaMontosPorAnio();

            double totalIngresosHistorico = montosPorAnio.Sum();
            string totalHistoricoFormat = totalIngresosHistorico.ToString("₡0,0.00");

            ViewBag.Anios = listaAnios;
            ViewBag.TotalIngresosHistorico = totalHistoricoFormat;
            ViewBag.TotalIngresosAnioActual = totalIngresosAnioFormat;
            ViewBag.MontosPorAnio = montosPorAnio;
            ViewBag.AnioActual = anioActual;
            ViewBag.ListaIngresosPorMes = listaIngresosPorMes;

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