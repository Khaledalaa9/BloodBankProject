using BloodBankProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Data
{
    public class BloodBankDBContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PendingRequest> PendingRequests { get; set; }

        public BloodBankDBContext(DbContextOptions<BloodBankDBContext> options):base(options)
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
