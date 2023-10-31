using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Models;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IList<User> users;

        public AuthService()
        {
            // Load users from the JSON file when the AuthService is constructed.
            users = LoadUsersFromJsonFile("data.json");
        }

        private IList<User> LoadUsersFromJsonFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    var jsonData = JsonSerializer.Deserialize<JsonData>(json);

                    if (jsonData != null && jsonData.Users != null)
                    {
                        return jsonData.Users;
                    }
                    else
                    {
                        throw new Exception("Invalid JSON format or missing 'Users' data.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading users from JSON file: {ex.Message}", ex);
            }
        }

        public Task<User> ValidateUser(string username, string password)
        {
            User? existingUser = users.FirstOrDefault(u =>
                u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception("Password mismatch");
            }
            return Task.FromResult(existingUser);
        }

        public Task RegisterUser(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ValidationException("Username cannot be null");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ValidationException("Password cannot be null");
            }
            // Do more user info validation here

            // Save to persistence instead of the list

            users.Add(user);

            return Task.CompletedTask;
        }
    }
}
