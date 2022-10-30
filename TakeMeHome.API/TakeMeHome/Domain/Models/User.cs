namespace TakeMeHome.API.TakeMeHome.Domain.Models;

public class User
{
    public int    Id { get; set; } 
    public string FullName { get; set; }    
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string IdNumber { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public int Points { get; set; }
    public int Rating { get; set; }
    public string Phone { get; set; }
}