using AutoMapper;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Entities.Entities;
using SupermarketApp.Repositories.Contracts;
using SupermarketApp.Services.Contracts.Entity;


namespace SupermarketApp.Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDtoForCreate productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            var product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);

            await _manager.SaveAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteProductAsync(int id, bool trackChanges)
        {
            var product = await _manager.Product.FindByIdAsync(id, trackChanges);

            if (product == null)
            {
                throw new Exception($"Product with id: {id} is not found");
            }

            _manager.Product.Delete(product);
            await _manager.SaveAsync();
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await _manager.Product.FindAllAsync(trackChanges);

            var mappedProducts = _mapper.Map<List<ProductDto>>(products);

            return mappedProducts;
        }

        public async Task<MarketDto> GetMarketByProductIdAsync(int productId, bool trackChanges)
        {
            var market = await _manager.Product.GetMarketByProductIdAsync(productId, trackChanges);

            if(market == null)
            {
                throw new Exception("This product does not have a market");
            }

            return _mapper.Map<MarketDto>(market);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await _manager.Product.FindByIdAsync(id, trackChanges);

            if (product == null)
            {
                throw new Exception($"Product with id: {id} is not found");
            }

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<RayonDto> GetRayonByProductIdAsync(int productId, bool trackChanges)
        {
            var rayon = await _manager.Product.GetRayonByProductIdAsync(productId, trackChanges);

            if(rayon == null)
            {
                throw new Exception("This product does not have a rayon");
            }

            return _mapper.Map<RayonDto>(rayon);
        }

        public async Task UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var product = await _manager.Product.FindByIdAsync(id, trackChanges);

            if (product == null)
            {
                throw new Exception($"Product with id: {id} is not found");
            }

            if (productDto == null)
            {
                throw new Exception("Product Dto is null");
            }

            product.Id = productDto.Id;

            product = _mapper.Map<Product>(productDto);
            _manager.Product.Update(product);

            await _manager.SaveAsync();
        }
    }
}
