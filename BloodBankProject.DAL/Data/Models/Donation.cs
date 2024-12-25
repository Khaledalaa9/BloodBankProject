using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        public string BloodType { get; set; }
        public string BloodBankCity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool VirusTestResult { get; set; }

        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        public int BloodStockId { get; set; }
        public BloodStock BloodStock { get; set; }
    }
}
