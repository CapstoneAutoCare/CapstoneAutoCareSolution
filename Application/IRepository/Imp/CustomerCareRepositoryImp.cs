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
    public class CustomerCareRepositoryImp : GenericRepositoryImp<CustomerCare>, ICustomerCareRepository
    {
        public CustomerCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<CustomerCare>> GetAll()
        {
            return await _context.Set<CustomerCare>().Include(c => c.Account).Include(c => c.MaintenanceCenter).ToListAsync();
        }

        public async Task<List<CustomerCare>> GetListByCenter(Guid id)
        {
            return await _context.Set<CustomerCare>()
                .Include(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .Where(c => c.CenterId == id).ToListAsync();
        }

        public async Task<CustomerCare> GetById(Guid id)
        {
            var customercare = await _context.Set<CustomerCare>()
                .Include(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .FirstOrDefaultAsync(c => c.CustomerCareId == id);
            if (customercare == null)
            {
                throw new Exception("Not Found");

            }
            return customercare;
        }
    }
}
