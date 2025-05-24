using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;

namespace TaskTracker.GenricRepo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly ApplicationDbContext _db;
    private readonly DbSet<T?> _dbSet;

    public GenericRepo(DbSet<T?> dbSet, ApplicationDbContext db)
    {
        _dbSet = dbSet;
        _db = db;
    }

    public async Task<List<T?>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}