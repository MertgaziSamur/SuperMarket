using Microsoft.Extensions.Hosting;
using SupermarketApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Services
{
    public class CurrencyUpdateService : BackgroundService
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyUpdateService(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _currencyService.GetExchangeRatesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
