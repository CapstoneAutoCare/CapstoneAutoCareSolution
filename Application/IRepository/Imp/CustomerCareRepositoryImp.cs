using Application.IGenericRepository.Imp;
using Domain.Entities;
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
    }
}
