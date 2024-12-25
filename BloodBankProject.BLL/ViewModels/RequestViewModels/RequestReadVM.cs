using BloodBankProject.BLL.ViewModels.HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.RequestViewModels
{
    public class RequestReadVM
    {
        public string BloodType { get; set; }
        public string City { get; set; }
        public string PatientStatus { get; set; } // Immediate, Urgent, Normal
        public int QuantityRequested { get; set; }
        
       public HospitalReadVM hospitalReadVM { get; set; }
    }
}
