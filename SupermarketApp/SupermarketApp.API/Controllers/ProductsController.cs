using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Services.Contracts;

namespace SupermarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _manager.Product.GetAllProductsAsync(false);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {
            var result = await _manager.Product.GetProductByIdAsync(id, false);
            return Ok(result);
        }

        [HttpGet("GetProductRayon/{productId:int}")]
        public async Task<IActionResult> GetRayonByProductIdAsync([FromRoute] int productId)
        {
            var result = await _manager.Product.GetRayonByProductIdAsync(productId, false);
            return Ok(result);
        }
        [HttpGet("GetProductMarket/{productId:int}")]
        public async Task<IActionResult> GetMarketByProductIdAsync([FromRoute] int productId)
        {
            var result = await _manager.Product.GetMarketByProductIdAsync(productId, false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogAsync([FromBody] ProductDtoForCreate productDto)
        {
            var product = await _manager.Product.CreateProductAsync(productDto);
            return StatusCode(201, product);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            await _manager.Product.DeleteProductAsync(id, false);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDtoForUpdate productDto, [FromRoute] int id)
            {
            await _manager.Product.UpdateProductAsync(id, productDto, false);
            return NoContent();
        }
    }
}
