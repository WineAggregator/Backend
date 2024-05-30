using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

public class Event : BaseModel
{
    public required string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public EventType EventType { get; set; } = 0;
    public DateTime DateFrom { get; set; } = DateTime.MinValue;
    public DateTime DateTo { get; set; } = DateTime.MaxValue;

    public Photo? PreviewPhotoId { get; set; }
    public required Organizer Organizer { get; set; }
}