﻿using Microsoft.AspNetCore.Identity;

namespace PurchaseApp.Domain
{
    public class User : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        public string Username { get; set; }
            public string Password { get; set; }

            public void RegisterUser(string username, string password)
            {
                this.Username = username;
                this.Password = BCrypt.Net.BCrypt.HashPassword(password);
            }

            public bool Login(string username, string password)
            {
                return this.Username == username && BCrypt.Net.BCrypt.Verify(password, this.Password);
            }
        }
}
