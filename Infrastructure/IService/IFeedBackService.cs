using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.RequestFb;
using Infrastructure.Common.Response.ResponseFb;
using Infrastructure.Common.Response.ResponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IFeedBackService
    {
        Task<List<ResponseFeedback>> GetAll();
        Task<ResponseFeedback> GetById(Guid id);
        Task<ResponseFeedback> Create(CreateFeedBack create);
        Task<List<ResponseFeedback>> GetListByCenterId(Guid id);
        Task<List<ResponseFeedback>> GetListByCenter();
        Task<ResponseFeedback> Update(Guid id, UpdateFeedback update);
        Task Remove(Guid id);

    }
}
