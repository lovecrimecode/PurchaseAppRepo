/*namespace PurchaseApp.Models
{
    public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public void RegisterUser(string name, string password)
    {
        this.Name = name;
        this.Password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Login(string name, string password)
    {
        return this.Name == name && BCrypt.Net.BCrypt.Verify(password, this.Password);
    }
}}*/