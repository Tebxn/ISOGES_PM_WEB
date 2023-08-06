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
            var respChartAnual = modelChart.CargarChartAnualIngreso();
            List<string> anios = new List<string>();
            List<string> mes = new List<string>();
            List<string> diaMes = new List<string>();
            foreach (var item in respChartAnual)
            {
                anios.Add(item.Anio.ToString());
                mes.Add(item.Mes.ToString());
                diaMes.Add(item.DiaMes.ToString());
            }
            //Separar anios
            List<string> aniosIndividuales = new List<string>();
            foreach (var item in anios)
            {
                if (!aniosIndividuales.Contains(item))
                {
                    aniosIndividuales.Add(item);
                }
            }
                //SepararMontosPorAnio
                List<double> montosPorAnio = new List<double>();
                foreach (var item in aniosIndividuales)
                {
                    var datos = respChartAnual.Where(p => p.Anio.Equals(item));
                    double montoPorAnio = 0;

                    foreach (var x in datos)
                    {
                        montoPorAnio += x.IngresosTotales;
                    }
                    montosPorAnio.Add(montoPorAnio);
                }

            double totalIngresosHistorico = montosPorAnio.Sum();
            string anioActual = util.ConseguirAnioActual();
            var respTotalIngresosAnioActual = respChartAnual.Where(p => p.Anio.Equals(anioActual));
            double totalIngresosAnioActual = 0;
            foreach (var item in respTotalIngresosAnioActual)
            {
                totalIngresosAnioActual += item.IngresosTotales; 
            }

            ViewBag.Anios = aniosIndividuales;
            ViewBag.Meses = mes;
            ViewBag.DiaMes = diaMes;
            ViewBag.TotalIngresosHistorico = totalIngresosHistorico;
            ViewBag.TotalIngresosAnioActual = totalIngresosAnioActual;
            ViewBag.MontosPorAnio = montosPorAnio;
            ViewBag.AnioActual = anioActual;

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