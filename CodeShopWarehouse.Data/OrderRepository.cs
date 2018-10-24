using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class OrderRepository
    {

        private readonly CodeShopWarehouseDbContext _db;

        public OrderRepository(CodeShopWarehouseDbContext db)
        {
            _db = db;
        }

        public void CreateOrder(Order order)
        {
            _db.Order.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            _db.Order.Remove(order);
        }

        public Order GetOrderById(int id)
        {
            return _db.Order.Find(id);
        }

        public List<Order> GetOpenOrders()
        {
            List<Order> orders = new List<Order>();
            orders.AddRange(_db.Order.Where(o => o.ProcessedAt == null));
            return orders;
        }

        public List<Order> GetProcessedOrders()
        {
            List<Order> orders = new List<Order>();
            orders.AddRange(_db.Order.Where(o => o.ProcessedAt != null && o.ClosedAt == null));
            return orders;
        }

        public List<Order> GetClosedOrders()
        {
            List<Order> orders = new List<Order>();
            orders.AddRange(_db.Order.Where(o => o.ClosedAt != null));
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            _db.Order.Update(order);
        }
    }
}
