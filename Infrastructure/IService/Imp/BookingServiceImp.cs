using AutoMapper;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class BookingServiceImp : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public BookingServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public Task<ResponseBooking> Create(RequestBooking create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseBooking>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBooking> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
