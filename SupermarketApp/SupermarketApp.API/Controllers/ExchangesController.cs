using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketApp.Services.Contracts;

namespace SupermarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public ExchangesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsdAndEurRates()
        {
            var rates = await _currencyService.GetExchangeRatesAsync();
            return Ok(rates);
        }
    }
}
