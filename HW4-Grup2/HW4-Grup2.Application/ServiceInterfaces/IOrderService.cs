using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.ServiceInterfaces
{
    public interface IOrderService
    {
        Task AddRangeAsync(IEnumerable<CreateOrderDto> entities);
        Task AddAsync(CreateOrderDto order);
        IQueryable<OrderDetail> GetAll();
        Task<OrderDetail> GetByIdAsync(string id);
        IQueryable<OrderDetail> GetByUserIdAsync(int id);
    }
}
