using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.Models
{
    public class Invoice
    {
        public ProductType ProductType  { get; set; }

        public decimal Price { get; set; }

        public short Points { get; set; }
    }
}
