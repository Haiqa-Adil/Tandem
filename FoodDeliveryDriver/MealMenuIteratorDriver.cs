using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.RestaurantFoodMenu;
using System;
using System.Collections.Generic;

namespace FoodDeliveryApp.FoodDeliveryDriver
{
    /// <summary>
    /// This driver called - Iterator Pattern.
    /// </summary>
    public class MealMenuIteratorDriver
    {
        public List<FoodMenuModel> PrintMealMenu(string restaurantId)
        {
            Waitress waitress = new Waitress(restaurantId);
            var foodMenu = waitress.PrintFoodMenu();

            Console.WriteLine("Would you like to apply any filters to the menu? (yes/no)");
            string applyFilters = Console.ReadLine().ToLower();

            if (applyFilters == "y")
            {
                Func<FoodMenuModel, bool> filterCriteria = GetFilterCriteriaFromUser();
                foodMenu = waitress.PrintFilteredFoodMenu(filterCriteria);
            }

            return foodMenu;
        }

        private Func<FoodMenuModel, bool> GetFilterCriteriaFromUser()
        {
            Console.WriteLine("Select a filter option:");
            Console.WriteLine("1. Minimum Rating");
            Console.WriteLine("2. Cuisine Type");
            int filterOption = int.Parse(Console.ReadLine());

            Func<FoodMenuModel, bool> filterCriteria = _ => true; // Default filter

            switch (filterOption)
            {
                case 1:
                    Console.WriteLine("Enter the minimum rating:");
                    int minRating = int.Parse(Console.ReadLine());
                    filterCriteria = item => item.Rating >= minRating;
                    break;
                case 2:
                    Console.WriteLine("Enter the cuisine type:");
                    string cuisineType = Console.ReadLine();
                    filterCriteria = item => item.Cuisine.Equals(cuisineType, StringComparison.OrdinalIgnoreCase);
                    break;
                default:
                    Console.WriteLine("Invalid option. No filter will be applied.");
                    break;
            }

            return filterCriteria;
        }
    }
}
