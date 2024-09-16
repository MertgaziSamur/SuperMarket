using SupermarketApp.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Entities
{
    public class Product : BaseEntity
    {
        public int? RayonId { get; set; }
        public int? MarketId { get; set; }
        public string Name { get; set; }
        public Rayon Rayon { get; set; }
        public Market Market { get; set; }

    }
}
