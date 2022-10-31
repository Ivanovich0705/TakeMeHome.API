using System.ComponentModel.DataAnnotations;

namespace TakeMeHome.API.TakeMeHome.Resources;

public class SaveOrderResource
{
    [Required]
    [MaxLength(30)]
    public string OrderCode { get; set; }
    
    [Required]
    public string OriginCountry { get; set; }
    
    [Required]
    public string OrderDestination { get; set; }
    
    [Required]
    public DateOnly RequestDate { get; set; }
    
    [Required]
    public DateOnly DeadlineDate { get; set; }
    
    public int CurrentProcess { get; set; }
    
    [Required]
    public int OrderStatusId { get; set; }
}