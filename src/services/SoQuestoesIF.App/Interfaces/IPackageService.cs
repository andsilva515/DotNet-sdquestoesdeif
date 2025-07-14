using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageDto>> GetAllPackagesAsync();
        Task<Guid> CreatePackageAsync(PackageCreateDto dto);
        Task<string> CreatePurchaseAndCheckoutAsync(Guid userId, PackagePurchaseDto dto);
    }
}
