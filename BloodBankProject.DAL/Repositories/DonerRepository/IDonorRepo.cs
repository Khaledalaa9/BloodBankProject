using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.DonerRepository
{
    public interface IDonorRepo
    {
        Donor GetById(int id);
        Donor GetByEmail(string email);
        Donor GetDonorDetailsById(int id);
        void Add(Donor donor);
        Donor GetDonorByUserName(string Name);
       
        void Update(Donor donor);
        void Delete(Donor donor);
    }
}
