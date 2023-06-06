using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_management_for_ISOGES.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult Login() => View();
        [HttpPost]
        public ActionResult Login(UserEnt user)
        {
            /* PROGRA */

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register() => View();
        [HttpPost]
        public ActionResult Register(UserEnt user)
        {
            /* PROGRA */

            return RedirectToAction("Login", "Home");
        }
    }
}