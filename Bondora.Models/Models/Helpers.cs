using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Models.Models
{
    public static class Helpers
    {
        public static void CalculateRent(CustomerInfo rentedData)
        {
            switch (rentedData.CustomerRentedProduct)
            {
                case ProductType.Heavy:
                    rentedData.CustomerPoints = 2;
                    rentedData.CustomerPaidMoney = 100 + (rentedData.RentalPeriod * 60);
                    break;

                case ProductType.Regular:
                    rentedData.CustomerPoints = 1;

                    rentedData.CustomerPaidMoney = rentedData.RentalPeriod > 2 ?
                        100 + (2 * 60) + ((rentedData.RentalPeriod - 2) * 40) :
                        100 + (rentedData.RentalPeriod * 60);
                    break;

                case ProductType.Specialized:
                    rentedData.CustomerPoints = 1;
                    rentedData.CustomerPaidMoney = rentedData.RentalPeriod > 3 ?
                        (rentedData.RentalPeriod * 60) :
                        (3 * 60) + ((rentedData.RentalPeriod - 3) * 40);
                    break;
            }
        }

        public static bool CheckBalance()
        {
            return true;
        }
    }
}
