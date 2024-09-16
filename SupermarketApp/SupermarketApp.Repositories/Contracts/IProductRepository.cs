using SupermarketApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Rayon> GetRayonByProductIdAsync(int productId, bool trackChanges);
        Task<Market> GetMarketByProductIdAsync(int productId, bool trackChanges);
    }
}
