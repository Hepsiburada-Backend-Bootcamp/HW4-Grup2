using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.ServiceInterfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDto product);
        Task<List<ProductDto>> GetProductsById(List<int> productIdList);
        Task<List<Product>> GetProducts(FilterDto filter);
        Task<List<Product>> GetProductsByIdProduct(List<int> productIdList);
        void Delete(int id);
    }
}
