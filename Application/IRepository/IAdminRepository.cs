using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin> GetById(Guid id);
        Task<Admin> GetByEmail(string  email);
        Task<List<Admin>> GetAll();


    }
}
