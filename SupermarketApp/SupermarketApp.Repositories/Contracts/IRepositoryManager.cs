using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IMarketRepository Market {  get; }
        IProductRepository Product { get; }
        IRayonRepository Rayon { get; }
        Task SaveAsync();
    }
}
