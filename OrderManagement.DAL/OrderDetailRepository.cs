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
    public class OrderDetailRepository
    {
        private readonly DatabaseHelper _db;

        public OrderDetailRepository()
        {
            _db = new DatabaseHelper();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            string query = @"SELECT od.*, i.ItemName
                           FROM OrderDetail od
                           JOIN Item i ON od.ItemID = i.ItemID
                           WHERE od.OrderID = @OrderID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (DataRow row in result.Rows)
            {
                OrderDetail detail = new OrderDetail
                {
                    ID = Convert.ToInt32(row["ID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ItemID = Convert.ToInt32(row["ItemID"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitAmount = Convert.ToDecimal(row["UnitAmount"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Item = new Item
                    {
                        ItemID = Convert.ToInt32(row["ItemID"]),
                        ItemName = row["ItemName"].ToString()
                    }
                };

                orderDetails.Add(detail);
            }

            return orderDetails;
        }

        public void AddOrderDetail(OrderDetail detail)
        {
            string query = @"INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount, TotalAmount) 
                           VALUES (@OrderID, @ItemID, @Quantity, @UnitAmount, @TotalAmount)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", detail.OrderID),
                new SqlParameter("@ItemID", detail.ItemID),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@UnitAmount", detail.UnitAmount),
                new SqlParameter("@TotalAmount", detail.TotalAmount)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void UpdateOrderDetail(OrderDetail detail)
        {
            string query = @"UPDATE OrderDetail 
                           SET OrderID = @OrderID,
                               ItemID = @ItemID,
                               Quantity = @Quantity,
                               UnitAmount = @UnitAmount,
                               TotalAmount = @TotalAmount
                           WHERE ID = @ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", detail.ID),
                new SqlParameter("@OrderID", detail.OrderID),
                new SqlParameter("@ItemID", detail.ItemID),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@UnitAmount", detail.UnitAmount),
                new SqlParameter("@TotalAmount", detail.TotalAmount)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteOrderDetail(int id)
        {
            string query = "DELETE FROM OrderDetail WHERE ID = @ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            _db.ExecuteNonQuery(query, parameters);
        }
    }
}
