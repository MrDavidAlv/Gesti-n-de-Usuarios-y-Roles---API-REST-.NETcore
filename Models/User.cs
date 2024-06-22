// User.cs
using empleadosFYMtech.Models;
    public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}

