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
    public class RayonRepository : RepositoryBase<Rayon>, IRayonRepository
    {
        public RayonRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<Market> GetMarketByRayonIdAsync(int rayonId, bool trackChanges)
        {
            return await _context.Set<Rayon>()
                                 .Where(r => r.Id == rayonId)
                                 .Select(r => r.Market) 
                                 .FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetProductsByRayonIdAsync(int rayonId, bool trackChanges)
        {
            return await _context.Set<Product>()
                                 .Where(p => p.RayonId == rayonId) 
                                 .ToListAsync();
        }
    }
}
