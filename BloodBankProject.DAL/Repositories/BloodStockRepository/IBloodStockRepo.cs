using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.BloodStockRepository
{
    public interface IBloodStockRepo
    {
       IEnumerable <BloodStock> GetAll();
        BloodStock GetByBloodTypeAndCity(string bloodType, string city);
        void Add(BloodStock bloodStock);
        void Update(BloodStock bloodStock);
    }
}
