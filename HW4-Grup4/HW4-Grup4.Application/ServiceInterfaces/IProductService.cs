using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.ServiceInterfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDto product);
        Task<List<ProductDto>> GetProductsById(List<int> productIdList);
    }
}
