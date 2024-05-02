namespace Backend.Database.Models;

public class Event : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public double Price { get; set; }
    public string Link { get; set; }
    public EventType EventType { get; set; }
}