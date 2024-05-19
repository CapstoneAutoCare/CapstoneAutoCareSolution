using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class TechnicianCostRepositoryImp : GenericRepositoryImp<Technician>, ITechnicianRepository
    {
        public TechnicianCostRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
