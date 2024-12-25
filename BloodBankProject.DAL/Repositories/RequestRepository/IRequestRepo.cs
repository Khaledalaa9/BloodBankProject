using BloodBankProject.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.RequestRepository
{
    public interface IRequestRepo
    {
        IEnumerable<Request> GetAll();
        IEnumerable<BloodStock> GetAvailableBlood(string bloodType, string city);
        void Add(Request request);
        int GetTotalRequestsFromAllHospitals();

        void ClearRequests();
       

    }
}
