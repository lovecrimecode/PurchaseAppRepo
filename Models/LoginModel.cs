using System.ComponentModel.DataAnnotations;

namespace PurchaseApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } // Use Username for login

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}