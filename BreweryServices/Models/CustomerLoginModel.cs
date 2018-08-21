using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreweryServices.Models
{
    public class CustomerLoginModel
    {
        private BreweryServicesEntities db = new BreweryServicesEntities();

        [Required]
        [Key]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool CustomerLogin()
        {
          try { 
            
            var CustomerUsername = (from login in db.Customers
                                    where login.Customer_ID == Username
                                    select login.Customer_ID).Single();

            var CustomerPassword = (from P in db.Customers
                                    where P.Customer_ID == CustomerUsername
                                    select P.Customer_Password).Single();


            if (CustomerUsername == Username)
            {
                if (CustomerPassword == Password)
                {
                    return true;
                }
            }
           }
            catch
            {

            }
            return false;

        }
        public bool AdminLogin()
        {
            try
            {
                var AdminUsername = (from AU in db.Admins
                                     where AU.Admin_EmployeeID == Username
                                     select AU.Admin_EmployeeID).Single();

                var AdminPassword = (from AP in db.Admins
                                     where AP.Admin_EmployeeID == AdminUsername
                                     select AP.Admin_Password).Single();
                if (AdminUsername == Username)
                {
                    if (AdminPassword == Password)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }

    }
}