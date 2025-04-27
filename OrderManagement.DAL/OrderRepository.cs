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
    public class OrderRepository
    {
        private readonly DatabaseHelper _db;

        public OrderRepository()
        {
            _db = new DatabaseHelper();
        }

        public List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM [Order]";
            DataTable result = _db.ExecuteQuery(query);
            List<Order> orders = new List<Order>();

            foreach (DataRow row in result.Rows)
            {
                orders.Add(new Order
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    AgentID = Convert.ToInt32(row["AgentID"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                });
            }

            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            string query = "SELECT * FROM [Order] WHERE OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];

            Order order = new Order
            {
                OrderID = Convert.ToInt32(row["OrderID"]),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                AgentID = Convert.ToInt32(row["AgentID"]),
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                Status = row["Status"].ToString()
            };

            // Get order details for this order
            OrderDetailRepository detailRepo = new OrderDetailRepository();
            order.OrderDetails = detailRepo.GetOrderDetailsByOrderId(orderId);

            return order;
        }

        public int CreateOrder(Order order)
        {
            int orderId = 0;

            _db.ExecuteTransaction((connection, transaction) =>
            {
                // Insert order
                string orderQuery = @"INSERT INTO [Order] (OrderDate, AgentID, TotalAmount, Status) 
                                    VALUES (@OrderDate, @AgentID, @TotalAmount, @Status);
                                    SELECT SCOPE_IDENTITY();";

                SqlCommand orderCommand = new SqlCommand(orderQuery, connection, transaction);
                orderCommand.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                orderCommand.Parameters.AddWithValue("@AgentID", order.AgentID);
                orderCommand.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                orderCommand.Parameters.AddWithValue("@Status", order.Status);

                orderId = Convert.ToInt32(orderCommand.ExecuteScalar());

                // Insert order details
                string detailQuery = @"INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount, TotalAmount) 
                                     VALUES (@OrderID, @ItemID, @Quantity, @UnitAmount, @TotalAmount)";

                foreach (var detail in order.OrderDetails)
                {
                    SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction);
                    detailCommand.Parameters.AddWithValue("@OrderID", orderId);
                    detailCommand.Parameters.AddWithValue("@ItemID", detail.ItemID);
                    detailCommand.Parameters.AddWithValue("@Quantity", detail.Quantity);
                    detailCommand.Parameters.AddWithValue("@UnitAmount", detail.UnitAmount);
                    detailCommand.Parameters.AddWithValue("@TotalAmount", detail.TotalAmount);

                    detailCommand.ExecuteNonQuery();
                }
            });

            return orderId;
        }

        public void UpdateOrder(Order order)
        {
            string query = @"UPDATE [Order] 
                           SET OrderDate = @OrderDate,
                               AgentID = @AgentID,
                               TotalAmount = @TotalAmount,
                               Status = @Status
                           WHERE OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", order.OrderID),
                new SqlParameter("@OrderDate", order.OrderDate),
                new SqlParameter("@AgentID", order.AgentID),
                new SqlParameter("@TotalAmount", order.TotalAmount),
                new SqlParameter("@Status", order.Status)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteOrder(int orderId)
        {
            _db.ExecuteTransaction((connection, transaction) =>
            {
                // Delete order details first due to foreign key constraint
                string detailQuery = "DELETE FROM OrderDetail WHERE OrderID = @OrderID";
                SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction);
                detailCommand.Parameters.AddWithValue("@OrderID", orderId);
                detailCommand.ExecuteNonQuery();

                // Then delete the order
                string orderQuery = "DELETE FROM [Order] WHERE OrderID = @OrderID";
                SqlCommand orderCommand = new SqlCommand(orderQuery, connection, transaction);
                orderCommand.Parameters.AddWithValue("@OrderID", orderId);
                orderCommand.ExecuteNonQuery();
            });
        }

        public List<Order> GetOrdersByAgent(int agentId)
        {
            string query = "SELECT * FROM [Order] WHERE AgentID = @AgentID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AgentID", agentId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);
            List<Order> orders = new List<Order>();

            foreach (DataRow row in result.Rows)
            {
                orders.Add(new Order
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    AgentID = Convert.ToInt32(row["AgentID"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                });
            }

            return orders;
        }
    }
}
