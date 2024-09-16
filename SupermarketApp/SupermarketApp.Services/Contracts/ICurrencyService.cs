using SupermarketApp.Entities.Dtos.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services.Contracts
{
    public interface ICurrencyService
    {
        Task<ExchangeRateDto> GetExchangeRatesAsync();
    }
}
