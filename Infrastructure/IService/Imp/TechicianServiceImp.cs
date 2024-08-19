using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class TechicianServiceImp : ITechnicianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IConfiguration _configuration;
        public TechicianServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _configuration = configuration;
        }

        public async Task<ResponseTechnician> Create(CreateTechnician create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var care = _mapper.Map<Technician>(create);
            var account = await _unitOfWork.Account.Profile(email);
            await _unitOfWork.Account.CheckExistEmail(care.Account.Email);
            await _unitOfWork.Account.CheckPhone(care.Account.Phone);

            care.CenterId = account.MaintenanceCenter.MaintenanceCenterId;
            care.Account.CreatedDate = DateTime.Now;
            care.Account.Status = "ACTIVE";
            care.Account.Role = "TECHNICAN";
            care.TechnicianDescription = "null";
            await _unitOfWork.Account.CheckPhone(care.Account.Phone);
            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (care.Account.Email == adminEmail && care.Account.Password == adminPassword)
            {
                throw new Exception("Không thể tạo tài khoản với thông tin đăng nhập của quản trị viên.");
            }
            await _unitOfWork.Account.Add(care.Account);
            await _unitOfWork.Techician.Add(care);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseTechnician>(care);
        }

        public async Task<List<ResponseTechnician>> GetAll()
        {
            return _mapper.Map<List<ResponseTechnician>>(await _unitOfWork.Techician.GetAll());
        }

        public async Task<ResponseTechnician> GetById(Guid id)
        {
            return _mapper.Map<ResponseTechnician>(await _unitOfWork.Techician.GetById(id));
        }

        public async Task<List<ResponseTechnician>> GetListByCenter(Guid id)
        {
            return _mapper.Map<List<ResponseTechnician>>(await _unitOfWork.Techician.GetListByCenter(id));
        }

        public async Task<ResponseTechnician> Update(Guid id, UpdateTechi center)
        {
            var center1 = await _unitOfWork.Techician.GetById(id);
            var update = _mapper.Map(center, center1);
            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (update.Account.Email == adminEmail && update.Account.Password == adminPassword)
            {
                throw new Exception("Không thể cập nhật tài khoản với thông tin đăng nhập của quản trị viên.");
            }
            if (center.Phone != center1.Account.Phone)
            {
                await _unitOfWork.Account.CheckPhone(center.Phone);
            }
            update.Account.Phone = center.Phone;
            update.Account.Logo = center.Logo;
            await _unitOfWork.Techician.Update(update);
            await _unitOfWork.Account.Update(update.Account);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseTechnician>(update);
        }
    }
}
