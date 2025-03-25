using FoodDeliveryApp.Utils;

namespace FoodDeliveryApp.FoodCostTaxCalculation
{
    public class FourStarTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double price, double localTax, bool imported)
        {
            double tax = price * localTax;

            if (imported)
                tax += (price * 3.5);

            // rounds off to nearest 0.05;
            tax = TaxUtil.RoundOff(tax);

            return tax;
        }
    }
}
