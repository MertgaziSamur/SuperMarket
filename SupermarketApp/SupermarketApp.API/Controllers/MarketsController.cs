using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Services.Contracts;

namespace SupermarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public MarketsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarketsAsync()
        {
            var result = await _manager.Market.GetAllMarketsAsync(false);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMarketByIdAsync([FromRoute] int id)
        {
            var result = await _manager.Market.GetMarketByIdAsync(id, false);
            return Ok(result);
        }

        [HttpGet("GetMarketRayons/{marketId:int}")]
        public async Task<IActionResult> GetMarketRayonsAsync([FromRoute] int marketId)
        {
            var result = await _manager.Market.GetMarketRayonsAsync(marketId, false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogAsync([FromBody] MarketDtoForCreate MarketDto)
        {
            var market = await _manager.Market.CreateMarketAsync(MarketDto);
            return StatusCode(201, market);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMarketAsync([FromRoute] int id)
        {
            await _manager.Market.DeleteMarketAsync(id, false);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMarketAsync([FromRoute] int id, MarketDtoForUpdate MarketDto)
        {
            await _manager.Market.UpdateMarketAsync(id, MarketDto, false);
            return NoContent();
        }

    }
}
