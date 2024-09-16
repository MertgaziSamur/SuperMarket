using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using SupermarketApp.Services.Contracts;

namespace SuperRayonApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RayonsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public RayonsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRayonsAsync()
        {
            var result = await _manager.Rayon.GetAllRayonsAsync(false);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRayonByIdAsync([FromRoute] int id)
        {
            var result = await _manager.Rayon.GetRayonByIdAsync(id, false);
            return Ok(result);
        }

        [HttpGet("GetRayonMarket/{rayonId:int}")]
        public async Task<IActionResult> GetMarketByRayonIdAsync([FromRoute] int rayonId)
        {
            var result = await _manager.Rayon.GetMarketByRayonIdAsync(rayonId, false);
            return Ok(result);
        }

        [HttpGet("GetRayonProducts/{rayonId:int}")]
        public async Task<IActionResult> GetProductsByRayonIdAsync([FromRoute] int rayonId)
        {
            var result = await _manager.Rayon.GetProductsByRayonIdAsync(rayonId, false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRayonAsync([FromBody] RayonDtoForCreate RayonDto)
        {
            var rayon = await _manager.Rayon.CreateRayonAsync(RayonDto);
            return StatusCode(201, rayon);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRayonAsync([FromRoute] int id)
        {
            await _manager.Rayon.DeleteRayonAsync(id, false);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRayonAsync([FromRoute] int id, RayonDtoForUpdate RayonDto)
        {
            await _manager.Rayon.UpdateRayonAsync(id, RayonDto, false);
            return NoContent();
        }
    }
}
