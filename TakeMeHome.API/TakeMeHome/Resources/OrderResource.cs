namespace TakeMeHome.API.TakeMeHome.Resources;

public class OrderResource
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string OriginCountry { get; set; }
    public string OrderDestination { get; set; }
    public DateOnly RequestDate { get; set; }
    public DateOnly DeadlineDate { get; set; }
    public int CurrentProcess { get; set; }
    public OrderStatusResource OrderStatus { get; set; }
}