using AutoMapper;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Entities.Entities;
using SupermarketApp.Repositories.Contracts;
using SupermarketApp.Services.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services
{
    public class RayonManager : IRayonService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public RayonManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<RayonDto> CreateRayonAsync(RayonDtoForCreate rayonDto)
        {
            if (rayonDto == null)
            {
                throw new ArgumentNullException(nameof(rayonDto));
            }

            var rayon = _mapper.Map<Rayon>(rayonDto);

            _manager.Rayon.Create(rayon);
            await _manager.SaveAsync();

            return _mapper.Map<RayonDto>(rayon);

        }

        public async Task DeleteRayonAsync(int id, bool trackChanges)
        {
            var rayon = await _manager.Rayon.FindByIdAsync(id, trackChanges);

            var products = await _manager.Product.FindByConditionAsync(x=>x.RayonId == rayon.Id, trackChanges);

            foreach (var product in products)
            {
                var deletedProduct = await _manager.Product.FindByIdAsync(product.Id, trackChanges);
                _manager.Product.Delete(deletedProduct);
            }

            if (rayon == null)
            {
                throw new Exception($"Rayon with id: {id} is not found");
            }

            _manager.Rayon.Delete(rayon);
            await _manager.SaveAsync();
        }

        public async Task<List<RayonDto>> GetAllRayonsAsync(bool trackChanges)
        {
            var rayons = await _manager.Rayon.FindAllAsync(trackChanges);

            foreach (var rayon in rayons)
            {
                var rayonProducts = await GetProductsByRayonIdAsync(rayon.Id, trackChanges);
                rayon.Products = _mapper.Map<List<Product>>(rayonProducts);
            }

            var mappedCatalogs = _mapper.Map<List<RayonDto>>(rayons);
            return mappedCatalogs;
        }

        public async Task<MarketDto> GetMarketByRayonIdAsync(int rayonId, bool trackChanges)
        {
            var market = await _manager.Rayon.GetMarketByRayonIdAsync(rayonId, trackChanges);

            if(market == null)
            {
                throw new Exception("This rayon does not have a market");
            }

            return _mapper.Map<MarketDto>(market);
        }

        public async Task<List<ProductDto>> GetProductsByRayonIdAsync(int rayonId, bool trackChanges)
        {
            var products = await _manager.Rayon.GetProductsByRayonIdAsync(rayonId,trackChanges);

            if(products == null)
            {
                throw new Exception("This rayon does not have any products");
            }

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<RayonDto> GetRayonByIdAsync(int id, bool trackChanges)
        {
            var rayon = await _manager.Rayon.FindByIdAsync(id, trackChanges);

            if(rayon == null)
            {
                throw new Exception($"Rayon with id: {id} is not found");
            }

            return _mapper.Map<RayonDto>(rayon);
        }

        public async Task UpdateRayonAsync(int id, RayonDtoForUpdate rayonDto, bool trackChanges)
        {
            var rayon = await _manager.Rayon.FindByIdAsync(id, trackChanges);

            if(rayon == null)
            {
                throw new Exception($"Rayon with id: {id} is not found");
            }

            if(rayonDto == null)
            {
                throw new Exception("Rayon Dto is null");
            }

            rayon = _mapper.Map<Rayon>(rayonDto);
            _manager.Rayon.Update(rayon);

            await _manager.SaveAsync(); 
        }
    }
}
