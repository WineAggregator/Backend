using Backend.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Repositories;

public class EventPhotoRepository(DatabaseContext database) : BaseRepository<EventPhoto>(database)
{
    public async Task<List<EventPhoto>> GetAllEventPhoto(int eventId)
    {
        return await table.Where(table => table.Event.Id == eventId).ToListAsync();
    }

    public async Task DeletePhotoFromGallery(int eventId, int photoId)
    {
        var eventPhoto = await table.Where(x => x.Event.Id == eventId && x.Photo.Id == photoId).FirstOrDefaultAsync();
        if (eventPhoto is not null)
            await DeleteEntityByIdAsync(eventPhoto.Id);
    }
}
