using Infrastructure.Common.Request;
using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IPackageCenterService
    {
        Task<List<ResponseCenterPackage>> GetAll();
        Task<ResponseCenterPackage> GetById(Guid id);
        Task<List<ResponseCenterPackage>> GetListByCenterId (Guid id);
        Task<string> Create(CreateCenterPackage createCenterPackage);
    }
}
