using HW4_Grup4.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4_Grup4.Domain.Repositories
{
    public interface IOrderDapperRepository : IDapperRepository<Order>
    {
        //Task<List<User>> GetUsers();
        Task<int> AddOrderAsync(Order order);
        Task<List<OrderItem>> GetOrderItemsAsync(int orderId);
    }
}
