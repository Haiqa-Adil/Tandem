using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.Ordering;
using System;
using System.Collections.Generic;
using FoodDeliveryApp.FoodCostTaxCalculation;

namespace FoodDeliveryApp.FoodDeliveryDriver
{
    public class MealBuilderDriver
    {
        /// <summary>
        /// Builds a meal for the user and calculates the total cost including tax.
        /// </summary>
        /// <param name="selectedMealItems">List of selected food items for the meal</param>
        /// <returns>Total cost of the meal including tax</returns>
        public double BuildMealForUser(List<FoodMenuModel> selectedMealItems)
        {
            Console.WriteLine();
            Console.WriteLine("You selected the following meal items:");
            Console.WriteLine("_____________________________________");

            // Use fluent interface to build the meal
            Meal meal = new MealBuilder()
                .AddFoodItems(selectedMealItems)
                .SetSpecialInstructionsFromUser() // Prompt user for special instructions
                .Build();

            meal.ShowItems();
            double foodCost = meal.GetCost();

            // Calculate tax
            var taxCalculationContext = new TaxCalculationContext(new OneStarTaxCalculator());
            var taxAmount = taxCalculationContext.GetCalculatedTax(foodCost, 0.05, false);
            var totalCostOfFood = foodCost + taxAmount;

            Console.WriteLine("Total Cost (Rs.): {0}", totalCostOfFood);
            Console.WriteLine("Total Tax (Rs.): {0}", taxAmount);

            return totalCostOfFood;
        }
    }
}
