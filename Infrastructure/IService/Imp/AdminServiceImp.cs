using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseAdmin;
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
            await _unitofWork.Admin.Add(admin);
            await _unitofWork.Account.Add(admin.Account);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseAdmin>(admin);
        }

        public async Task<ResponseAdmin> GetById(Guid adminId)
        {
            return _mapper.Map<ResponseAdmin>(await _unitofWork.Admin.GetById(adminId));
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
