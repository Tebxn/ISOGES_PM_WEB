using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class RequerimientosController : Controller
    {
        RequerimientoModel model = new RequerimientoModel();
        ProyectoModel proyectoModel = new ProyectoModel();
        UsuarioModel usuarioModel = new UsuarioModel();


        [HttpGet]
        public ActionResult ConsultarRequerimientos()
        {
            var resp = model.ConsultarRequerimientos();
            return View(resp);
        }

        [HttpGet]
        public ActionResult CrearRequerimiento() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearRequerimiento(Entities.RequerimientoEnt entidad)
        {
            RequerimientoModel model = new RequerimientoModel();
            model.CrearRequerimiento(entidad);

            return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
        }

        [HttpGet]
        public ActionResult InactivarRequerimiento(long q)
        {
            RequerimientoEnt entidad = new RequerimientoEnt();
            entidad.IdRequerimiento = q;

            var resp = model.InactivarRequerimiento(entidad);

            if (resp > 0)
            {
                ViewBag.MsjPantalla = "Estado Actualizado";
                return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
            }
            else
            {
                ViewBag.MsjPantalla = "No se ha podido inactivar el requerimiento";
                return View("ConsultarRequerimientos", "Requerimientos");
            }
        }

        [HttpGet]
        public ActionResult EditarRequerimiento(long q)
        {
            var resp = model.ConsultaRequerimientoPorId(q);
            
            return View(resp);
        }

        [HttpPost]
        public ActionResult EditarRequerimiento(RequerimientoEnt entidad, HttpPostedFileBase file)
        {
            string extension = System.IO.Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
            int tamanno = file.ContentLength;
            string nombreArchivo = System.IO.Path.GetFileName(file.FileName);

            if (extension == ".pdf" && tamanno <= 1048576)
            {
                string ruta = @"C:\Users\Saul Hernandez\source\repos\ISOGES_PM_WEB\project_management_for_ISOGES\PDFs\" + nombreArchivo;
                file.SaveAs(ruta);
                entidad.URLRequerimiento = @"\PDFs\" + nombreArchivo;

                var resp = model.EditarRequerimiento(entidad);
                return RedirectToAction("ConsultarRequerimientos", "Requerimientos");
            }
            else
            {
                if (extension != ".pdf")
                {
                    ViewBag.MsjPantalla = "No se aceptan archivos diferentes a PDF";
                    return View();
                } 
                else
                {
                    ViewBag.MsjPantalla = "Archivo muy grande";
                    return View();
                }
            }

        }
        [HttpGet]
        public ActionResult NuevoTask(long q)
        {
            var listadoRequerimientos = model.ConsultarRequerimientos();
            var listadoUsuarios = usuarioModel.ConsultarUsuarios();
            var proyecto = proyectoModel.ConsultarProyectoPorId(q);

            var requerimientos = new List<SelectListItem>();
            var usuarios = new List<SelectListItem>();

            foreach (var item in listadoRequerimientos)
            {
                requerimientos.Add(new SelectListItem { Value = item.IdRequerimiento.ToString(), Text = item.NombreRequerimiento.ToString() });
            }

            foreach (var item in listadoUsuarios)
            {
                usuarios.Add(new SelectListItem { Value = item.IdUsuario.ToString(), Text = item.Nombre.ToString() });
            }
            ViewBag.ComboRequerimientos = requerimientos;
            ViewBag.ComboUsuarios = usuarios;

            return View(proyecto);
        }

        [HttpPost]
        public ActionResult NuevoTask(Entities.Requerimiento_ProyectoEnt entidad)
        {
            model.NuevoTask(entidad);

            return RedirectToAction("ConsultarProyectos", "Proyecto");
        }
    }
}