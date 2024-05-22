using Application.IGenericRepository.Imp;
using Domain.Entities;
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
            return await _context.Set<VehiclesBrand>().ToListAsync();
        }

        public Task<VehiclesBrand> GetById(Guid id)
        {
            var brand = _context.Set<VehiclesBrand>().FirstOrDefaultAsync(c => c.VehiclesBrandId.Equals(id));
            if (brand == null)
            {
                throw new Exception("Not Found");
            }
            return brand;
        }
        public Task<VehiclesBrand> GetBrandbyName(string brandName)
        {
            var brand = _context.Set<VehiclesBrand>().FirstOrDefaultAsync(c => c.VehiclesBrandName.Equals(brandName));
            if (brand != null)
            {
                throw new Exception("Not Found");
            }
            return null;
        }
    }
}
