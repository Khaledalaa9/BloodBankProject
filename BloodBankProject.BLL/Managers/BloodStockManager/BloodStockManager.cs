using BloodBankProject.BLL.ViewModels.BloodStockViewModel;
using BloodBankProject.DAL.Repositories.BloodStockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.BloodStockManager
{
    public class BloodStockManager:IBloodStockManager
    {
        private readonly IBloodStockRepo _bloodStockRepo;

        public BloodStockManager(IBloodStockRepo bloodStockRepo)
        {
            _bloodStockRepo = bloodStockRepo;
        }

        public IEnumerable<BloodStockReadVM> GetAll()
        {
            var BloodStockModel=_bloodStockRepo.GetAll();
            var BloodStockReadVM = BloodStockModel.Select(x => new BloodStockReadVM
            {
                Id = x.Id,
                BloodType = x.BloodType,
                ExpirationDate = x.ExpirationDate,
                AvailableQuantity = x.AvailableQuantity,
                BloodBankCity = x.BloodBankCity
            });
            return BloodStockReadVM;


        }
    }
}
