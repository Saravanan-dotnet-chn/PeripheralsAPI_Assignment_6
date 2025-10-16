using PeripheralsAPI_Assignment_6.Models;

namespace PeripheralsAPI_Assignment_6.Repositories
{
    public interface IPeripheralRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}