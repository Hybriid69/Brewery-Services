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
    public class OrdersController : Controller
    {
        private BreweryServicesEntities db = new BreweryServicesEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Beverage).Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Extra);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Beverage_ID = new SelectList(db.Beverages, "Beverage_ID", "Beverage_Name");
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_FirstName");
            ViewBag.Employee_ID = new SelectList(db.Employees, "EmployeeID", "Employee_FirstName");
            ViewBag.Extras_ID = new SelectList(db.Extras, "Extras_ID", "Extras_Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Number,Customer_ID,Beverage_ID,Employee_ID,Extras_ID,Customer_FirstName,Customer_LastName,Beverage_Name,Beverage_Quantity,Extras_Quantity,Order_Status,Payment_Type,Total_Cost,Beverage_Cost,Extras_Name,Extras_Cost")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                ViewBag.Sucess = "Order Placed Sucessfully";
                return RedirectToAction("Details");
            }

            ViewBag.Beverage_ID = new SelectList(db.Beverages, "Beverage_ID", "Beverage_Name", order.Beverage_ID);
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_FirstName", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "EmployeeID", "Employee_FirstName", order.Employee_ID);
            ViewBag.Extras_ID = new SelectList(db.Extras, "Extras_ID", "Extras_Name", order.Extras_ID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Beverage_ID = new SelectList(db.Beverages, "Beverage_ID", "Beverage_Name", order.Beverage_ID);
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_FirstName", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "EmployeeID", "Employee_FirstName", order.Employee_ID);
            ViewBag.Extras_ID = new SelectList(db.Extras, "Extras_ID", "Extras_Name", order.Extras_ID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Number,Customer_ID,Beverage_ID,Employee_ID,Extras_ID,Customer_FirstName,Customer_LastName,Beverage_Name,Beverage_Quantity,Extras_Quantity,Order_Status,Payment_Type,Total_Cost,Beverage_Cost,Extras_Name,Extras_Cost")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Customer_FirstName = order.getCustomerFirstName();
                order.Customer_LastName = order.getCustomerSurname();
                order.Beverage_ID = order.BevergeID();
                order.Beverage_Cost = order.BeverageCost();
                order.Extras_ID = order.ExtraID();
                order.Extras_Cost = order.ExtraCost();
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Beverage_ID = new SelectList(db.Beverages, "Beverage_ID", "Beverage_Name", order.Beverage_ID);
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_FirstName", order.Customer_ID);
            ViewBag.Employee_ID = new SelectList(db.Employees, "EmployeeID", "Employee_FirstName", order.Employee_ID);
            ViewBag.Extras_ID = new SelectList(db.Extras, "Extras_ID", "Extras_Name", order.Extras_ID);
            return View(order);
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
