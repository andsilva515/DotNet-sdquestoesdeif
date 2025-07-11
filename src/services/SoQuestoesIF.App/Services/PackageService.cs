using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
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
        private readonly IPackagePurchaseRepository _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackageService(
            IPackageRepository packageRepository,
            IPackagePurchaseRepository purchaseRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _packageRepository = packageRepository;
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
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

        public async Task PurchasePackageAsync(Guid userId, PackagePurchaseDto dto)
        {
            var purchase = new PackagePurchase
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PackageId = dto.PackageId,
                PurchaseDate = DateTime.UtcNow,
                Price = dto.Price,
                IsActive = true
            };

            await _purchaseRepository.AddAsync(purchase);
            await _unitOfWork.CommitAsync();
        }
    }

}
