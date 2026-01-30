
namespace OrderAPI.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(T entities);
        Task Delete(T entity);
        Task DeleteRange(T entities);
        List<T> GetAll();
        Task Update(T entity);
    }
}