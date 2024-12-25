using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string PatientStatus { get; set; } // Immediate, Urgent, Normal
        public int QuantityRequested { get; set; }



        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public int? BloodStockId { get; set; }
        public BloodStock BloodStock { get; set; }

    }
}
