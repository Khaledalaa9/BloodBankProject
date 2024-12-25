using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Validation
{
   
    public class DonationDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime donationDate)
            {
                if (donationDate <= DateTime.Today)
                {
                    return new ValidationResult("Donation date must be at least one day after today.");
                }
            }

            return ValidationResult.Success;
        }
    }


}
