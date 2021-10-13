using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Domain.Services;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailMongoRepository _orderDetailMongoRepository;

        public OrderDetailService(IOrderDetailMongoRepository orderDetailMongoRepository)
        {
            _orderDetailMongoRepository = orderDetailMongoRepository;
        }

        public void InsertOrderDetailToMongoDb(OrderDetail orderDetail)
        {
            OrderDetail order = new OrderDetail
            {
                Order = new Order { Id = Guid.NewGuid(), Address = "Üsküdar", CreatedAt = DateTime.Now, TotalPrice = 661 },
                User = new User { Id = Guid.NewGuid(), Email = "qweqweqw@gmail.com", IsActive = true, LastName = "Birinci", Name = "Ali" },
                Product = new Product { Id = Guid.NewGuid(), Name = "product1", Price = 772 },
                Product23 = "wqeqwe"
            };

            _orderDetailMongoRepository.AddAsync(order);
        }
    }
}
