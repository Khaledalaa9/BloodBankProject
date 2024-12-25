using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.BLL.ViewModels.BloodStockViewModel
{
    public class BloodStockReadVM
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string BloodBankCity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
