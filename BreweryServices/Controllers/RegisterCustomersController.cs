using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BreweryServices.Models;

namespace BreweryServices.Controllers
{
    public class RegisterCustomersController : Controller
    {
        private BreweryServicesEntities db = new BreweryServicesEntities();

        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,Customer_FirstName,Customer_LastName,Customer_IdentificationNumber,Customer_DOB,Customer_Password,Customer_Cell,Customer_Email,Customer_Address")] Customer customer)
            
        {
            if (ModelState.IsValid)
            {

                CustomersModel customermodel = new CustomersModel();

                if (customermodel.validateAge() == true)
                {
                    if (customermodel.ValidateID() == true)
                    {
                        db.Customers.Add(customer);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else if (customermodel.ValidateID() == false)
                {
                    ViewBag.errormessage = "I.D Number error";
                    return View();
                }
                else
                {
                    ViewBag.AgeError = "No under 18 permitted";
                    return View();
                }
                //db.Customers.Add(customer);
                //db.SaveChanges();
                //return RedirectToAction("Index");

            }

            return View(customer);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
