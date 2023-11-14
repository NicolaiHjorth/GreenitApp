using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Models;
using EfcDataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IList<User> users;
        private readonly PostContext context;
        
        public AuthService(PostContext context)
        {
            this.context = context;
        }
        
        public async Task<User> ValidateUser(string userName, string password)
        {
            Console.WriteLine("SWAG1");

            User existingUser = await context.Users
                .FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(userName.ToLower()));


            Console.WriteLine(existingUser);
            Console.WriteLine("SWAG");

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception("Password mismatch");
            }

            Console.WriteLine(existingUser);

            return existingUser;
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
