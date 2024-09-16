using SupermarketApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IMarketRepository> _marketRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IRayonRepository> _rayonRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _marketRepository = new Lazy<IMarketRepository>(() => new MarketRepository(_context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _rayonRepository = new Lazy<IRayonRepository>(() => new RayonRepository(_context));
        }

        public IMarketRepository Market => _marketRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        public IRayonRepository Rayon => _rayonRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
