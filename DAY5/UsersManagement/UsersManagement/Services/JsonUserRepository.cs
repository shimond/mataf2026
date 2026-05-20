using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using UsersManagement.Contracts;
using UsersManagement.Models;

namespace UsersManagement.Services
{
    internal class JsonUserRepository : IUserRepository
    {
        private readonly string _filePath = "users.json";
        public List<UserInfo> LoadUsers()
        {
            if(!File.Exists(_filePath))
            {
                return new List<UserInfo>();
            }
            
            var jsonFromFile = File.ReadAllText(_filePath);
            try
            {
                var users = JsonSerializer.Deserialize<List<UserInfo>>(jsonFromFile);
                if (users == null)
                {
                    return new List<UserInfo>();
                }
                return users;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                File.Copy(_filePath, _filePath + ".bak", true);
                return new List<UserInfo>();
            }
        }

        public void SaveUsers(List<UserInfo> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(_filePath, json);
        }
    }
}
