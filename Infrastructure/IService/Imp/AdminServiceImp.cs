﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseAdmin;
using Infrastructure.ISecurity;
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
        private readonly ITokensHandler _tokensHandler;

        public AdminServiceImp(IUnitOfWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseAdmin> ChangeStatusAdmin(Guid adminId, string status)
        {
            var admin = await _unitofWork.Admin.GetById(adminId);
            admin.Account.Status = status;
            await _unitofWork.Account.Update(admin.Account);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseAdmin>(admin);

        }

        public async Task<ResponseAdmin> CreateAdmin(CreateAdmin create)
        {
            var admin = _mapper.Map<Admin>(create);
            admin.Account.CreatedDate = DateTime.Now;
            admin.Account.Status = "ACTIVE";
            admin.Account.Role = "ADMIN";
            await _unitofWork.Account.CheckExistEmail(admin.Account.Email);
            await _unitofWork.Account.CheckPhone(admin.Account.Phone);
            await _unitofWork.Admin.Add(admin);
            await _unitofWork.Account.Add(admin.Account);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseAdmin>(admin);
        }

        public async Task<ResponseAdmin> GetByEmail()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var admin = await _unitofWork.Admin.GetByEmail(email);
            return _mapper.Map<ResponseAdmin>(admin);
        }

        public async Task<ResponseAdmin> GetById(Guid id)
        {
            var admin = await _unitofWork.Admin.GetById(id);
            return _mapper.Map<ResponseAdmin>(admin);
        }

        public async Task<ResponseAdmin> UpdateAdmin(Guid adminId, UpdateAdmin update)
        {
            var admin = await _unitofWork.Admin.GetById(adminId);
            admin.Account.Phone = update.Phone;
            admin.Account.Gender = update.Gender;
            admin.Account.Logo = update.Logo;
            await _unitofWork.Account.Update(admin.Account);

            await _unitofWork.Commit();

            return _mapper.Map<ResponseAdmin>(admin);
        }
    }
}
