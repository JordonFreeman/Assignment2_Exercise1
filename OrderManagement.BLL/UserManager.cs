using System;
using System.Collections.Generic;
using OrderManagement.DAL;
using OrderManagement.Models;

namespace OrderManagement.BLL
{
    public class UserManager
    {
        private readonly UserRepository _userRepo;

        public UserManager()
        {
            _userRepo = new UserRepository();
        }

        public User AuthenticateUser(string username, string password)
        {
            // In a real application, we would hash the password
            return _userRepo.Authenticate(username, password);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return _userRepo.GetUserById(userId);
        }

        public void AddUser(User user)
        {
            // Validate user data
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException("Username cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email cannot be empty");

            // In a real application, we would hash the password
            _userRepo.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            // Validate user data
            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentException("Username cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password cannot be empty");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email cannot be empty");

            _userRepo.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepo.DeleteUser(userId);
        }
    }
}