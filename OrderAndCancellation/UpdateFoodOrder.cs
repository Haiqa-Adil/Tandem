using FoodDeliveryApp.FoodDeliveryAppModel;

namespace FoodDeliveryApp.OrderAndCancellation
{
    public class UpdateFoodOrder : IFoodOrderCommands
    {
        private readonly Food food;
        public string OrderId;
        public UserModel UpdatedUser;

        public UpdateFoodOrder(Food food)
        {
            this.food = food;
            UpdatedUser = new UserModel(); // Ensure UpdatedUser is instantiated
        }

        public void Execute()
        {
            food.UpdateOrder(OrderId, UpdatedUser);
        }
    }
}
