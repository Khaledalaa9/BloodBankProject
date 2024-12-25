using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.RequestRepository
{
    public class RequestRepo : IRequestRepo
    {
        private readonly BloodBankDBContext _dbContext;

        public RequestRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Request> GetAll()
        {
            return _dbContext.Requests.Include(a=>a.Hospital);
        }

        public void Add(Request request)
        {
            _dbContext.Requests.Add(request);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BloodStock> GetAvailableBlood(string bloodType, string city)
        {
            return _dbContext.BloodStocks
           .Where(b => b.BloodType == bloodType && b.BloodBankCity == city && b.AvailableQuantity > 0)
           .ToList();
        }

        public int GetTotalRequestsFromAllHospitals()
        {
            return _dbContext.Requests.Count();
        }

        public void ClearRequests()
        {
            
                var Requests = _dbContext.Requests.ToList();
                _dbContext.Requests.RemoveRange(Requests);
                _dbContext.SaveChanges();
           
        }
    }
}
