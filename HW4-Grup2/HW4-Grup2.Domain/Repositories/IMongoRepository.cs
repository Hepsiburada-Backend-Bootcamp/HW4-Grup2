using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW4_Grup2.Domain.Repositories
{
    public interface IMongoRepository<TEntity>  where TEntity : class
    {
        void AddAsync(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> GetByKeyAsync(object key);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition);


        //List<TEntity> Get();
        //TEntity Get(string id);
        //TEntity Create(TEntity item);
        //void Update(string id, TEntity item);
        //void Remove(TEntity item);
        //void Remove(string id);
        //Task<bool> InsertAsync(TEntity item);
        //Task<bool> Save(TEntity item);
    }
}
