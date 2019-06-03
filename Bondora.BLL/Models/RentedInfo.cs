using Bondora.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.BLL.Models
{
    public class RentedInfo
    {
        [JsonProperty("customerId")]
        public long CustomerId { get; set; }


        [JsonProperty("rentedData")]
        public CustomerRentInfo RentedData { get; set; }
    }
}
