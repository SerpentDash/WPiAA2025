using System;

namespace CodeSmells
{
    public class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }
    }

    public class Order
    {
        public string OrderId { get; set; }

        public Order(string orderId)
        {
            OrderId = orderId;
        }
    }

    public class OrderService
    {
        public void CreateOrder(Customer customer, Order order)
        {
            Console.WriteLine($"Order {order.OrderId} created for customer {customer.Name}.");
            SaveOrder(order);
        }

        public void SaveOrder(Order order)
        {
            Console.WriteLine($"Order {order.OrderId} saved.");
        }
    }
}
