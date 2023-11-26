using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataBaseContext _context;

        public Repository(DataBaseContext context)
        {
            _context = context;
        }

   
        public async Task<TEntity?> GetByIdAsync(string id)
        {
            return await _context.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<TEntity?> GetDeletedByIdAsync(string id)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(w=>w.IsDeleted==true).IgnoreQueryFilters()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await Save();
        }

        public async Task Update(TEntity entity)
        {

            _context.Update(entity);
            await Save();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<int> GetTrashCount()
        {
            return await _context.Set<TEntity>()
                .Where(w=>w.IsDeleted==true).IgnoreQueryFilters().CountAsync();
        }

        public async Task<TEntity?> FirstOrDefaultAsync()
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IQueryable<TEntity>> GetByQuery()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
    }
}
