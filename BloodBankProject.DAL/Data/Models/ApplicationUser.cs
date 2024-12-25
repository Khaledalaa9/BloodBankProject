using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NationalId { get; set; }
        public string City { get; set; }
        public DateTime LastDonationDate { get; set; }

    }
}
