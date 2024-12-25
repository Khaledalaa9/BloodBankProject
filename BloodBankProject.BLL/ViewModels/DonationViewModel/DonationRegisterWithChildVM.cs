using BloodBankProject.BLL.ViewModels.BloodStockViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.DonationViewModel
{
    public class DonationRegisterWithChildVM
    {

        public int Id { get; set; }

        public string BloodType { get; set; }

        public string BloodBankCity { get; set; }

       
        [DataType(DataType.Date)]
        [Display(Name = "Donation Date")]
        [DonationDate]
        public DateTime DonationDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public bool VirusTestResult { get; set; }

      public  DonorRegisterWithParentVM DonorRegisterWithParentVM { get; set; }
      public BloodStockAddVM BloodStockAddVM { get; set; }

    }

}
