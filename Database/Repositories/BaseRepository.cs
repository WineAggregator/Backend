using Backend.Api.Dto;
using Backend.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Repositories;

public class BaseRepository<T>
    where T : BaseModel
{
    protected readonly DatabaseContext _database;
    protected DbSet<T> table;

    public BaseRepository(DatabaseContext database)
    {
        _database = database;
        table = _database.Set<T>();
    }

    public virtual async Task<int> CreateEntityAsync(T entity)
    {
        await table.AddAsync(entity);
        await _database.SaveChangesAsync();

        return entity.Id;
    }

    public virtual async Task<int?> DeleteEntityByIdAsync(int id)
    {
        var entity = await GetEntityByIdAsync(id);
        if (entity is null)
            return null;

        table.Remove(entity);
        await _database.SaveChangesAsync();

        return 0;
    }

    public virtual async Task<List<T>> GetAllEntitiesAsync()
    {
        return await table.ToListAsync();
    }

    public virtual async Task<T?> GetEntityByIdAsync(int id)
    {
        return await table.FindAsync(id);
    }

    public virtual async Task<int?> UpdateEntityAsync(int id, BaseUpdateDto<T> updateDto)
    {
        var entity = await GetEntityByIdAsync(id);
        if (entity is null)
            return null;

        updateDto.UpdateEntity(entity);
        await _database.SaveChangesAsync();

        return id;
    }
}
