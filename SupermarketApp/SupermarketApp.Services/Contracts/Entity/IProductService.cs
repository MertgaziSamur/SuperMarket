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
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync(bool trackChanges);
        Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForCreate productDto);
        Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task DeleteProductAsync(int id, bool trackChanges);
        Task<RayonDto> GetRayonByProductIdAsync(int productId, bool trackChanges);
        Task<MarketDto> GetMarketByProductIdAsync(int productId, bool trackChanges);
    }
}
