using SupermarketApp.Services.Contracts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services.Contracts
{
    public interface IServiceManager
    {
        IMarketService Market {  get; }
        IRayonService Rayon { get; }
        IProductService Product { get; }
    }
}
