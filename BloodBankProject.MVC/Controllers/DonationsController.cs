using BloodBankProject.BLL.Managers.DonationManager;
using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Repositories.EmailReposirory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankProject.MVC.Controllers
{
    [Authorize]
    public class DonationsController : Controller
    {
        private readonly IDonationManager _donationManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailRepo _emailRepo;

        public DonationsController(IDonationManager donationManager, UserManager<ApplicationUser> userManager,IEmailRepo emailRepo)
        {
            _donationManager = donationManager;
            _userManager = userManager;
            _emailRepo = emailRepo;
        }


        public async Task<IActionResult> Register()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Accounts"); 
            }


            var donationRegisterVM = new DonationRegisterWithChildVM
            {
                BloodStockAddVM = new BLL.ViewModels.BloodStockViewModel.BloodStockAddVM
                {
                    AvailableQuantity = 1
                },
                DonorRegisterWithParentVM = new DonorRegisterWithParentVM
                {
                    City = user.City,
                    Email = user.Email,
                    LastDonationDate = user.LastDonationDate
                }
            };

            return View(donationRegisterVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(DonationRegisterWithChildVM donationRegisterWithChildVM)
        {
            if (!ModelState.IsValid)
            {
                return View(donationRegisterWithChildVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            
            if (donationRegisterWithChildVM.DonationDate != default(DateTime))
            {
                donationRegisterWithChildVM.ExpirationDate = donationRegisterWithChildVM.DonationDate.AddYears(1);
            }

            
            var result = _donationManager.Add(donationRegisterWithChildVM, user.Email); 

            if (result.IsSuccess)
            {
                TempData["Message"] = "Donation request submitted!";
                return RedirectToAction("MyDetails", "Accounts");
            }
            else
            {
                await _emailRepo.SendEmailAsync(user.Email, "Donation Request Status", result.ErrorMessage);
                TempData["Message"] = "There was a problem with your donation. Please check the form and try again.";

            }

            return View(donationRegisterWithChildVM);
        }

    }
}