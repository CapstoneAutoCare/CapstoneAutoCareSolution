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
    public class VehicleModelRepositoryImp : GenericRepositoryImp<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepositoryImp(AppDBContext context) : base(context)
        {
        }
        public async Task<List<VehicleModel>> GetAll()
        {
            return await _context.Set<VehicleModel>().Include(c => c.VehiclesBrand).ToListAsync();
        }

        public Task<VehicleModel> GetById(Guid id)
        {
            var model = _context.Set<VehicleModel>().Include(a => a.VehiclesBrand).FirstOrDefaultAsync(c => c.VehicleModelId.Equals(id));
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            return model;
        }
    }
}
