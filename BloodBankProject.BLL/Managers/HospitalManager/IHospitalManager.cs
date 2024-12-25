using BloodBankProject.BLL.ViewModels.HospitalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.HospitalManager
{
    public interface IHospitalManager
    {
        IEnumerable<HospitalReadVM> GetAll();
    }
}
