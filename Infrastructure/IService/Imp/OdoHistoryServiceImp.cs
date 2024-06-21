using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestOdo;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class OdoHistoryServiceImp : IOdoHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OdoHistoryServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseOdoHistory> Create(CreateOdoHistory create)
        {
            var odo = _mapper.Map<OdoHistory>(create);
            odo.OdoHistoryName = create.Odo.ToString();
            odo.CreatedDate = DateTime.Now;
            odo.Status = EnumStatus.ACTIVE.ToString();
            await _unitOfWork.Vehicles.GetById(odo.VehiclesId);
            await _unitOfWork.InformationMaintenance.GetById(odo.MaintenanceInformationId);
            await _unitOfWork.OdoHistory.Add(odo);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseOdoHistory>(odo);
        }

        public async Task<List<ResponseOdoHistory>> GetAll()
        {
            return _mapper.Map<List<ResponseOdoHistory>>(await _unitOfWork.OdoHistory.GetAll());
        }

        public async Task<ResponseOdoHistory> GetById(Guid id)
        {
            return _mapper.Map<ResponseOdoHistory>(await _unitOfWork.OdoHistory.GetById(id));
        }

        public async Task<ResponseOdoHistory> Update(Guid id, UpdateOdo updateOdo)
        {

            var odo = await _unitOfWork.OdoHistory.GetById(id);
            var update = _mapper.Map(updateOdo, odo);
            await _unitOfWork.OdoHistory.Update(update);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseOdoHistory>(update);
        }
    }
}
