using Bondora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.BLL.Models
{
    public class CacheMemoryInfo
    {
        public CacheMemoryInfo()
        {
            RentItems = new List<RentItems>();
            CustomerData = new Dictionary<long,List<CustomerInfo>>();
        }

        public List<RentItems> RentItems { get; set; }

        public Dictionary<long,List<CustomerInfo>> CustomerData { get; set; }

    }
}
