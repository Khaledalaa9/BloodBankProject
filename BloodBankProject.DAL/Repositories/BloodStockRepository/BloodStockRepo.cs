using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.BloodStockRepository
{
    public class BloodStockRepo : IBloodStockRepo
    {
        private readonly BloodBankDBContext _dbContext;
        public BloodStockRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(BloodStock bloodStock)
        {
            _dbContext.BloodStocks.Add(bloodStock);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BloodStock> GetAll()
        {
           return _dbContext.BloodStocks.ToList();
        }

        public BloodStock GetByBloodTypeAndCity(string bloodType, string city)
        {
            return _dbContext.BloodStocks
           .FirstOrDefault(bs => bs.BloodType == bloodType && bs.BloodBankCity == city);
        }

        public void Update(BloodStock bloodStock)
        {
            _dbContext.SaveChanges();
        }
    }
}
