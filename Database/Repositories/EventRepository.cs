using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class EventRepository(DatabaseContext database) : BaseRepository<Event>(database)
{

}
