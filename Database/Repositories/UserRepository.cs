using System.Data.Entity;

using Backend.Database.Models;

namespace Backend.Database.Repositories;

public class UserRepository(DatabaseContext database) : BaseRepository<User>(database)
{
    public User? GetUserByEmail(string email)
    {
        var user = table.Where( user => user.Email == email).FirstOrDefault();
        return user;
    }
}