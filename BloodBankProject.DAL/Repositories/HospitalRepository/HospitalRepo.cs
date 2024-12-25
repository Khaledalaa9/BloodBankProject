using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.HospitalRepository
{
    public class HospitalRepo:IHospitalRepo
    {
        private readonly BloodBankDBContext _dbContext;

        public HospitalRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Hospital> GetAll()
        {
            return _dbContext.Hospitals.ToList();
        }
    }
}
