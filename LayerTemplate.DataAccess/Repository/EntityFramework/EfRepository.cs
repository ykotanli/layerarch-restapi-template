using LayerTemplate.DataAccess.Context;
using LayerTemplate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.DataAccess.Repository.EntityFramework
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly personDbContext _databaseContext;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(personDbContext context)
        {
            _databaseContext = context;
            _dbSet = _databaseContext.Set<TEntity>();
        }

        public async Task Delete(int id)
        {
            var entity = _dbSet.Find(id);
            await Delete(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Deleted;
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<TEntity> Find(params object[] keyValues)
        {
            var entry = await _dbSet.FindAsync(keyValues);
            if (entry != null)
                _databaseContext.Entry(entry).State = EntityState.Detached;
            return entry;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Added;
            await _dbSet.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await Insert(entity);
            }
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAll(List<TEntity> entitySet)
        {
            if (entitySet != null)
            {
                foreach (TEntity entity in entitySet)
                {
                    //_dbSet.Attach(entity);
                    _databaseContext.Entry(entity).State = EntityState.Modified;
                    await _databaseContext.Set<TEntity>().AddAsync(entity);
                }
                _databaseContext.SaveChanges();
            }
        }

        IQueryable<TEntity> IRepository<TEntity>.Queryable()
        {
            return _dbSet;
        }
    }
}
