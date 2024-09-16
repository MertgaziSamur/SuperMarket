using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services.Contracts.Entity
{
    public interface IRayonService
    {
        Task<List<RayonDto>> GetAllRayonsAsync(bool trackChanges);
        Task<RayonDto> GetRayonByIdAsync(int id, bool trackChanges);
        Task<RayonDto> CreateRayonAsync(RayonDtoForCreate rayonDto);
        Task UpdateRayonAsync(int id, RayonDtoForUpdate rayonDto, bool trackChanges);
        Task DeleteRayonAsync(int id, bool trackChanges);
        Task<MarketDto> GetMarketByRayonIdAsync(int rayonId, bool trackChanges);
        Task<List<ProductDto>> GetProductsByRayonIdAsync(int rayonId, bool trackChanges);
    }
}
