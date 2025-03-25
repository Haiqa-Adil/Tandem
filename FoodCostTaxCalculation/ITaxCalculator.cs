namespace FoodDeliveryApp.FoodCostTaxCalculation
{
    public interface ITaxCalculator
    {
        double CalculateTax(double price, double localTax, bool imported);
    }
}
