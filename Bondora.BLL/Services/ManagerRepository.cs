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

        public void AddRent(long custumerId, CustomerInfo rentedData)
        {
            cacheMemoryService.AddRent(custumerId, rentedData);
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
