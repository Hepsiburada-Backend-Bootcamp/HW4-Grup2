using HW4_Grup2.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW4_Grup2.Infrastructure.Repositories
{
    public class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> _items;

        public MongoRepository(IMongoDbContext context)
        {
            _items = context.db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void AddAsync(TEntity entity)
        {
            _items.InsertOne(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _items.AsQueryable();
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
            => _items.Find(condition).FirstOrDefaultAsync();

        public virtual Task<TEntity> GetByKeyAsync(object key)
        {
            return _items.Find(FilterId(key)).SingleOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        { 
            return GetAll().Where(condition);
        }
        

        protected FilterDefinition<TEntity> FilterId(object key)
        {
            if (key is Guid guidKey)
            {
                return Builders<TEntity>.Filter.Eq(new StringFieldDefinition<TEntity, Guid>("_id"), guidKey);
            }

            return Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(key.ToString()));
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
