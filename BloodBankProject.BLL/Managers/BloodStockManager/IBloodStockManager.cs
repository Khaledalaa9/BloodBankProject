using BloodBankProject.BLL.ViewModels.BloodStockViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.BloodStockManager
{
    public interface IBloodStockManager
    {
        IEnumerable<BloodStockReadVM> GetAll();
    }
}
