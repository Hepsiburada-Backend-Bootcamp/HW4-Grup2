using HW4_Grup4.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.ServiceInterfaces
{
    public interface IOrderService
    {
        Task AddRangeAsync(IEnumerable<OrderDto> entities);
        Task AddAsync(OrderDto order);
    }
}
