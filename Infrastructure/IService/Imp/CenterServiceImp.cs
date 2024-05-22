using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseCenter;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class CenterServiceImp : ICenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CenterServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseCenter> Create(CreateCenter create)
        {
            var centre = _mapper.Map<MaintenanceCenter>(create);
            centre.Account.CreatedDate = DateTime.Now;
            centre.Account.Status = "INACTIVE";
            centre.Account.Role = "CENTER";
            centre.Rating = 5;
            await _unitOfWork.MaintenanceCenter.Add(centre);
            await _unitOfWork.Account.Add(centre.Account);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseCenter>(centre);
        }

        public async Task<List<ResponseCenter>> GetAll()
        {
            return _mapper.Map<List<ResponseCenter>>(await _unitOfWork.MaintenanceCenter.GetAll());
        }

        public async Task<ResponseCenter> GetById(Guid id)
        {
            return _mapper.Map<ResponseCenter>(await _unitOfWork.MaintenanceCenter.GetById(id));
        }
    }
}
