using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.PendingRequestRepository
{
    public class PendingRequestRepo:IPendingRequestRepo
    {
        private readonly BloodBankDBContext _dbContext;

        public PendingRequestRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void ClearPendingRequests()
        {
            var pendingRequests = _dbContext.PendingRequests.ToList();
            _dbContext.PendingRequests.RemoveRange(pendingRequests);
            _dbContext.SaveChanges(); 
        }
        public IEnumerable<PendingRequest> GetPendingRequests()
        {
            return _dbContext.PendingRequests;
        }
        public void SavePendingRequest(PendingRequest pendingRequest)
        {
            _dbContext.PendingRequests.Add(pendingRequest);
            _dbContext.SaveChanges();
        }
    }
}
