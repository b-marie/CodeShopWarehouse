using System;
using System.Collections.Generic;
using System.Text;
using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Business
{
    class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //Create customer order (order type)
        public void CreateCustomerOrder(Order order)
        {
            order.OrderType = "Customer Order";
            _orderRepository.CreateOrder(order);
        }

        //Create inventory order (order type)
        public void CreateInventoryOrder(Order order)
        {
            order.OrderType = "Inventory Order";
            _orderRepository.CreateOrder(order);
        }

        //Delete order
        public void DeleteOrder(Order order)
        {
            _orderRepository.DeleteOrder(order);
        }

        //Get order
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        //View all open orders
        public List<Order> GetOpenOrders()
        {
            return _orderRepository.GetOpenOrders();
        }

        //View all orders in processing
        public List<Order> GetProcessedOrders()
        {
            return _orderRepository.GetProcessedOrders();
        }

        //View all closed orders
        public List<Order> GetClosedOrders()
        {
            return _orderRepository.GetClosedOrders();
        }

        //Process order
        public Order ProcessOrder(Order order, DateTimeOffset processTime)
        {
            var currentOrder = GetOrderById(order.Id);
            if (currentOrder == null)
            {
                //Doesn't exist
                throw new Exception("Order not found");
            }

            if (currentOrder.ProcessedAt != null)
            {
                throw new Exception("Order already processed");
            }

            currentOrder.ProcessedAt = processTime;
            _orderRepository.UpdateOrder(currentOrder);
            return currentOrder;
        }

        //Close order
        public Order CloseOrder(Order order, DateTimeOffset closeTime)
        {
            var currentOrder = GetOrderById(order.Id);
            if (currentOrder == null)
            {
                throw new Exception("Order not found");
            }

            if (currentOrder.ClosedAt != null)
            {
                throw new Exception("Order already closed");
            }

            currentOrder.ClosedAt = closeTime;
            _orderRepository.UpdateOrder(currentOrder);
            return currentOrder;
        }
    }
}
