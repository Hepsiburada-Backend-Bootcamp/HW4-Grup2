namespace HW4_Grup4.Domain.Repositories
{
    public interface IMongoRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);

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
