using Bondora.BLL.Services;
using Bondora.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.BLL.Models
{
    public class CacheMemoryService
    {
        private IMemoryCache _cache;
        public CacheMemoryService(IMemoryCache cache)
        {
            _cache = cache;
            InitData();
        }

        private void InitData()
        {
            List<RentItems> allItems = new List<RentItems>()
            {
                new RentItems { Name = "Caterpillar Bulldozer", Price = 100, Type = ProductType.Heavy },
                new RentItems { Name = "KamAZ truck", Price = 60, Type = ProductType.Regular },
                new RentItems { Name = "Komatsu crane", Price = 100, Type = ProductType.Heavy },
                new RentItems { Name = "Volvo steamroller ", Price = 60, Type = ProductType.Regular },
                new RentItems { Name = "Bosch jackhammer", Price = 40, Type = ProductType.Specialized }
             };

            _cache.Set("RentItems", allItems, new MemoryCacheEntryOptions() { Priority = CacheItemPriority.NeverRemove });
            _cache.Set("CustomerData",new Dictionary<long, List<CustomerInfo>>(), new MemoryCacheEntryOptions() { Priority = CacheItemPriority.NeverRemove });
        }

        public List<Invoice> GetInvoice(long customerId)
        {
            List<Invoice> customerInvoice = new List<Invoice>();

            var customerData = new Dictionary<long, List<CustomerInfo>>();
            if (_cache.TryGetValue("CustomerData", out customerData))
            {
                customerInvoice.AddRange(customerData[customerId].Select(e => new Invoice() { Points = e.CustomerPoints, ProductType = e.CustomerRentedProduct, Price = e.CustomerPaidMoney }).ToList());
            }

            return customerInvoice;
        }

        public List<RentItems> GetProducts()
        {
            List<RentItems> allItems = new List<RentItems>();
            _cache.TryGetValue("RentItems", out allItems);
            return allItems;
        }


        public void AddRent(long custumerId, CustomerInfo rentedData)
        {
            var customerData = new Dictionary<long, List<CustomerInfo>>();

            if (_cache.TryGetValue("CustomerData", out customerData))
            {
                if (customerData.ContainsKey(custumerId))
                {
                    customerData[custumerId].Add(rentedData);
                }
                else
                {
                    customerData.Add(custumerId, new List<CustomerInfo>() { rentedData });
                }
            }
        }
    }
}
