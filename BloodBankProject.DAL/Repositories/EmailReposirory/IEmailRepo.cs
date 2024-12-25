using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.EmailReposirory
{
    public interface IEmailRepo
    {
        Task SendEmailAsync(string email, string subject, string message);

    }
}
