using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreweryServices.Controllers
{
    public class AdminMenuController : Controller
    {
        // GET: AdminMenu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customers()
        {
            return RedirectToAction("Index", "CustomerAdminTasks");
        }
        public ActionResult Extras()
        {
            return RedirectToAction("Index", "Extras");
        }
        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Administrators");
        }
        public ActionResult Vehicles()
        {
            return RedirectToAction("Index", "Vehicles");
        }
    }
}