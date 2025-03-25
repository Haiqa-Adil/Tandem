using System;
using System.Collections.Generic;

namespace FoodDeliveryApp.Tracking
{
    public abstract class FoodDelivery
    {
        #region Properties

        private readonly List<ICustomers> _customers = new List<ICustomers>();

        public string OrderId { get; set; }

        public string RestaurantId { get; set; }

        private string deliveryStatus;
        public string DeliveryStatus
        {
            get { return deliveryStatus; }
            set
            {
                if (deliveryStatus != value)
                {
                    deliveryStatus = value;
                    Notify();
                }
            }
        }

        public DateTime DeliveryTime
        {
            get { return DateTime.Now; }
        }

        #endregion

        #region Constructor

        protected FoodDelivery(string restaurantId, string orderId, string deliveryStatus)
        {
            this.RestaurantId = restaurantId;
            this.OrderId = orderId;
            this.deliveryStatus = deliveryStatus;
        }

        #endregion

        #region Methods

        public void Attach(ICustomers customer)
        {
            _customers.Add(customer);
        }

        public void Detach(ICustomers customer)
        {
            _customers.Remove(customer);
        }

        public void Notify()
        {
            foreach (ICustomers customer in _customers)
            {
                customer.Update(this);
            }

            Console.WriteLine(string.Empty);
        }

        public void NotifyDetailed(string estimatedDeliveryTime)
        {
            foreach (ICustomers customer in _customers)
            {
                customer.UpdateDetailed(this, estimatedDeliveryTime);
            }

            Console.WriteLine(string.Empty);
        }

        #endregion
    }
}
