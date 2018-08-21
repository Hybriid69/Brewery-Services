using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BreweryServices.Models
{
    public class CustomersModel
    {

        private BreweryServicesEntities db = new BreweryServicesEntities();
        Customer customer = new Customer();

        [Key]
        [Required]
        [Display(Name = "Customer ID")]
        public string Customer_ID { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Customer_Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Customer_Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = " Name")]
        public string Customer_FirstName { get; set; }
        [Required]
        [Display(Name = " Surname")]
        public string Customer_LastName { get; set; }
        [Required]
        [Display(Name = "ID Number")]
        [RegularExpression(@"^[0-9]{13,13}$", ErrorMessage = "Must be only 13 digits")]
        public string Customer_IdentificationNumber { get; set; }

        [Required]
        //[RegularExpression(@"[0-9]{1,2}$"+"-"+@"[0-9]{1,2}$"+"-"+@"[0-9]{4,4}$")]
        //[MinimumAge(18)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = " Date of Birth")]
        public Nullable<System.DateTime> Customer_DOB { get; set; }


        [Required]
        [Display(Name = "Cell Number")]
        [StringLength(13, ErrorMessage = "Number cannot be more than 13 digits")]
        [DataType(DataType.PhoneNumber)]
        public string Customer_Cell { get; set; }
        [Required]
        [Display(Name = "Home Address")]
        public string Customer_Address { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Customer_Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public bool ValidateID()
        {
            string FirstOne = Customer_IdentificationNumber.Substring(0, 1);
            string ElevenDigit = Customer_IdentificationNumber.Substring(10, 1);
            string TwelveDigit = Customer_IdentificationNumber.Substring(11, 1);
            if (FirstOne == "8" || FirstOne == "9" || FirstOne == "0" || FirstOne == "1" || FirstOne == "2")
            {
                if (ElevenDigit == "0" || ElevenDigit == "1")
                {
                    if (TwelveDigit == "8" || TwelveDigit == "9")
                    {

                        return true;
                    }

                }

            }
            return false;

        }

        public bool validateAge()
        {
            string DOB = Convert.ToString(Customer_DOB).Substring(7, 4);
            int DOB2 = Convert.ToInt32(DOB);

            int Current = (Convert.ToInt16(DateTime.Now.Year.ToString()));
            int Age = Current - DOB2;

            if (Age >= 18)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}

    //public class MinimumAgeAttribute : ValidationAttribute
    //{
    //    int MinAge;

    //    public MinimumAgeAttribute(int minAge)
    //    {
    //        MinAge = minAge;
    //    }

    //    public override bool IsValid(object result)
    //    {
    //        DateTime date;
    //        if (DateTime.TryParse(result.ToString(), out date))
    //        {
    //            return date.AddYears(MinAge) < DateTime.Now;
    //        }

    //        return false;
    //    }}

