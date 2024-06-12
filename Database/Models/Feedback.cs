namespace Backend.Database.Models;

public class Feedback : BaseModel
{
    public required virtual User User { get; set; }
    public required virtual Event Event { get; set; }

    public required int Rating { get; set; }
    public required string Text { get; set; }
}
