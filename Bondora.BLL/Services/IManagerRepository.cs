using Bondora.BLL.Models;
using Bondora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bondora.BLL.Services
{
    public interface IManagerRepository
    {
        List<Invoice> GetInvoice(long customerId);

        List<RentItems> GetProducts();

        void AddRent(long custumerId, CustomerInfo rentedData);
    }
}
