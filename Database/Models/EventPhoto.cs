using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

public class EventPhoto : BaseModel
{
    public virtual Event? Event { get; set; }
    public virtual Photo? Photo { get; set; }
}