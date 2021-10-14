using HW4_Grup4.Application.ServiceInterfaces;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using System;

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
                User = new User { Id = Guid.NewGuid(), LastName = "Birinci", Name = "Ali" },
                Product = new Product { Id = Guid.NewGuid(), Name = "product1", Price = 772 },
            };

            _orderDetailMongoRepository.AddAsync(order);
        }
    }
}
