namespace FoodDeliveryApp.Tracking
{
    public class Restaurant : FoodDelivery
    {
        public Restaurant(string restaurantId, string orderId, string deliveryStatus)
            : base(restaurantId, orderId, deliveryStatus) { }

        public void UpdateDeliveryStatus(string newStatus, string estimatedDeliveryTime)
        {
            this.DeliveryStatus = newStatus;
            this.NotifyDetailed(estimatedDeliveryTime);
        }
    }
}
