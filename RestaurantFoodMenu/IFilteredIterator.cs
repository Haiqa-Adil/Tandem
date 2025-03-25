using FoodDeliveryApp.FoodDeliveryAppModel;
using System;

namespace FoodDeliveryApp.FoodMenu
{
    public interface IFilteredIterator : IIterator
    {
        void SetFilter(Func<FoodMenuModel, bool> filterCriteria);
    }
}

