using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.DonationViewModel
{
    public class DonationReadVM
    {
        public DateTime DonationDate { get; set; }
        public string BloodType { get; set; }
        public string BloodBankCity { get; set; }
        public bool VirusTestResult { get; set; }

    }
}
