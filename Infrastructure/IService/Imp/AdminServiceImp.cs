﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class AdminServiceImp : IAdminService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public AdminServiceImp(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<Admin> CreateAdmin(CreateAdmin create)
        {
            var admin = _mapper.Map<Admin>(create);
            admin.Account.CreatedDate = DateTime.Now;
            admin.Account.Status = "ACTIVE";
            admin.Account.Role = "ADMIN";
            await _unitofWork.Admin.Add(admin);
            await _unitofWork.Account.Add(admin.Account);

            await _unitofWork.Commit();
            return admin;
        }
    }
}
