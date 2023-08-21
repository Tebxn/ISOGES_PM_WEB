using project_management_for_ISOGES.Entities;
using project_management_for_ISOGES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class TipoCobroController : Controller
    {
        // GET: Cliente
        TipoCobroModel model = new TipoCobroModel();

        [HttpGet]
        public ActionResult ConsultarTipoCobros()
        {
            var resp = model.ConsultarTipoCobros();
            return View(resp);
        }

  

    }
}