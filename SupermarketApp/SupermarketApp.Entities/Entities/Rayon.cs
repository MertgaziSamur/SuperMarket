using SupermarketApp.Entities.Contracts;
using SupermarketApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Entities
{
    public class Rayon : BaseEntity
    {
        public int? MarketId { get; set; }
        public Market Market { get; set; }
        public RayonType RayonType { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
