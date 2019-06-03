using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.Models
{
    public class CustomerRentInfo
    {
        public string Name { get; set; }

        public short CustomerPoints { get; set; }

        public string CustomerPCType { get; set; }

        public ProductType CustomerRentedProduct { get; set; }

        public short RentalPeriod { get; set; }

        public decimal CustomerPaidMoney { get; set; }
    }
}
