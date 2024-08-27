using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class VehiclesBrandRepositoryImp : GenericRepositoryImp<VehiclesBrand>, IVehiclesBrandRepository
    {
        public VehiclesBrandRepositoryImp(AppDBContext context) : base(context)
        {
        }
        public async Task<List<VehiclesBrand>> GetAll()
        {
            return await _context.Set<VehiclesBrand>()
                //.Include(c=>c.VehiclesMaintenance)
                //.Include(c=>c.VehicleModels)
                .ToListAsync();
        }

        public Task<VehiclesBrand> GetById(Guid id)
        {
            var brand = _context.Set<VehiclesBrand>()
                //.Include(c => c.VehiclesMaintenance)
                //.Include(c => c.VehicleModels)
                .FirstOrDefaultAsync(c => c.VehiclesBrandId.Equals(id));
            if (brand == null)
            {
                throw new Exception("Not Found");
            }
            return brand;
        }
        public async Task<VehiclesBrand> GetBrandbyName(string brandName)
        {
            var brand = await _context.Set<VehiclesBrand>()
                //.Include(c => c.VehiclesMaintenance)
                //.Include(c => c.VehicleModels)
                .FirstOrDefaultAsync(c => c.VehiclesBrandName.ToLower().Contains(brandName.ToLower()));
            if (brand != null)
            {
                throw new Exception("Existed");
            }
            return brand;
        }

        public async Task<List<VehiclesBrand>> GetListBrandActive()
        {
            return await _context.Set<VehiclesBrand>()
                //.Include(c=>c.VehiclesMaintenance)
                //.Include(c=>c.VehicleModels)
                .Where(c => c.Status.Equals(EnumStatus.ACTIVE.ToString()))
                .ToListAsync();
        }

        public async Task<List<VehiclesBrand>> GetBrandsNotInCenter(Guid centerId)
        {
            var allBrands = await _context.Set<VehiclesBrand>()
                    .Where(b => b.Status == "ACTIVE")
                    .ToListAsync();

            var brandsInCenter = await _context.Set<VehiclesMaintenance>()
                    .Where(vm => vm.MaintenanceCenterId == centerId)
                    .Select(vm => vm.VehiclesBrand)
                    .Distinct()
                    .ToListAsync();

            var brandsNotInCenter = allBrands
                .Where(b => !brandsInCenter.Any(bc => bc.VehiclesBrandId == b.VehiclesBrandId))
                .ToList();

            return brandsNotInCenter;
        }
    }
}
