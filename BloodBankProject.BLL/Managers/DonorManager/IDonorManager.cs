using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.DonorManager
{
    public interface IDonorManager
    {
        DonorReadVM GetById(int Id);
        DonorReadVM GetDonorDetailsById(int Id);

        Donor GetDonorByUserName(string Name);


        void Add(DonorRegisterVM donorRegisterVM);

        //void Delete(int Id);
    }
}
