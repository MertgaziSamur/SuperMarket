using AutoMapper;
using SupermarketApp.Repositories.Contracts;
using SupermarketApp.Services.Contracts;
using SupermarketApp.Services.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMarketService> _marketService;
        private readonly Lazy<IRayonService> _rayonService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _marketService = new Lazy<IMarketService>(() => new MarketManager(repositoryManager, mapper));
            _productService = new Lazy<IProductService>(() => new ProductManager(repositoryManager, mapper));
            _rayonService = new Lazy<IRayonService>(() => new RayonManager(repositoryManager, mapper));
        }
        public IMarketService Market => _marketService.Value;
        public IRayonService Rayon => _rayonService.Value;
        public IProductService Product => _productService.Value;
    }
}
