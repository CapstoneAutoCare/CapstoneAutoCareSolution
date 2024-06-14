using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IInformationMaintenanceRepository: IGenericRepository<MaintenanceInformation>
    {
        Task<MaintenanceInformation> GetById(Guid id);
        Task<List<MaintenanceInformation>> GetAll();
        Task<List<MaintenanceInformation>> GetListByClient(Guid id);

    }
}
