namespace FoodDeliveryApp.FoodCostTaxCalculation
{
    public class TaxCalculationContext
    {
        private readonly ITaxCalculator taxCalculator;

        public TaxCalculationContext(ITaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        public double GetCalculatedTax(double price, double localTax, bool imported)
        {
           return taxCalculator.CalculateTax(price, localTax, imported);
        }
    }
}
