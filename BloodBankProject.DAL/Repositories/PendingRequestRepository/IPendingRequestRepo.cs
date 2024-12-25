using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.PendingRequestRepository
{
    public interface IPendingRequestRepo
    {
        IEnumerable<PendingRequest> GetPendingRequests();
        void ClearPendingRequests();
        void SavePendingRequest(PendingRequest pendingRequest);
    }
}
