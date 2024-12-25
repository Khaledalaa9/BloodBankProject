using BloodBankProject.BLL.ViewModels.RequestViewModels;
using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.RequestManager
{
    public interface IRequestManager
    {
        IEnumerable<RequestReadVM> GetAll();
        IEnumerable<BloodStock> GetAvailableBlood(RequestAddVM requestAddVM);
        void Add(RequestAddVM requestAddVM);

    }
}
