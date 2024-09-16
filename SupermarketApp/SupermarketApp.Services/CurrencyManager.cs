using SupermarketApp.Entities.Dtos.Exchanges;
using SupermarketApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SupermarketApp.Services
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeRateDto> GetExchangeRatesAsync()
        {
            var tcmbUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";

            var response = await _httpClient.GetAsync(tcmbUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var document = XDocument.Parse(content);

                var usdElement = document.Descendants("Currency")
                                         .FirstOrDefault(x => (string)x.Attribute("CurrencyCode") == "USD");
                var usdRate = (decimal)usdElement.Element("ForexSelling");

                var eurElement = document.Descendants("Currency")
                                         .FirstOrDefault(x => (string)x.Attribute("CurrencyCode") == "EUR");
                var eurRate = (decimal)eurElement.Element("ForexSelling");

                return new ExchangeRateDto
                {
                    USDToTRY = usdRate,
                    EURToTRY = eurRate
                };
            }

            throw new HttpRequestException("Exchange rate data could not be retrieved.");
        }
    }
}
