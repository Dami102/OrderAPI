using Microsoft.EntityFrameworkCore;
using OrderAPI.Core.Interfaces.IRepositories;
using OrderAPI.Data;

namespace OrderAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OrderDbContext _context;
        protected readonly DbSet<T> _db;
        public GenericRepository(OrderDbContext orderDbContext)
        {
            _context = orderDbContext;
            _db = orderDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(T entities)
        {
            await _db.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteRange(T entities)
        {
            _db.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public List<T> GetAll()
        {
           return  _db.AsNoTracking().ToList();
        }

    }
}
