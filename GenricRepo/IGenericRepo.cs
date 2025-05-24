using Abp.Domain.Entities;

namespace TaskTracker.GenricRepo;

public interface IGenericRepo<T> where T : class
{
    Task<List<T?>> GetAllAsync();
    
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    
}