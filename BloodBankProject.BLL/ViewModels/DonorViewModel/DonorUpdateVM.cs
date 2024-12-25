using BloodBankProject.BLL.ViewModels.DonationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.DonorViewModel
{
    public class DonorUpdateVM
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime LastDonationDate { get; set; }


        //public ICollection <DonationUpdateVM> DonationUpdateVM { get; set; }
    }
}
