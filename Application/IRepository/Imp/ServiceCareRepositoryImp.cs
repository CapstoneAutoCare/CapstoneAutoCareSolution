using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class ServiceCareRepositoryImp : GenericRepositoryImp<ServiceCare>, IServiceCareRepository
    {
        public ServiceCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Task<List<ServiceCare>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceCare> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
