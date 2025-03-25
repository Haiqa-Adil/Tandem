using FoodDeliveryApp.FoodDeliveryAppModel;
using System;

namespace FoodDeliveryApp.OrderAndCancellation
{
    public class Food
    {
        public string OrderFood(string restaurantId, UserModel user)
        {
            var orderId = (restaurantId + Guid.NewGuid().ToString().Substring(0, 15)).ToUpper();
            Console.WriteLine("Order ID: {0}", orderId);
            Console.WriteLine("Customer Name : {0}", user.UserName);
            Console.WriteLine("Mobile : {0}", user.PhoneNumber);
            Console.WriteLine("User ID : {0}", user.UserId);
            Console.WriteLine("Address : {0}", user.Address);
            Console.WriteLine("Amount(Rs.): {0}", user.Amount);
            Console.WriteLine("Food Ordered");
            return orderId.ToString();
        }

        public void CancelFood(string orderId)
        {
            Console.WriteLine("Food Order with Order ID {0} has been cancelled.", orderId);
        }

        public void UpdateOrder(string orderId, UserModel updatedUser)
        {
            Console.WriteLine("Food Order with Order ID {0} has been updated.", orderId);
            Console.WriteLine("Updated Customer Name : {0}", updatedUser.UserName);
            Console.WriteLine("Updated Mobile : {0}", updatedUser.PhoneNumber);
            Console.WriteLine("Updated Address : {0}", updatedUser.Address);
            Console.WriteLine("Updated Amount(Rs.): {0}", updatedUser.Amount);
        }
    }
}
