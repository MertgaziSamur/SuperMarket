using SupermarketApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.Contracts
{
    public interface IMarketRepository : IRepositoryBase<Market>
    {
        Task<List<Rayon>> GetMarketRayonsAsync(int marketId, bool trackChanges);
    }
}
