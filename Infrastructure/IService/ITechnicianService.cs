﻿using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseStaffCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ITechnicianService
    {
        Task<ResponseTechnician> Create(CreateTechnician create);
        Task<List<ResponseTechnician>> GetAll();
        Task<ResponseTechnician> GetById(Guid id);
    }
}
