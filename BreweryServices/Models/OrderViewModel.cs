using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BreweryServices.Models
{
    public class OrderViewModel
    {
        private BreweryServicesEntities db = new BreweryServicesEntities();

        //Irrelevant to customer
        public string Customer_ID { get; set; }
        public string Beverage_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Employee_Deliverer_Fullname { get; set; }
        public string Extras_ID { get; set; }
        public string Customer_FirstName { get; set; }
        public string Customer_LastName { get; set; }
        public string Order_Number { get; set; }
        public string customerfullname { get; set; }
        public string customernumber { get; set; }


        public string Beverage_Name { get; set; }
        public Nullable<int> Beverage_Quantity { get; set; }
        public Nullable<int> Extras_Quantity { get; set; }
        public string Order_Status { get; set; }
        public string Payment_Type { get; set; }
        public Nullable<int> Total_Cost { get; set; }
        public Nullable<int> Beverage_Cost { get; set; }
        public string Extras_Name { get; set; }
        public Nullable<int> Extras_Cost { get; set; }

        public virtual Beverage Beverage { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Extra Extra { get; set; }

        CustomerLoginModel cus = new CustomerLoginModel();
        public string getCustomerName()
        {
            var name = (from n in db.Customers
                        where n.Customer_ID == cus.Username
                        select n.Customer_FirstName + n.Customer_LastName).Single();
            return customerfullname;
        }

        public string getCell()
        {
            var number = (from n in db.Customers
                          where n.Customer_ID == cus.Username
                          select n.Customer_Cell).Single();
            return number;
        }
        public string BevergeID()
        {
            var Bname = (from b in db.Beverages
                         where b.Beverage_Name == Beverage_Name
                         select Beverage_ID).Single();
            return Bname;
        }
        public int? BeverageCost()
        {
            var Bcost = (from b in db.Beverages
                         where b.Beverage_Name == Beverage_Name
                         select Beverage_Cost).Single();
            return Bcost;
        }

        public string EmpDeliverername()
        {
            var Ename = (from en in db.Employees
                         where en.EmployeeID == Employee.Employee_FirstName
                         select en.Employee_FirstName + " " + en.Employee_Lastname).Single();
            return Ename;
        }
        public string ExtraID()
        {
            var cID = (from i in db.Extras
                      where i.Extras_Name == Extras_Name
                      select Extras_ID).Single();
            return cID;
        }
        public int? ExtraCost()
        {
            var cost = (from c in db.Extras
                        where c.Extras_Name == Extras_Name
                        select Extras_Cost).Single();
            return cost;
        }

    }
}