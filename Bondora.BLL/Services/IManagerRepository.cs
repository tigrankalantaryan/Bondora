using Bondora.Models;
using System.Collections.Generic;

namespace Bondora.BLL.Services
{
    public interface IManagerRepository
    {
        List<Invoice> GetInvoice(long customerId);

        List<RentItems> GetProducts();

        bool AddRent(long costumerId, CustomerRentInfo rentedData);
    }
}
