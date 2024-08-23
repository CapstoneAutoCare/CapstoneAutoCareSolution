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
    public class VehicleModelRepositoryImp : GenericRepositoryImp<VehicleModel>, IVehicleModelRepository
    {
        public VehicleModelRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<VehicleModel> CheckExist(string name)
        {
            var model = await _context.Set<VehicleModel>().Include(a => a.VehiclesBrand).FirstOrDefaultAsync(c => c.VehicleModelName.ToLower().Equals(name.ToLower()));
            if (model != null)
            {
                throw new Exception("Không được trùng tên xe");
            }
            return model;
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

        public async Task<List<VehicleModel>> GetListActiveByBrandId(Guid brandId)
        {
            var model = await _context.Set<VehicleModel>()
                .Include(a => a.VehiclesBrand)
                .Where(c => c.VehiclesBrandId.Equals(brandId) && c.Status.Equals(EnumStatus.ACTIVE.ToString())).ToListAsync();
            return model;

        }

        public async Task<List<VehicleModel>> GetListByBrandId(Guid brandId)
        {
            var model = await _context.Set<VehicleModel>()
                .Include(a => a.VehiclesBrand)
                .Where(c => c.VehiclesBrandId.Equals(brandId)).ToListAsync();
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            return model;
        }
    }
}
