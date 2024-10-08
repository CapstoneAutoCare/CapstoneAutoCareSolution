﻿using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class VehiclesRepositoryImp : GenericRepositoryImp<Vehicles>, IVehiclesRepository
    {
        public VehiclesRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<Vehicles> CheckLicenseplateExist(string licenseplate)
        {
            var check = await _context.Set<Vehicles>().Include(c => c.Client).Include(c => c.VehicleModel).ThenInclude(c => c.VehiclesBrand)
                .SingleOrDefaultAsync(c => c.LicensePlate.ToUpper().Equals(licenseplate.ToUpper()));
            if (check != null)
            {
                throw new Exception($"Existed Licenseplate {licenseplate}");
            }
            return check;
        }

        public async Task<List<Vehicles>> GetAll()
        {
            return await _context.Set<Vehicles>().Include(c => c.Client).Include(c => c.VehicleModel).ThenInclude(c => c.VehiclesBrand).ToListAsync();
        }

        public async Task<Vehicles> GetById(Guid id)
        {
            var vehicle = await _context.Set<Vehicles>().Include(c => c.Client).Include(c => c.VehicleModel).ThenInclude(c => c.VehiclesBrand).FirstOrDefaultAsync(c => c.VehiclesId == id);
            if (vehicle == null)
            {
                throw new Exception("Not Found");
            }
            return vehicle;
        }

        public async Task<List<Vehicles>> GetListByCenterWhenBuyPackage(Guid centerId)
        {
            return await _context.Set<Vehicles>()
                .Include(c => c.Client)
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand).Where(c => c.MaintenanceVehiclesDetails.Any(c=>c.MaintenanceCenterId==centerId &&c.MaintenanceInformations.Any()))
                .ToListAsync();
        }

        public async Task<List<Vehicles>> GetListByClient(Guid id)
        {
            return await _context.Set<Vehicles>()
                .Include(c => c.Client)
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand).Where(c => c.ClientId == id)
                .ToListAsync();
        }
    }
}
