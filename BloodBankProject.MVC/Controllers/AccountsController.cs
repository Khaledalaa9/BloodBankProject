using BloodBankProject.BLL.Managers.DonorManager;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using BloodBankProject.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDonorManager _donorManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,IDonorManager donorManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _donorManager = donorManager;
        }

        //Accounts/Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(DonorLoginVM model)
        {
         
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var Password = await _userManager.CheckPasswordAsync(user, model.Password);
                
                    if (Password)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No user found with this email address.");
                }
            }

            return View(model);
        }


        //Accounts/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(DonorRegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName=model.UserName,
                    Email = model.Email,
                    NationalId = model.NationalId,
                    City = model.City,
                    LastDonationDate= model.LastDonationDate,
                };


                var result = await _userManager.CreateAsync(user,model.Password);
            
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Donor"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Donor"));
                    }
                    _donorManager.Add(model);
                    await _userManager.AddToRoleAsync(user, "Donor");
                    await _signInManager.SignInAsync(user, isPersistent:true);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> MyDetails()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Accounts");
            }

            var donor =  _donorManager.GetDonorByUserName(user.UserName);
            if (donor == null)
            {
                return NotFound($"Unable to find donor with username '{user.UserName}'.");
            }

            var model = new DonorReadVM
            {
                Id = donor.Id 
              
            };

            return RedirectToAction("GetById","Donors", model);
        }

        //Accounts/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
