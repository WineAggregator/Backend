using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

public class Organizer : BaseModel
{
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public required User User { get; set; }
}