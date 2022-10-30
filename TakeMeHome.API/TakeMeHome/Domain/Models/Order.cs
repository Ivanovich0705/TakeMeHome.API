namespace TakeMeHome.API.TakeMeHome.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public int OrderStatusId { get; set; }
    
}