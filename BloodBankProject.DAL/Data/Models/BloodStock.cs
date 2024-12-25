using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class BloodStock
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string BloodBankCity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int AvailableQuantity { get; set; }



        public ICollection<Donation> Donations { get; set; }=new HashSet<Donation>();
        public ICollection<Request> Requests { get; set; }=new HashSet<Request>();
    }
}
