﻿using BloodBankProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProject.DAL.Repositories.DonationRepository
{
    public interface IDonationRepo
    {
        void Add(Donation donation);

    }
}
