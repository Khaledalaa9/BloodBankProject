using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Repositories.BloodStockRepository;
using BloodBankProject.DAL.Repositories.DonationRepository;
using BloodBankProject.DAL.Repositories.DonerRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.Managers.DonationManager
{
    public class DonationManager : IDonationManager
    {
        private readonly IDonationRepo _donationRepo;
        private readonly IDonorRepo _donorRepo;
        private readonly IBloodStockRepo _bloodStockRepo;

        public DonationManager(IDonationRepo donationRepo, IDonorRepo donorRepo,IBloodStockRepo bloodStockRepo)
        {
            _donationRepo = donationRepo;
            _donorRepo = donorRepo;
            _bloodStockRepo = bloodStockRepo;
        }

        public (bool IsSuccess, string ErrorMessage) Add(DonationRegisterWithChildVM donationRegisterWithChildVM, string donorEmail)
        {
            List<string> issues = new List<string>();

            // تحقق من الشروط
            if (donationRegisterWithChildVM.DonationDate <= DateTime.Today)
            {
                issues.Add("Donation date must be at least one day after today.");
            }

            if (donationRegisterWithChildVM.VirusTestResult == true) 
            {
                issues.Add("Cannot donate with a positive virus test result.");
            }

         
            var lastDonationDate = donationRegisterWithChildVM.DonorRegisterWithParentVM.LastDonationDate;
            var timeDifference = donationRegisterWithChildVM.DonationDate - lastDonationDate;

                if (timeDifference.TotalDays < 90) 
                {
                    issues.Add("The time difference between the current donation and the last donation must be more than 3 months.");
                }
            

            if (issues.Count > 0)
            {
                return (false, string.Join("; ", issues)); 
            }

            
            var existingDonor = _donorRepo.GetByEmail(donationRegisterWithChildVM.DonorRegisterWithParentVM.Email);


            if (existingDonor != null)
            {
                BloodStock bloodStock;
                
                var existingBloodStock = _bloodStockRepo.GetByBloodTypeAndCity(donationRegisterWithChildVM.BloodType, donationRegisterWithChildVM.BloodBankCity);

                if (existingBloodStock != null)
                {
                    
                    existingBloodStock.AvailableQuantity += donationRegisterWithChildVM.BloodStockAddVM.AvailableQuantity;
                    existingBloodStock.ExpirationDate = donationRegisterWithChildVM.ExpirationDate;

                    _bloodStockRepo.Update(existingBloodStock);

                    bloodStock = existingBloodStock;
                }
                else
                {
                    bloodStock = new BloodStock
                    {
                        BloodType = donationRegisterWithChildVM.BloodType,
                        BloodBankCity = donationRegisterWithChildVM.BloodBankCity,
                        AvailableQuantity = donationRegisterWithChildVM.BloodStockAddVM.AvailableQuantity,
                        ExpirationDate = donationRegisterWithChildVM.ExpirationDate,
                    };

                    _bloodStockRepo.Add(bloodStock);
                }

               
                Donation donation = new Donation
                {
                    BloodType = donationRegisterWithChildVM.BloodType,
                    BloodBankCity = donationRegisterWithChildVM.BloodBankCity,
                    DonationDate = donationRegisterWithChildVM.DonationDate,
                    ExpirationDate = donationRegisterWithChildVM.ExpirationDate,
                    VirusTestResult = donationRegisterWithChildVM.VirusTestResult,
                    DonorId = existingDonor.Id,
                    BloodStockId= bloodStock.Id
                };

                _donationRepo.Add(donation);

                existingDonor.LastDonationDate = donationRegisterWithChildVM.DonationDate;
                       _donorRepo.Update(existingDonor);

                return (true, string.Empty);
            }
            else
            {
                return (false, "Donor not found.");
            }
        }
    }
}

