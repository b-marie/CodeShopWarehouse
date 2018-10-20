using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class OrderRepository
    {

        private readonly IDbConnection _db;

        public OrderRepository(IDbConnection db)
        {
            _db = db;
        }

        public void CreateOrder(Order order)
        {
            Console.WriteLine("order created");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("order deleted");
        }

        public Order GetOrderById(int id)
        {
            return new Order()
            {
                Id = id,
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
            };
        }

        public List<Order> GetOpenOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3),
            };
        }

        public List<Order> GetClosedOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3),
            };
        }
        public List<Order> GetOrdersInProcessing()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3),
            };
        }
    }
}
