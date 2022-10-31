namespace TakeMeHome.API.TakeMeHome.Resources;

public class SaveOrderResource
{
    public string OrderCode { get; set; }
    public string OriginCountry { get; set; }
    public string OrderDestination { get; set; }
    public DateOnly RequestDate { get; set; }
    public DateOnly DeadlineDate { get; set; }
    public int CurrentProcess { get; set; }
}