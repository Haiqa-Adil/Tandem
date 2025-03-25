using FoodDeliveryApp.FoodDeliveryAppModel;
using System;
using System.Collections.Generic;

namespace FoodDeliveryApp.Ordering
{
    public class MealBuilder
    {
        private Meal meal;

        public MealBuilder()
        {
            meal = new Meal();
        }

        public MealBuilder AddFoodItems(List<FoodMenuModel> foodMenu)
        {
            meal.AddFoodItem(foodMenu);
            return this;
        }

        public MealBuilder SetSpecialInstructionsFromUser()
        {
            Console.WriteLine("Enter any special instructions for your meal (press Enter to skip):");
            string instructions = Console.ReadLine();

            if (!string.IsNullOrEmpty(instructions))
            {
                meal.SetSpecialInstructions(instructions);
            }

            return this;
        }

        public Meal Build()
        {
            return meal;
        }
    }
}
