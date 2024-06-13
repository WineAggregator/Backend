using Backend.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Repositories;

public class TicketRepository(DatabaseContext database) : BaseRepository<Ticket>(database)
{
    public async Task<List<Ticket>> GetAllUserTickets(int userId)
    {
        return await table.Where(ticket => ticket.User.Id == userId).ToListAsync();
    }

    public async Task ActivateTicket(int ticketId)
    {
        var ticket = await GetEntityByIdAsync(ticketId);
        if (ticket is null)
            return;

        ticket!.IsActivated = true;

        await _database.SaveChangesAsync();
    }
}
