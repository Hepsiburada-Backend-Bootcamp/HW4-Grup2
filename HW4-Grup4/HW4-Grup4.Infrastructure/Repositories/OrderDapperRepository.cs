using Dapper;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class OrderDapperRepository : DapperRepository<Order>, IOrderDapperRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;
        public OrderDapperRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        //public async Task<List<User>> GetUsers()
        //{
        //    using IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring));

        //    var query = "SELECT * FROM Users";

        //    var userList = await db.QueryAsync<User>(query);

        //    return userList.ToList();
        //}

        public async Task<int> AddOrderAsync(Order order)
        {            
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var orderAddQuery = $"Insert into orders (TotalPrice, Address, CreatedAt, OrderNumber, UserId)" +
                $" Values({order.TotalPrice}, '{order.Address}', GETDATE(), {order.Id}, {order.User.Id} )";

                await db.ExecuteAsync(orderAddQuery);

                var getMaxOrderIdQuery = "select max(id) from orders";

                var getMaxOrderId = await db.QueryFirstAsync<int>(getMaxOrderIdQuery);

                var orderItemAddQuery = string.Empty;

                foreach (var item in order.OrderItems)
                {
                    orderItemAddQuery += $" Insert into orderItems (OrderId, ProductId, Quantity, ItemPrice)" +
                    $" Values({getMaxOrderId}, {item.ProductId}, {item.Quantity}, {item.ItemPrice})";

                    orderAddQuery += orderItemAddQuery;
                }             

                await db.ExecuteAsync(orderItemAddQuery);

                return getMaxOrderId;
            }
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
        {            
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var query = $"Select * from orderItems where OrderId = { orderId }";

                var result = await db.QueryAsync<OrderItem>(query);

                return result.ToList();
            }
        }
    }
}
