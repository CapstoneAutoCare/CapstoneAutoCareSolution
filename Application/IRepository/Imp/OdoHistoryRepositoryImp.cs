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
    public class OdoHistoryRepositoryImp : GenericRepositoryImp<OdoHistory>, IOdoHistoryRepository
    {
        public OdoHistoryRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<OdoHistory>> GetAll()
        {
            return await _context.Set<OdoHistory>().Include(c => c.MaintenanceInformation).ToListAsync();
        }

        public async Task<OdoHistory> GetById(Guid id)
        {
            var odo = await _context.Set<OdoHistory>().Include(c => c.MaintenanceInformation).FirstOrDefaultAsync(c => c.OdoHistoryId == id);
            if (odo == null)
            {
                throw new Exception("not found");

            }
            return odo;
        }

        public async Task<OdoHistory> GetByInforId(Guid inforId)
        {
            var odo = await _context.Set<OdoHistory>().Include(c => c.MaintenanceInformation).FirstOrDefaultAsync(c => c.MaintenanceInformationId == inforId);
            if (odo == null)
            {
                throw new Exception("not found");

            }
            return odo;
        }
    }
}
