using Backend.Database.Enums;

namespace Backend.Database.Models;

public class Notification : BaseModel
{
    public required virtual User User { get; set; }
    public virtual Event? Event { get; set; }

    public required string Text { get; set; }
    public required NotificationType NotificationType { get; set; }
}
