using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.DataAccess.Context
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Find(params object[] keyValues);
        Task<List<TEntity>> GetAll();
        Task Insert(TEntity entity);
        Task InsertRange(IEnumerable<TEntity> entities);
        Task Update (TEntity entity);
        Task UpdateAll(List<TEntity> entitySet);
        Task Delete(int id);
        Task Delete(TEntity entity);
        IQueryable<TEntity> Queryable();
    }
}
