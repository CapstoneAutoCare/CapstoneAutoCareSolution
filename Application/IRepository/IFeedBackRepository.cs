using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IFeedBackRepository: IGenericRepository<FeedBack>
    {
        Task<List<FeedBack>> GetAll();
        Task<FeedBack> GetById(Guid id);
        Task<List<FeedBack>> GetListByCenter(Guid center);
    }
}
