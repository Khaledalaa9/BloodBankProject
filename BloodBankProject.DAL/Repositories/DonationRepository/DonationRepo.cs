using BloodBankProject.DAL.Data;
using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.DonationRepository
{
    public class DonationRepo : IDonationRepo
    {
        private readonly BloodBankDBContext _dbContext;

        public DonationRepo(BloodBankDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Donation donation)
        {
            _dbContext.Donations.Add(donation);
            _dbContext.SaveChanges();
        }
    }
}
