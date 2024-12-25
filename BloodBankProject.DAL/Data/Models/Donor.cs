using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime LastDonationDate { get; set; }

        public ICollection<Donation> Donations { get; set; } = new HashSet<Donation>();

    }
}
