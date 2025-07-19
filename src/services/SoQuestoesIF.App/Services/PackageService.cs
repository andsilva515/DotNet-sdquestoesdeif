using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPackagePurchaseRepository _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PackageService(
            IPackageRepository packageRepository,
            IPaymentRepository paymentRepository,
            IPackagePurchaseRepository purchaseRepository,
            IUnitOfWork unitOfWork,
            IPaymentService paymentService,
            IMapper mapper)
        {
            _packageRepository = packageRepository;
            _paymentRepository = paymentRepository;
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PackageDto>> GetAllPackagesAsync()
        {
            var packages = await _packageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PackageDto>>(packages);
        }

        public async Task<Guid> CreatePackageAsync(PackageCreateDto dto)
        {
            var entity = _mapper.Map<Package>(dto);
            entity.Id = Guid.NewGuid();

            await _packageRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task<string> CreatePurchaseAndCheckoutAsync(Guid userId, PackagePurchaseDto dto)
        {
            // Cria compra inativa
            var purchase = new PackagePurchase
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PackageId = dto.PackageId,
                Price = dto.Price,
                IsActive = false,
                PurchaseDate = DateTime.UtcNow
            };
            await _purchaseRepository.AddAsync(purchase);

            // Checkout
            var checkoutUrl = await _paymentService.CreateCheckoutAsync(userId, purchase.Id);

            // Pagamento aguardando
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = purchase.Id,
                Amount = dto.Price,
                Method = EnumPaymentMethod.MercadoPago,
                GatewayTransactionId = purchase.Id.ToString(),
                Status = "Aguardando",
                PaidAt = DateTime.MinValue
            };
            await _paymentRepository.AddAsync(payment);

            await _unitOfWork.CommitAsync();
            return checkoutUrl;
        }
    }


}
