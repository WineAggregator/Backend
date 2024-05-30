using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class PhotoRepository(DatabaseContext database) : BaseRepository<Photo>(database)
{
    
}
