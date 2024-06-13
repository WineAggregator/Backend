using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class EventRepository(DatabaseContext database) : BaseRepository<Event>(database)
{
    public async Task SetPreview(int eventId, string link)
    {
        var eventObject = await base.GetEntityByIdAsync(eventId);
        if (eventObject is null)
            return;

        eventObject.PreviewPhotoLink = link;
        await _database.SaveChangesAsync();
    }

    public async Task<List<Event>> GetOrganizerEvents(int organizerUserId)
    {
        return await table.Where(e => e.Organizer.Id == organizerUserId).ToListAsync();
    }
}
