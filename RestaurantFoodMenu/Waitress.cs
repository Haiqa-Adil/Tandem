using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.FoodMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApp.RestaurantFoodMenu
{
    public class Waitress
    {
        private readonly string restaurantId;
        private FoodMenu foodMenu;

        public Waitress(string restaurantId)
        {
            this.restaurantId = restaurantId;
        }

        public List<FoodMenuModel> PrintFoodMenu()
        {
            foodMenu = new FoodMenu(restaurantId);
            IIterator restaurantFoodMenu = foodMenu.CreateFoodMenuIterator();
            return PrintFoodMenu(restaurantFoodMenu);
        }

        public List<FoodMenuModel> PrintFilteredFoodMenu(Func<FoodMenuModel, bool> filterCriteria)
        {
            foodMenu = new FoodMenu(restaurantId);
            var foodMenuItems = foodMenu.GetFoodMenuItems();
            var filteredFoodMenuItems = foodMenuItems.Where(filterCriteria).ToList();
            PrintFoodMenu(new RestaurantFoodMenuIterator(filteredFoodMenuItems));
            return filteredFoodMenuItems;
        }

        private List<FoodMenuModel> PrintFoodMenu(IIterator iterator)
        {
            Console.WriteLine("Food Menu");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            List<FoodMenuModel> foodMenu = new List<FoodMenuModel>();

            while (iterator.HasNext())
            {
                FoodMenuModel foodMenuItem = (FoodMenuModel)iterator.Next();
                foodMenu.Add(foodMenuItem);

                Console.WriteLine("Restaurant ID : {0}", foodMenuItem.RestaurantId);
                Console.WriteLine("Food ID : {0}", foodMenuItem.FoodId);
                Console.WriteLine("Food Name : {0}", foodMenuItem.FoodName);
                Console.WriteLine("Cuisine : {0}", foodMenuItem.Cuisine);
                Console.WriteLine("Rate(Rs.) : {0}", foodMenuItem.Rate);
                Console.WriteLine("Rating : {0}", foodMenuItem.Rating);
                Console.WriteLine("____________________________");
                Console.WriteLine();
            }

            return foodMenu;
        }
    }
}
