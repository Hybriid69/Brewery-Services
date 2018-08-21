using BreweryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreweryServices.Controllers
{
    public class LoginController : Controller
    {
        private BreweryServicesEntities db = new BreweryServicesEntities();

        // GET: CustomerLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLoginModel login)
        {
            //try
            //{                     select P.Customer_Password).Single();
                if (login.CustomerLogin() == true)
                {
                    return Content("Welcome Customer...Under Construction but Username and Password Correct...Order Page Route goes here ");
                }
                else if (login.AdminLogin() == true)
                {
                return RedirectToAction("Index","AdminMenu");               
                //return View("../CustomerAdminTasks/Index");
                }
                else
                {
                    return View(/*".../ Views / Customer / Logins / Create"*/);

                }

               
            //}
            //catch
            //{                
            //ViewBag.LoginError = "Username or Password Incorrect";
            //}
            
            //return View();
            //return View("../Customers/Index");
        }
    }
}
