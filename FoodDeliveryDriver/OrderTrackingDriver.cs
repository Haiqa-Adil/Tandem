using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.Tracking;
using System;
using System.Threading;

namespace FoodDeliveryApp.FoodDeliveryDriver
{
    public class OrderTrackingDriver
    {
        /// <summary>
        /// This Driver used Observer Design Pattern
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <param name="orderId"></param>
        /// <param name="user"></param>
        /// <param name="cancel"></param>
        public void OrderTrackingByUser(string restaurantId, string orderId, UserModel user, char cancel)
        {
            if (cancel != 'y')
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Food Delivery Status");
                Console.WriteLine("---------------------");

                Restaurant restaurant = new Restaurant(restaurantId, orderId, "Order Received");
                Customers customer = new Customers(user);
                restaurant.Attach(customer);

                Thread.Sleep(1000);
                restaurant.UpdateDeliveryStatus("Dispatched", "30 minutes");
                Thread.Sleep(1000);
                restaurant.UpdateDeliveryStatus("On the way", "25 minutes");
                Thread.Sleep(1000);
                restaurant.UpdateDeliveryStatus("Near to your home", "5 minutes");
                restaurant.UpdateDeliveryStatus("Delivered", "0 minutes");

                restaurant.Detach(customer);
            }

            Console.ReadKey();
        }
    }
}
