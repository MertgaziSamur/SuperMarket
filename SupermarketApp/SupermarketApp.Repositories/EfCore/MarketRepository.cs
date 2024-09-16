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
    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {
        public MarketRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<List<Rayon>> GetMarketRayonsAsync(int marketId, bool trackChanges)
        {
            return await _context.Set<Rayon>()
                                 .Where(r => r.MarketId == marketId)
                                 .Include(r => r.Market)  
                                 .ToListAsync();
        }
    }
}
