namespace TakeMeHome.API.TakeMeHome.Domain.Models;

public class OrderStatus
{
    public string Id { get; set; }
    public string Status { get; set; }
    
    //Relationships
    public IList<Order> Orders { get; set; } = new List<Order>();
}