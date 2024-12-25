using BloodBankProject.BLL.ViewModels.BloodStockViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.DonorViewModel
{
    public class DonorRegisterWithParentVM
    {
        public string City { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Last Donation Date")]
        public DateTime LastDonationDate { get; set; }
      // public BloodStockAddVM BloodStockAddVM { get; set; }


    }
}
