namespace FoodDeliveryApp.Tracking
{
    public interface ICustomers
    {
        void Update(FoodDelivery foodDelivery);
        void UpdateDetailed(FoodDelivery foodDelivery, string estimatedDeliveryTime);
    }
}
