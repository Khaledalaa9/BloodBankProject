using BloodBankProject.BLL.ViewModels.HospitalViewModels;
using BloodBankProject.DAL.Repositories.HospitalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.HospitalManager
{
    public class HospitalManager: IHospitalManager
    {
        private readonly IHospitalRepo _hospitalRepo;

        public HospitalManager(IHospitalRepo hospitalRepo)
        {
            _hospitalRepo = hospitalRepo;
        }

        public IEnumerable<HospitalReadVM> GetAll()
        {
            var HospitalModelList = _hospitalRepo.GetAll();

            var HospitalReadVMList = HospitalModelList.Select(a => new HospitalReadVM
            {
                Id = a.Id,
                Name = a.Name,
                City = a.City
            });
            return HospitalReadVMList;
        }
    }
}
