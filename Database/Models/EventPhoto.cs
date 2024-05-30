using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

public class EventPhoto : BaseModel
{
    public Event? Event { get; set; }
    public Photo? Photo { get; set; }

    [ForeignKey("Event")]
    public int EventId { get; set; }

    [ForeignKey("Photo")]
    public int PhotoId { get; set; }
}