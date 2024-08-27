using Infrastructure.Common.Request;
using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IPackageService
    {
        Task<ResponsePackage> Create (CreatePackage createPackage);
        Task<List<ResponsePackage>> GetAll();
        Task<ResponsePackage> GetById(Guid id);
    }
}
