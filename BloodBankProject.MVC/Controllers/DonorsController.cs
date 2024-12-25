using BloodBankProject.BLL.Managers.DonorManager;
using BloodBankProject.BLL.ViewModels.DonationViewModel;
using BloodBankProject.BLL.ViewModels.DonorViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.MVC.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        private readonly IDonorManager _donorManager;

        public DonorsController(IDonorManager donorManager)
        {
            _donorManager = donorManager;
        }
        //Donors/GetById/1
        [Authorize]
        public IActionResult GetById(int Id)
        {
            var DonorById = _donorManager.GetById(Id);
            if (DonorById == null)
            {
                return NotFound();
            }
            return View(DonorById);
        }
       


    }
}
