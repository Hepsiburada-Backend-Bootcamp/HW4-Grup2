using HW4_Grup4.Domain.Repositories;
using MongoDB.Driver;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> _items;

        public MongoRepository(IMongoDbContext context)
        {
            _items = context.db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void AddAsync(TEntity entity)
        {
            _items.InsertOne(entity);
        }

        //public List<TEntity> Get()
        //{
        //    return _items.Find(x => true).ToList();
        //}

        //public TEntity Get(string id)
        //{
        //    return _items.Find(book => book.Id == id).FirstOrDefault();
        //}

        //public TEntity Create(TEntity item)
        //{
        //    _items.InsertOne(item);
        //    return item;
        //}

        //public void Update(string id, TEntity item) =>
        //    _items.ReplaceOne(item => item.Id == id, item);

        //public void Remove(TEntity item) =>
        //    _items.DeleteOne(item => item.Id == item.Id);

        //public void Remove(string id) =>
        //    _items.DeleteOne(item => item.Id == id);

        //public virtual async Task<bool> InsertAsync(TEntity item)
        //{
        //    await _items.InsertOneAsync(item);
        //    return true;
        //}

        //public virtual async Task<bool> Save(TEntity item)
        //{
        //    bool result = false;
        //    result = await InsertAsync(item);
        //    return result;
        //}

        //public Task<TEntity> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}      

        //public Task AddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    throw new NotImplementedException();
        //}

        //public TEntity Update(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
