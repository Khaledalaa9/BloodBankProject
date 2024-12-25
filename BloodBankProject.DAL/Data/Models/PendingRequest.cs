using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class PendingRequest
    {
        public int Id { get; set; } 

        public string BloodType { get; set; } 

        public string City { get; set; } 

        public string PatientStatus { get; set; } 

        public int QuantityRequested { get; set; } 

        public DateTime RequestDate { get; set; } = DateTime.Now; 

        public string Status { get; set; } = "Pending";

        public int HospitalId { get; set; }
    }
}
