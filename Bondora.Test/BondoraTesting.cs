using Bondora.BLL.Models;
using Bondora.BLL.Services;
using Bondora.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bondora.Test
{
    public  class BondoraTesting
    {
        private IManagerRepository manager;

        public BondoraTesting()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            CacheMemoryService memory = new CacheMemoryService(memoryCache);
            manager = new ManagerRepository(memory);
        }


        [Fact]
        public void TestAddRent()
        {
            long customerId = 1;
            CustomerRentInfo customerRentInfo = new CustomerRentInfo() {  CustomerPaidMoney = 100, CustomerPCType = "Chrome",  CustomerPoints = 2, CustomerRentedProduct = ProductType.Heavy, Name = "Bulduser", RentalPeriod = 1};
            Assert.True(manager.AddRent(customerId,customerRentInfo));
        }

        [Fact]
        public void TestGetProduct()
        {
            Assert.NotNull(manager.GetProducts());
        }

        [Fact]
        public void TestGetInvoice()
        {
            long customerId = 1;
            TestAddRent();
            Assert.NotNull(manager.GetInvoice(customerId));
        }
    }
}
