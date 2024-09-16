using SupermarketApp.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp.Entities.Entities
{
    public class Market : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Rayon> Rayons { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
