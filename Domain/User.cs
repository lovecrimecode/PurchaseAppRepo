using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PurchaseApp.Domain
{
    public class User : IdentityUser
    {
        // Additional properties can be added here if needed
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /*public void RegisterUser(string password)
        {
            this.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Login(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, this.PasswordHash);
        }*/
    }
}