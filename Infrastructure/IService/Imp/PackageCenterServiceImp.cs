using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Payment;
using Infrastructure.Common.Request;
using Infrastructure.Common.Response;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class PackageCenterServiceImp : IPackageCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;
        private readonly ConfiVnPay _confiVnPay;
        private readonly VnPayLibrary _vnPayLibrary;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PackageCenterServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler, ConfiVnPay confiVnPay, VnPayLibrary vnPayLibrary, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _confiVnPay = confiVnPay;
            _vnPayLibrary = vnPayLibrary;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Create(CreateCenterPackage createCenterPackage)
        {
            var create = _mapper.Map<CenterPackages>(createCenterPackage);
            var email = _tokenHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var center = await _unitOfWork.MaintenanceCenter.GetById(account.MaintenanceCenter.MaintenanceCenterId);

            var package = await _unitOfWork.PackageRepository.GetById(create.PackageId);
            create.MaintenanceCenterId = center.MaintenanceCenterId;
            create.Status = EnumStatus.ACTIVE.ToString();
            create.StartDate = DateTime.Now;
            create.EndDate = create.StartDate.AddMonths(package.DurationMonths);
            await _unitOfWork.PackageCenterRepository.Add(create);
            Transactions transactions = new Transactions
            {

                Amount=createCenterPackage.CreateTransaction.Amount,
                PaymentMethod=createCenterPackage.CreateTransaction.PaymentMethod,
                TransactionsId=Guid.NewGuid(),
                Status=EnumStatus.ACTIVE.ToString(),
                CenterPackagesId=create.CenterPackagesId,
                TransactionDate=DateTime.Now,
            };
            await _unitOfWork.TransactionRepository.Add(transactions);


            var url = await CreatePaymentUrl( transactions, package);


            //await _unitOfWork.Commit();
            return _mapper.Map<string>(url);
        }

        public async Task<List<ResponseCenterPackage>> GetAll()
        {
            return _mapper.Map<List<ResponseCenterPackage>>(await _unitOfWork.PackageCenterRepository.GetAll());
        }

        public async Task<ResponseCenterPackage> GetById(Guid id)
        {
            return _mapper.Map<ResponseCenterPackage>(await _unitOfWork.PackageCenterRepository.GetById(id));
        }

        public async Task<List<ResponseCenterPackage>> GetListByCenterId(Guid id)
        {
            return _mapper.Map<List<ResponseCenterPackage>>(await _unitOfWork.PackageCenterRepository.GetAll());
        }
        private async Task<string> CreatePaymentUrl( Transactions transactions,Package package)
        {
            var tick = DateTime.Now.Ticks.ToString();
            //var r = await _unitOfWork.ReceiptRepository.GetById(model.ReceiptId);
            //var packagev1 = await _unitOfWork.PackageRepository.GetById(package.PackageId);

            _vnPayLibrary.AddRequestData("vnp_Version", _confiVnPay.Version);
            _vnPayLibrary.AddRequestData("vnp_Command", _confiVnPay.Command);
            _vnPayLibrary.AddRequestData("vnp_TmnCode", _confiVnPay.TmnCode);
            _vnPayLibrary.AddRequestData("vnp_Amount", (package.MonthlyPrice * 100).ToString());

            _vnPayLibrary.AddRequestData("vnp_CreateDate", transactions.TransactionDate.ToString("yyyyMMddHHmmss"));
            _vnPayLibrary.AddRequestData("vnp_CurrCode", _confiVnPay.CurrCode);
            _vnPayLibrary.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(_httpContextAccessor.HttpContext));
            _vnPayLibrary.AddRequestData("vnp_Locale", _confiVnPay.Locale);

            _vnPayLibrary.AddRequestData("vnp_OrderInfo", "Thanh toán cho đơn hàng:" + transactions.TransactionsId);
            _vnPayLibrary.AddRequestData("vnp_OrderType", "other");

            //string baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.PathBase}";
            //string returnUrl = $"{baseUrl}/api/Payments/PaymentExecute/";
            _vnPayLibrary.AddRequestData("vnp_ReturnUrl", "returnUrl");

            _vnPayLibrary.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl = await _vnPayLibrary.CreateRequestUrl(_confiVnPay.BaseUrl, _confiVnPay.HashSecret);
            return paymentUrl;
        }
    }
}
