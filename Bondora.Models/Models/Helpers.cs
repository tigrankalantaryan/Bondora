using System;
using System.Collections.Generic;
using System.Text;

namespace Bondora.Models.Models
{
    public static class Helpers
    {
        public static void CalculateRent(CustomerRentInfo rentedData)
        {
            var OneTimePrice = 100;
            var PremiumPrice = 60;
            var RegularPrice = 40;
            switch (rentedData.CustomerRentedProduct)
            {
                case ProductType.Heavy:
                    rentedData.CustomerPoints = 2;
                    rentedData.CustomerPaidMoney = OneTimePrice + (rentedData.RentalPeriod * PremiumPrice);
                    break;

                case ProductType.Regular:
                    rentedData.CustomerPoints = 1;

                    rentedData.CustomerPaidMoney = rentedData.RentalPeriod > 2 ?
                        100 + (2 * PremiumPrice) + ((rentedData.RentalPeriod - 2) * RegularPrice) :
                        100 + (rentedData.RentalPeriod * PremiumPrice);
                    break;

                case ProductType.Specialized:
                    rentedData.CustomerPoints = 1;
                    rentedData.CustomerPaidMoney = rentedData.RentalPeriod > 3 ?
                        (rentedData.RentalPeriod * PremiumPrice) :
                        (3 * PremiumPrice) + ((rentedData.RentalPeriod - 3) * RegularPrice);
                    break;
            }
        }

        public static bool CheckBalance()
        {
            return true;
        }
    }
}
