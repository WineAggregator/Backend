namespace Backend.Database.Models;

public class Payment : BaseModel
{
    public required virtual User User { get; set; }
    public required virtual Event Event { get; set; }

    public bool IsConfirmed { get; set; }
    public double PaymentAmount { get; set; }
}
