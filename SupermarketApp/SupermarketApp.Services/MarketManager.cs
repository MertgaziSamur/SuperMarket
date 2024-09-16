using AutoMapper;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Entities.Entities;
using SupermarketApp.Repositories.Contracts;
using SupermarketApp.Services.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services
{
    public class MarketManager : IMarketService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public MarketManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<MarketDto> CreateMarketAsync(MarketDtoForCreate marketDto)
        {
            if (marketDto == null)
                throw new ArgumentNullException(nameof(marketDto));

            var market = _mapper.Map<Market>(marketDto);
            _manager.Market.Create(market);

            await _manager.SaveAsync();

            return _mapper.Map<MarketDto>(market);
        }

        public async Task DeleteMarketAsync(int id, bool trackChanges)
        {
            var market = await _manager.Market.FindByIdAsync(id, trackChanges);
            var rayons = await _manager.Rayon.FindByConditionAsync(x => x.MarketId == market.Id, trackChanges);

            if (rayons != null)
            {
                foreach (var rayon in rayons)
                {
                    var products = await _manager.Product.FindByConditionAsync(x => x.RayonId == rayon.Id, trackChanges);

                    if(products != null)
                    {
                        foreach (var product in products)
                        {
                            var deletedProduct = await _manager.Product.FindByIdAsync(product.Id, trackChanges);
                            _manager.Product.Delete(deletedProduct);
                            await _manager.SaveAsync();
                        }

                        var deletedRayon = await _manager.Rayon.FindByIdAsync(rayon.Id, trackChanges);
                        _manager.Rayon.Delete(deletedRayon);
                        await _manager.SaveAsync();
                    }
                }
            }

            if (market == null)
            {
                throw new Exception($"Market with id: {id} is not found");
            }

            _manager.Market.Delete(market);
            await _manager.SaveAsync();
        }

        public async Task<List<MarketDto>> GetAllMarketsAsync(bool trackChanges)
        {
            var markets = await _manager.Market.FindAllAsync(trackChanges);

            foreach (var market in markets)
            {
                var marketRayons = await _manager.Market.GetMarketRayonsAsync(market.Id, trackChanges);
                market.Rayons = _mapper.Map<List<Rayon>>(marketRayons);

                foreach (var rayon in marketRayons)
                {
                    var rayonProducts = await _manager.Rayon.GetProductsByRayonIdAsync(rayon.Id, trackChanges);
                    rayon.Products = _mapper.Map<List<Product>>(rayonProducts);
                }
            }

            var mappedMarkets = _mapper.Map<List<MarketDto>>(markets);
            return mappedMarkets;
        }

        public async Task<MarketDto> GetMarketByIdAsync(int id, bool trackChanges)
        {
            var market = await _manager.Market.FindByIdAsync(id, trackChanges);

            if (market == null)
            {
                throw new Exception($"Market with id: {id} is not found");
            }

            return _mapper.Map<MarketDto>(market);
        }

        public async Task<List<RayonDto>> GetMarketRayonsAsync(int marketId, bool trackChanges)
        {
            var rayons = await _manager.Market.GetMarketRayonsAsync(marketId, trackChanges);

            if (rayons == null)
            {
                throw new Exception("The market does not have an rayon");
            }

            return _mapper.Map<List<RayonDto>>(rayons);
        }

        public async Task UpdateMarketAsync(int id, MarketDtoForUpdate marketDto, bool trackChanges)
        {
            var market = await _manager.Market.FindByIdAsync(id, trackChanges);

            if (market == null)
            {
                throw new Exception($"Market with id: {id} is not found");
            }

            if (marketDto == null)
            {
                throw new Exception("Market Dto is null");
            }

            market = _mapper.Map<Market>(marketDto);
            _manager.Market.Update(market);

            await _manager.SaveAsync();
        }
    }
}
