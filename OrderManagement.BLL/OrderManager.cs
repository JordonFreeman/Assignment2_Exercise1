using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.DAL;
using OrderManagement.Models;

namespace OrderManagement.BLL
{
    public class OrderManager
    {
        private readonly OrderRepository _orderRepo;
        private readonly OrderDetailRepository _orderDetailRepo;
        private readonly ItemRepository _itemRepo;

        public OrderManager()
        {
            _orderRepo = new OrderRepository();
            _orderDetailRepo = new OrderDetailRepository();
            _itemRepo = new ItemRepository();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepo.GetOrderById(orderId);
        }

        public int CreateOrder(Order order)
        {
            // Validate order data
            if (order.AgentID <= 0)
                throw new ArgumentException("Invalid agent ID");

            if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                throw new ArgumentException("Order must have at least one item");

            // Calculate total amount based on order details
            decimal totalAmount = 0;
            foreach (var detail in order.OrderDetails)
            {
                // Get current price of the item
                Item item = _itemRepo.GetItemById(detail.ItemID);
                if (item == null)
                    throw new ArgumentException($"Item with ID {detail.ItemID} does not exist");

                // Set unit amount to current item price
                detail.UnitAmount = item.UnitPrice;

                // Calculate total for this detail
                detail.TotalAmount = detail.Quantity * detail.UnitAmount;

                // Add to order total
                totalAmount += detail.TotalAmount;
            }

            // Set order total
            order.TotalAmount = totalAmount;

            // Set default order status
            if (string.IsNullOrEmpty(order.Status))
                order.Status = "Pending";

            // Set order date
            if (order.OrderDate == DateTime.MinValue)
                order.OrderDate = DateTime.Now;

            return _orderRepo.CreateOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            // Validate order data
            if (order.AgentID <= 0)
                throw new ArgumentException("Invalid agent ID");

            _orderRepo.UpdateOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            _orderRepo.DeleteOrder(orderId);
        }

        public List<Order> GetOrdersByAgent(int agentId)
        {
            return _orderRepo.GetOrdersByAgent(agentId);
        }
    }
}
