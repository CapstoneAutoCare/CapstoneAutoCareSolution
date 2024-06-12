using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ITechnicianRepository : IGenericRepository<Technician>
    {
        Task<Technician> GetById(Guid id);
        Task<List<Technician>> GetAll();
    }
}
