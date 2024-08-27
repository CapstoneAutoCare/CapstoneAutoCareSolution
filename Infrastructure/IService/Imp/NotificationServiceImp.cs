using AutoMapper;
using Infrastructure.Common.Response;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class NotificationServiceImp : INotificationSerivce
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;

        public NotificationServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<List<ResponseNotification>> GetAll()
        {
            return _mapper.Map<List<ResponseNotification>>(await _unitOfWork.NotificationRepository.GetAll());
        }

        public async Task<List<ResponseNotification>> GetListbyAccount(Guid id)
        {
            return _mapper.Map<List<ResponseNotification>>(await _unitOfWork.NotificationRepository.GetListbyAccount(id));
        }

        public async Task<ResponseNotification> UpdateRead(Guid id)
        {
            var n = await _unitOfWork.NotificationRepository.GetById(id);
            n.IsRead = true;
            n.ReadDate = DateTime.Now;
            await _unitOfWork.NotificationRepository.Update(n);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseNotification>(n);
        }
    }
}
