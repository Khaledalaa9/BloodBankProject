using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.DonerRepository
{
    public class DonorRepo : IDonorRepo
    {
        private readonly BloodBankDBContext _dbContext;

        public DonorRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Donor GetById(int id)
        {
            var donor = _dbContext.Donors.Include(a => a.Donations).FirstOrDefault(d => d.Id == id);
            return donor;
        }

        public void Update(Donor donor)
        {
            _dbContext.SaveChanges();
        }
        public void Delete(Donor donor)
        {
            _dbContext.Remove(donor);
            _dbContext.SaveChanges();
        }

        public Donor GetDonorDetailsById(int id)
        {
            var donor = _dbContext.Donors.FirstOrDefault(d => d.Id == id);
            return donor;
        }

        public void Add(Donor donor)
        {
            _dbContext.Donors.Add(donor);
            _dbContext.SaveChanges();
        }

        public Donor GetDonorByUserName(string Name)
        {
           
           return _dbContext.Donors.FirstOrDefault(d => d.Name == Name);
      
        }

        public Donor GetByEmail(string email)
        {
           return _dbContext.Donors.FirstOrDefault(d => d.Email == email);
        }
    }
}
