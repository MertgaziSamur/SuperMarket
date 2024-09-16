using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Dtos.RayonDtos
{
    public record RayonDto
    {
        public int Id { get; init; }
        public int MarketId { get; init; }
        public string RayonType { get; init; }
        public List<ProductDto> Products { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
    }
}
