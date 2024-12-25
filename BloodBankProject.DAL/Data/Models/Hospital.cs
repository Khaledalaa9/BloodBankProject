using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

      
        public ICollection<Request> Requests { get; set; } = new HashSet<Request>();

    }
}
