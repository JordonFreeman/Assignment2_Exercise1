using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OrderManagement.Models;

namespace OrderManagement.DAL
{
    public class UserRepository
    {
        private readonly DatabaseHelper _db;

        public UserRepository()
        {
            _db = new DatabaseHelper();
        }

        public User Authenticate(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password AND IsLocked = 0";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", password)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                UserName = row["UserName"].ToString(),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                IsLocked = Convert.ToBoolean(row["IsLocked"]),
                Role = row["Role"].ToString(),
                LastLogin = Convert.ToDateTime(row["LastLogin"])
            };
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM Users";
            DataTable result = _db.ExecuteQuery(query);
            List<User> users = new List<User>();

            foreach (DataRow row in result.Rows)
            {
                users.Add(new User
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    UserName = row["UserName"].ToString(),
                    Email = row["Email"].ToString(),
                    Password = row["Password"].ToString(),
                    IsLocked = Convert.ToBoolean(row["IsLocked"]),
                    Role = row["Role"].ToString(),
                    LastLogin = Convert.ToDateTime(row["LastLogin"])
                });
            }

            return users;
        }

        public User GetUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId)
            };

            DataTable result = _db.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                UserName = row["UserName"].ToString(),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                IsLocked = Convert.ToBoolean(row["IsLocked"]),
                Role = row["Role"].ToString(),
                LastLogin = Convert.ToDateTime(row["LastLogin"])
            };
        }

        public void AddUser(User user)
        {
            string query = @"INSERT INTO Users (UserName, Email, Password, IsLocked, Role, LastLogin) 
                           VALUES (@UserName, @Email, @Password, @IsLocked, @Role, @LastLogin)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@IsLocked", user.IsLocked),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@LastLogin", user.LastLogin)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void UpdateUser(User user)
        {
            string query = @"UPDATE Users 
                           SET UserName = @UserName,
                               Email = @Email,
                               Password = @Password,
                               IsLocked = @IsLocked,
                               Role = @Role,
                               LastLogin = @LastLogin
                           WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", user.UserID),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@IsLocked", user.IsLocked),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@LastLogin", user.LastLogin)
            };

            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", userId)
            };

            _db.ExecuteNonQuery(query, parameters);
        }
    }
}