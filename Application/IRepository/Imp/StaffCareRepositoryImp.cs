using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class StaffCareRepositoryImp : GenericRepositoryImp<StaffCare>, IStaffCareRepository
    {
        public StaffCareRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
