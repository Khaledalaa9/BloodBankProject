using BloodBankProject.BLL.Managers.HospitalManager;
using BloodBankProject.BLL.Managers.RequestManager;
using BloodBankProject.BLL.ViewModels.HospitalViewModels;
using BloodBankProject.BLL.ViewModels.RequestViewModels;
using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Repositories.HospitalRepository;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.MVC.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestManager _requestManager;
        private readonly IHospitalRepo _hospitalRepo;

        public RequestController(IRequestManager requestManager,IHospitalRepo hospitalRepo)
        {
              _requestManager = requestManager;
            _hospitalRepo = hospitalRepo;
        }
        //Request/GetAll
        public IActionResult GetAll()
        {
          
            var AllRequests = _requestManager.GetAll();
            return View(AllRequests);
        }

       //Request/Add
        public IActionResult Add()
        {
            var model = new RequestAddVM
            {
                HospitalReadVMs = _hospitalRepo.GetAll().Select(h => new HospitalReadVM
                {
                    Id = h.Id,
                    Name = h.Name,
                    City = h.City
                })
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(RequestAddVM requestAddVM)
        {
            if (!ModelState.IsValid)
            {
                return View(requestAddVM);
            }

            _requestManager.Add(requestAddVM);

           
            var availableBlood = _requestManager.GetAvailableBlood(requestAddVM);


            //BloodStocks/GetAll
            return RedirectToAction("GetAll", "BloodStocks");
           
        }
    }
}
