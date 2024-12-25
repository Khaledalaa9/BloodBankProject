using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Repositories.DonerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.DonorManager
{
    public class DonorManager : IDonorManager
    {
        private readonly IDonorRepo _donorRepo;

        public DonorManager(IDonorRepo donorRepo)
        {
            _donorRepo = donorRepo;
        }

        public DonorReadVM GetById(int Id)
        {
            var DonorModel= _donorRepo.GetById(Id);
            DonorReadVM donorReadVM = new DonorReadVM
            {
                Id = Id,
                Email = DonorModel.Email,
                City = DonorModel.City,
                Name = DonorModel.Name,
                NationalId = DonorModel.NationalId,
                LastDonationDate = DonorModel.LastDonationDate,

                DonationReadVM = DonorModel.Donations.Select(Donation => new DonationReadVM
                {
                    BloodBankCity = Donation.BloodBankCity,
                    BloodType = Donation.BloodType,
                    DonationDate = Donation.DonationDate,
                    VirusTestResult = Donation.VirusTestResult,
                }).ToList()
            };
            return donorReadVM;
        }

        public DonorReadVM GetDonorDetailsById(int Id)
        {
            var DonorModel = _donorRepo.GetById(Id);
            DonorReadVM donorReadVM = new DonorReadVM
            {
                Id = Id,
                Email = DonorModel.Email,
                City = DonorModel.City,
                Name = DonorModel.Name,
                NationalId = DonorModel.NationalId,
                LastDonationDate = DonorModel.LastDonationDate,

            };
            return donorReadVM;
        }

        //public void Delete(int Id)
        //{
        //    var DonorModel = _donorRepo.GetById(Id);
        //    _donorRepo.Delete(DonorModel);
        //}

        public void Add(DonorRegisterVM donorRegisterVM)
        {
            Donor donor = new Donor
            {
                Name=donorRegisterVM.UserName,
                Email=donorRegisterVM.Email,
                NationalId=donorRegisterVM.NationalId,
                City=donorRegisterVM.City,
                LastDonationDate=donorRegisterVM.LastDonationDate,
            };
            _donorRepo.Add(donor);

        }

        public Donor GetDonorByUserName(string Name)
        {
            
           return _donorRepo.GetDonorByUserName(Name);

        }
    }
}
