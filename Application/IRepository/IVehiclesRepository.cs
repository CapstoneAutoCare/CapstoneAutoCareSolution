using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IVehiclesRepository : IGenericRepository<Vehicles>
    {
        Task<Vehicles> GetById(Guid id);
        Task<List<Vehicles>> GetAll();
        Task<List<Vehicles>> GetListByClient(Guid id);

    }
}
