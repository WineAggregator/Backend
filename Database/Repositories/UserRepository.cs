using Microsoft.EntityFrameworkCore;

using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class UserRepository(DatabaseContext database) : BaseRepository<User>(database)
{
    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await table.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }
}