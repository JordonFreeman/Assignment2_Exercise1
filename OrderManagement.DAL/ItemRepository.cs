using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OrderManagement.Models;

namespace OrderManagement.DAL
{
    public class ItemRepository
    {
        private readonly DatabaseHelper _db;

        public ItemRepository()
        {
            _db = new DatabaseHelper();
        }

        public List<Item> GetAllItems()
        {
            string query = "SELECT * FROM Item";
            DataTable result = _db.ExecuteQuery(query);
            List<Item> items = new List<Item>();

            foreach (DataRow row in result.Rows)
            {
                items.Add(new Item
                {
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    ItemName = row["ItemName"].ToString(),
                    Size = row["Size"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                    Description = row["Description"].ToString()
                });
            }

            return items;
        }

        public Item GetItemById(int itemId)
        {
            string query = "SELECT * FROM Item WHERE ItemID = @ItemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", itemId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new Item
            {
                ItemID = Convert.ToInt32(row["ItemID"]),
                ItemName = row["ItemName"].ToString(),
                Size = row["Size"].ToString(),
                UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                Description = row["Description"].ToString()
            };
        }

        public int AddItem(Item item)
        {
            string query = @"INSERT INTO Item (ItemName, Size, UnitPrice, StockQuantity, Description) 
                            VALUES (@ItemName, @Size, @UnitPrice, @StockQuantity, @Description);
                            SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemName", item.ItemName),
                new SqlParameter("@Size", item.Size),
                new SqlParameter("@UnitPrice", item.UnitPrice),
                new SqlParameter("@StockQuantity", item.StockQuantity),
                new SqlParameter("@Description", item.Description)
            };

            object result = _db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public void UpdateItem(Item item)
        {
            string query = @"UPDATE Item 
                           SET ItemName = @ItemName,
                               Size = @Size,
                               UnitPrice = @UnitPrice,
                               StockQuantity = @StockQuantity,
                               Description = @Description
                           WHERE ItemID = @ItemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", item.ItemID),
                new SqlParameter("@ItemName", item.ItemName),
                new SqlParameter("@Size", item.Size),
                new SqlParameter("@UnitPrice", item.UnitPrice),
                new SqlParameter("@StockQuantity", item.StockQuantity),
                new SqlParameter("@Description", item.Description)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteItem(int itemId)
        {
            string query = "DELETE FROM Item WHERE ItemID = @ItemID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ItemID", itemId)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public List<Item> GetBestSellingItems()
        {
            string query = @"SELECT i.*, SUM(od.Quantity) as TotalQuantitySold
                           FROM Item i
                           JOIN OrderDetail od ON i.ItemID = od.ItemID
                           GROUP BY i.ItemID, i.ItemName, i.Size, i.UnitPrice, i.StockQuantity, i.Description
                           ORDER BY TotalQuantitySold DESC";

            DataTable result = _db.ExecuteQuery(query);
            List<Item> items = new List<Item>();

            foreach (DataRow row in result.Rows)
            {
                items.Add(new Item
                {
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    ItemName = row["ItemName"].ToString(),
                    Size = row["Size"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                    Description = row["Description"].ToString()
                });
            }

            return items;
        }

        public List<Item> GetItemsPurchasedByAgent(int agentId)
        {
            string query = @"SELECT DISTINCT i.*
                           FROM Item i
                           JOIN OrderDetail od ON i.ItemID = od.ItemID
                           JOIN [Order] o ON od.OrderID = o.OrderID
                           WHERE o.AgentID = @AgentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentID", agentId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);
            List<Item> items = new List<Item>();

            foreach (DataRow row in result.Rows)
            {
                items.Add(new Item
                {
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    ItemName = row["ItemName"].ToString(),
                    Size = row["Size"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                    Description = row["Description"].ToString()
                });
            }

            return items;
        }
    }

}
