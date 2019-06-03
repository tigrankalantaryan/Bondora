using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.Models
{
    public class RentItems
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }
    }
}
