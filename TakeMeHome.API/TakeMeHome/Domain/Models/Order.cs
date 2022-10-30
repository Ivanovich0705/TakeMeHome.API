namespace TakeMeHome.API.TakeMeHome.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string OriginCountry { get; set; }
    public string OrderDestination { get; set; }
    public DateOnly RequestDate { get; set; }
    public DateOnly DeadlineDate { get; set; }
    public int CurrentProcess { get; set; }

    //Relationships
    public int UserId  { get; set; }
    public User User { get; set; }
    
    public int ClientId { get; set; }
    public User Client { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int StatusId { get; set; }
    public OrderStatus Status { get; set; }
    
    public int CommentId { get; set; }
    public Comment Comment { get; set; }
}