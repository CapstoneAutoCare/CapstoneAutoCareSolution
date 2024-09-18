using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Payment;
using Infrastructure.Common.Response;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class TransactionServiceImp : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;

        public TransactionServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<ResponseTransaction> Create(CreatePaymentTransaction transaction)
        {
            var mc = await _unitOfWork.MaintenanceCenter.GetById((transaction.MaintenanceCenterId));
            var plan = await _unitOfWork.MaintenancePlanRepository.GetById(transaction.MaintenancePlanId);
            var vehicle = await _unitOfWork.Vehicles.GetById(transaction.VehiclesId);
            var listT = await _unitOfWork.MaintenanceService.GetListPackageOdoTRUEByCenterIdAndModelIdAndPlanId(mc.MaintenanceCenterId, vehicle.VehicleModelId, plan.MaintenancePlanId);
            float amount = 0;
            foreach (var item in listT)
            {
                var cost = await _unitOfWork.MaintenanceServiceCost.GetByIdMaintenanceServiceActiveAndServiceAdmin
                    (EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), item.MaintenanceServiceId);

                amount += cost.ActuralCost;

            }

            Transactions transactions = new Transactions
            {
                Amount = amount * 90 / 100F,
                Description = "Đã chuyền tiền từ admin " + vehicle.LicensePlate + " - Mua gói " + plan.MaintenancePlanName + " Số tiền " + amount,
                MaintenanceCenterId = mc.MaintenanceCenterId,
                MaintenancePlanId = plan.MaintenancePlanId,
                PaymentMethod = "VNPAY",
                Status = "TRANSFERRED",
                TransactionsId = Guid.NewGuid(),
                TransactionDate = DateTime.Now,
                VehiclesId = vehicle.VehiclesId,
                Volume = 90,

            };
            await _unitOfWork.TransactionRepository.Add(transactions);




            await _unitOfWork.Commit();
            return _mapper.Map<ResponseTransaction>(transactions);
        }

        public async Task<List<ResponseTransaction>> GetAll()
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetAll());
        }

        public async Task<ResponseTransaction> GetById(Guid id)
        {
            return _mapper.Map<ResponseTransaction>(await _unitOfWork.TransactionRepository.GetById(id));
        }


        public async Task<List<ResponseTransaction>> GetListByCenterAndStatusTransferred(Guid id)
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetListByCenterIdAndStatusTransferred(id));
        }

        public async Task<List<ResponseTransaction>> GetListByClientRECEIVED(Guid id)
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetListByClientRECEIVED(id));
        }
    }
}
