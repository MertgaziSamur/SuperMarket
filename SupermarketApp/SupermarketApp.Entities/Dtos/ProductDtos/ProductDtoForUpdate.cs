using SupermarketApp.Entities.Dtos.MarketDtos;
using SupermarketApp.Entities.Dtos.RayonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Dtos.ProductDtos
{
    public record ProductDtoForUpdate
    {
        public int Id { get; init; }
        public int RayonId { get; init; }
        public int MarketId { get; init; }
        public string Name { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UptatedDate { get; init; }
    }
}
