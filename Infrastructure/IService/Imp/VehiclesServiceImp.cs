using AutoMapper;
using Azure;
using Domain.Entities;
using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.VehiclesResponse;
using Infrastructure.Hubs;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class VehiclesServiceImp : IVehiclesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;
        private readonly IHubContext<VehicleHub> _hubContext;

        public VehiclesServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler, IHubContext<VehicleHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _hubContext = hubContext;
        }

        public async Task<ResponseVehicles> Create(CreateVehicle create)
        {
            var email = _tokenHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var vehicles = _mapper.Map<Vehicles>(create);
            await _unitOfWork.VehicleModel.GetById(vehicles.VehicleModelId);
            vehicles.ClientId = account.Client.ClientId;
            vehicles.Status = "ACTIVE";
            vehicles.CreatedDate = DateTime.Now;
            var check = ValidateLicensePlate(vehicles.LicensePlate);
            await _unitOfWork.Vehicles.CheckLicenseplateExist(vehicles.LicensePlate);
            if (check == true)
            {
                await _unitOfWork.Vehicles.Add(vehicles);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseVehicles>(vehicles);
            }
            else
            {
                throw new Exception("LicensePlate does not match  format( 54A 333.12)");
            }
        }
        private static bool ValidateLicensePlate(string licensePlate)
        {
            string pattern = @"^[0-9]{2}[A-Z] [0-9]{3}\.[0-9]{2}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(licensePlate);
        }
        public async Task<List<ResponseVehicles>> GetAll()
        {
            return _mapper.Map<List<ResponseVehicles>>(await _unitOfWork.Vehicles.GetAll());
        }

        public async Task<ResponseVehicles> GetById(Guid id)
        {
            return _mapper.Map<ResponseVehicles>(await _unitOfWork.Vehicles.GetById(id));
        }

        public async Task<List<ResponseVehicles>> GetListByClient()
        {
            var email = _tokenHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseVehicles>>(
                await _unitOfWork.Vehicles.GetListByClient(account.Client.ClientId));
        }

        public async Task<ResponseVehicles> UpdateStatus(Guid id, string status)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(id);
            vehicle.Status = status;
            await _unitOfWork.Vehicles.Update(vehicle);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseVehicles>(vehicle);
        }

        public async Task<ResponseVehicles> Update(Guid id, UpdateVehicle updateVehicle)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(id);
            var previousOdo = vehicle.Odo;

            var update = _mapper.Map(updateVehicle, vehicle);
            await _unitOfWork.Vehicles.Update(vehicle);
            await _unitOfWork.Commit();

            if (update.Odo != previousOdo)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveOdoUpdate", update.VehiclesId, update.Odo);
            }

            var response = _mapper.Map<ResponseVehicles>(update);
            return response;
        }

        public async Task<List<ResponseVehicles>> GetListByCenterWhenBuyPackage(Guid centerId)
        {
            return _mapper.Map<List<ResponseVehicles>>(
                            await _unitOfWork.Vehicles.GetListByCenterWhenBuyPackage(centerId));
        }
    }
}
