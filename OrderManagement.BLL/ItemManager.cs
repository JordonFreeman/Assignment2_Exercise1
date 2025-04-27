using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.DAL;
using OrderManagement.Models;

namespace OrderManagement.BLL
{
    public class ItemManager
    {
        private readonly ItemRepository _itemRepo;

        public ItemManager()
        {
            _itemRepo = new ItemRepository();
        }

        public List<Item> GetAllItems()
        {
            return _itemRepo.GetAllItems();
        }

        public Item GetItemById(int itemId)
        {
            return _itemRepo.GetItemById(itemId);
        }

        public int AddItem(Item item)
        {
            // Validate item data
            if (string.IsNullOrWhiteSpace(item.ItemName))
                throw new ArgumentException("Item name cannot be empty");

            if (item.UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero");

            if (item.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative");

            return _itemRepo.AddItem(item);
        }

        public void UpdateItem(Item item)
        {
            // Validate item data
            if (string.IsNullOrWhiteSpace(item.ItemName))
                throw new ArgumentException("Item name cannot be empty");

            if (item.UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero");

            if (item.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative");

            _itemRepo.UpdateItem(item);
        }

        public void DeleteItem(int itemId)
        {
            _itemRepo.DeleteItem(itemId);
        }

        public List<Item> GetBestSellingItems()
        {
            return _itemRepo.GetBestSellingItems();
        }

        public List<Item> GetItemsPurchasedByAgent(int agentId)
        {
            return _itemRepo.GetItemsPurchasedByAgent(agentId);
        }
    }
}