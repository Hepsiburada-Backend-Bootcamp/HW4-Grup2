using HW4_Grup2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup2.Domain.Repositories
{
    public interface IProductDapperRepository : IDapperRepository<Product>
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProductsById(List<int> productIdList);
    }
}
