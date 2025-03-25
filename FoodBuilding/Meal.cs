using FoodDeliveryApp.FoodDeliveryAppModel;
using System;
using System.Collections.Generic;

namespace FoodDeliveryApp.Ordering
{
    public class Meal
    {
        private readonly List<FoodMenuModel> foodItems = new List<FoodMenuModel>();
        private string specialInstructions;

        public void AddFoodItem(List<FoodMenuModel> items)
        {
            foodItems.AddRange(items);
        }

        public void SetSpecialInstructions(string instructions)
        {
            specialInstructions = instructions;
        }

        public double GetCost()
        {
            double cost = 0;

            foreach (var item in foodItems)
            {
                cost += item.Rate;
            }

            return cost;
        }

        public void ShowItems()
        {
            foreach (var item in foodItems)
            {
                Console.WriteLine("Food Id: {0}", item.FoodId);
                Console.WriteLine("Food Name: {0}", item.FoodName);
                Console.WriteLine("Food Price: {0}", item.Rate);
                Console.WriteLine("Food Rating: {0}", item.Rating);
                Console.WriteLine("----------------------------");
            }

            if (!string.IsNullOrEmpty(specialInstructions))
            {
                Console.WriteLine("Special Instructions: {0}", specialInstructions);
                Console.WriteLine("----------------------------");
            }
        }
    }
}
