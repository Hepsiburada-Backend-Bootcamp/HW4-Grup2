using System.Threading.Tasks;

namespace HW4_Grup2.Domain.Repositories
{
    public interface IDapperRepository<TEntity> where TEntity : class // : IRepository<TEntity> where TEntity : class
    {
        TEntity GetByIdAsync(string query);
    }
}
