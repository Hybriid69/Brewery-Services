using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreweryServices;
using BreweryServices.Controllers;
using BreweryServices.Models;

namespace BreweryServices.Tests.Controllers
{
    [TestClass]
   public class CustomerTests
    {
            [TestMethod]
            public void IDTest()
            {
               Customer c = new Customer();
            CustomersModel cm = new CustomersModel(); 
                c.Customer_IdentificationNumber = "9710145161084";
                bool expected = true;
                bool actual = cm.ValidateID();
                Assert.AreEqual(expected, actual);

            }

            [TestMethod]
            public void AgeTest()
            {
            Customer c = new Customer();
            CustomersModel cm = new CustomersModel();
            int Current = (Convert.ToInt16(DateTime.Now.Year.ToString()));
                CustomersModel customer = new CustomersModel();
                c.Customer_DOB = Convert.ToDateTime("14-10-1997");
                DateTime date = Convert.ToDateTime(c.Customer_DOB);
                string DOB = Convert.ToString(date).Substring(7, 4);
                int DOB2 = Convert.ToInt32(DOB);


                bool expected = true;
                bool actual = customer.validateAge();
                Assert.AreEqual(expected, actual);
            }
        [TestMethod]
        public void AdminLogin()
        {
            CustomerLoginModel clm = new CustomerLoginModel();
            bool expected = true;
            bool actual = clm.AdminLogin();

            Assert.AreEqual(expected, actual);


        }
    }
}
