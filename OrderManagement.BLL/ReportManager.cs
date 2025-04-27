using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.DAL;
using OrderManagement.Models;

namespace OrderManagement.BLL
{
    public class ReportManager
    {
        private readonly OrderRepository _orderRepo;
        private readonly AgentRepository _agentRepo;
        private readonly ItemRepository _itemRepo;

        public ReportManager()
        {
            _orderRepo = new OrderRepository();
            _agentRepo = new AgentRepository();
            _itemRepo = new ItemRepository();
        }

        public List<Item> GetBestSellingItems()
        {
            return _itemRepo.GetBestSellingItems();
        }

        public List<Item> GetItemsPurchasedByAgent(int agentId)
        {
            return _itemRepo.GetItemsPurchasedByAgent(agentId);
        }

        public List<Agent> GetAgentsWhoOrderedItem(int itemId)
        {
            // This would require a new query in the repository layer
            // For now, let's return an empty list
            return new List<Agent>();
        }

        public Order GenerateOrderReport(int orderId)
        {
            // Get complete order details
            Order order = _orderRepo.GetOrderById(orderId);

            if (order == null)
                throw new ArgumentException($"Order with ID {orderId} does not exist");

            // Get agent information
            Agent agent = _agentRepo.GetAgentById(order.AgentID);

            if (agent == null)
                throw new ArgumentException($"Agent with ID {order.AgentID} does not exist");

            // Add additional information for report
            // In a real application, we might create a special OrderReport class with all required information

            return order;
        }
    }
}
