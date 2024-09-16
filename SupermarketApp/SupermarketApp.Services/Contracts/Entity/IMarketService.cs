using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services.Contracts.Entity
{
    public interface IMarketService
    {
        Task<List<MarketDto>> GetAllMarketsAsync(bool trackChanges);
        Task<MarketDto> GetMarketByIdAsync(int id, bool trackChanges);
        Task<MarketDto> CreateMarketAsync(MarketDtoForCreate marketDto);
        Task UpdateMarketAsync(int id, MarketDtoForUpdate marketDto, bool trackChanges);
        Task DeleteMarketAsync(int id, bool trackChanges);
        Task<List<RayonDto>> GetMarketRayonsAsync(int marketId, bool trackChanges);
    }
}
