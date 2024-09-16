using Microsoft.EntityFrameworkCore;
using SupermarketApp.Entities.Entities;
using SupermarketApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.EfCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<Rayon> GetRayonByProductIdAsync(int productId, bool trackChanges)
        {
            return await _context.Set<Product>()
                                 .Where(p => p.Id == productId)
                                 .Select(p => p.Rayon) 
                                 .FirstOrDefaultAsync();
        }
        public async Task<Market> GetMarketByProductIdAsync(int productId, bool trackChanges)
        {
            return await _context.Set<Product>()
                                 .Where(p => p.Id == productId)
                                 .Select(p => p.Market) 
                                 .FirstOrDefaultAsync();
        }
    }
}
