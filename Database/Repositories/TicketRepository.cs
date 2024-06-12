using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class TicketRepository(DatabaseContext database) : BaseRepository<Ticket>(database)
{
    public async Task<List<Ticket>> GetAllUserTickets(int userId)
    {
        var allTickets = await GetAllEntitiesAsync();
        return allTickets.Where(ticket => ticket.User.Id == userId).ToList();
    }
}
