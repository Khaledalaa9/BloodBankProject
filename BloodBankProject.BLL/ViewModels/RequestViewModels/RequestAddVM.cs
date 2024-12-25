using BloodBankProject.BLL.ViewModels.HospitalViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.RequestViewModels
{
    public class RequestAddVM
    {
        public string BloodType { get; set; }
        public string City { get; set; }

        [RegularExpression("Immediate|Urgent|Normal", ErrorMessage = "Patient status must be either 'Immediate', 'Urgent', or 'Normal'.")]
        public string PatientStatus { get; set; } // Immediate, Urgent, Normal
        [Range(1, 100, ErrorMessage = "Quantity must be a positive number.")]
        public int QuantityRequested { get; set; }
        public int HospitalId { get; set; }
        public IEnumerable<HospitalReadVM>? HospitalReadVMs { get; set; }
    }
}
