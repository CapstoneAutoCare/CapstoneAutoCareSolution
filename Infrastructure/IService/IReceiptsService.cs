using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.Common.Response.ReceiptResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IReceiptsService
    {
        Task<List<ResponseReceipts>> GetAll();
        Task<List<ResponseReceipts>> GetListByCenter();
        Task<ResponseReceipts> GetById(Guid id);
        Task<ResponseReceipts> Create(CreateReceipt receipt);
    }
}
