using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.DonationManager
{
    public interface IDonationManager
    {
        //void Add(DonationRegisterWithChildVM donationRegisterWithChildVM);
        (bool IsSuccess, string ErrorMessage) Add(DonationRegisterWithChildVM donationRegisterWithChildVM, string donorEmail);

    }
}
