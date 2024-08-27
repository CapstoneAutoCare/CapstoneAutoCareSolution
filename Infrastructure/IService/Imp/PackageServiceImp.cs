using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request;
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
    public class PackageServiceImp :IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;

        public PackageServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<ResponsePackage> Create(CreatePackage createPackage)
        {
            var r = _mapper.Map<Package>(createPackage);
            r.DateTime= DateTime.Now;
            await _unitOfWork.PackageRepository.Add(r);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponsePackage>(r);
        }

        public async Task<List<ResponsePackage>> GetAll()
        {
            return _mapper.Map<List<ResponsePackage>>(await _unitOfWork.PackageRepository.GetAll());
        }

        public async Task<ResponsePackage> GetById(Guid id)
        {
            return _mapper.Map<ResponsePackage>(await _unitOfWork.PackageRepository.GetById(id));
        }
    }
}
