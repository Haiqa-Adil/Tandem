using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.FoodMenu;
using System;
using System.Collections.Generic;
namespace FoodDeliveryApp.RestaurantFoodMenu
{
    public class FilteredFoodMenuIterator : IFilteredIterator
{
        private readonly List<FoodMenuModel> foodItems;
        private int position;
        private Func<FoodMenuModel, bool> filterCriteria;

        public FilteredFoodMenuIterator(List<FoodMenuModel> foodItems)
        {
            this.foodItems = foodItems;
            this.filterCriteria = _ => true; // Default filter that allows all items
        }

        public bool HasNext()
        {
            while (position < foodItems.Count)
            {
                if (filterCriteria(foodItems[position]))
                {
                    return true;
                }
                position++;
            }
            return false;
        }

        public object Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements matching the criteria.");
            }

            return foodItems[position++];
        }

        public void SetFilter(Func<FoodMenuModel, bool> filterCriteria)
        {
            this.filterCriteria = filterCriteria;
            position = 0; // Reset the iterator
        }
    }
}
