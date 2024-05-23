﻿using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Response.ResponseVehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehiclesService
    {
        Task<List<ResponseVehicles>> GetAll();
        Task<ResponseVehicles> Create(CreateVehicle create);
        Task<ResponseVehicles> GetById(Guid id);
    }
}
