using SupermarketApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.Contracts
{
    public interface IRayonRepository : IRepositoryBase<Rayon>
    {
        Task<Market> GetMarketByRayonIdAsync(int rayonId, bool trackChanges);
        Task<List<Product>> GetProductsByRayonIdAsync(int rayonId, bool trackChanges);
    }
}
