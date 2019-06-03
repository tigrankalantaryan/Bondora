using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bondora.BLL.Models;
using Bondora.Models;
using Bondora.Models.Models;

namespace Bondora.BLL.Services
{
    public class ManagerRepository : IManagerRepository
    {
        private CacheMemoryService cacheMemoryService;

        public ManagerRepository(CacheMemoryService _cacheMemoryService)
        {
            cacheMemoryService = _cacheMemoryService;
        }

        public bool AddRent(long customerId, CustomerRentInfo rentedData)
        {
          return  cacheMemoryService.AddRent(customerId, rentedData);
        }

        public List<Invoice> GetInvoice(long customerId)
        {
            return cacheMemoryService.GetInvoice(customerId);
        }

        public List<RentItems> GetProducts()
        {
            return cacheMemoryService.GetProducts();
        }
    }
}
