using BloodBankProject.BLL.Managers.BloodStockManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankProject.MVC.Controllers
{
    
    public class BloodStocksController : Controller
    {
        private readonly IBloodStockManager _bloodStockManager;

        public BloodStocksController(IBloodStockManager bloodStockManager)
        {
            _bloodStockManager = bloodStockManager;
        }
        //BloodStocks/GetAll
        public IActionResult GetAll()
        {
            var AllBloodStocks = _bloodStockManager.GetAll();
            return View(AllBloodStocks);
        }
    }
}
