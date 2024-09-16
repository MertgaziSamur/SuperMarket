using SupermarketApp.Entities.Dtos.ProductDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Dtos.MarketDtos
{
    public record MarketDtoForCreate
    {
        public string Name { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
    }
}
