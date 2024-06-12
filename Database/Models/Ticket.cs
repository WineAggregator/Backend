namespace Backend.Database.Models;

public class Ticket : BaseModel
{
    public required virtual User User { get; set; }
    public required virtual Event Event { get; set; }
    public required bool IsActivated { get; set; }
}
