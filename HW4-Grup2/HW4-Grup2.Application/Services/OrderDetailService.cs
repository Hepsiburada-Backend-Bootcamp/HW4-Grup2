using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using System;

namespace HW4_Grup2.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        //private readonly IOrderMongoRepository _orderDetailMongoRepository;
        ////private readonly IOrderMongoRepository _orderDetailMongoRepository;

        //public OrderDetailService(IOrderMongoRepository orderDetailMongoRepository)
        //{
        //    _orderDetailMongoRepository = orderDetailMongoRepository;
        //}

        //public void InsertOrderDetailToMongoDb(OrderDetail orderDetail)
        //{



        //    OrderDetail order = new OrderDetail
        //    {
        //        Order = new Order { Id = 1, Address = "Üsküdar", CreatedAt = DateTime.Now, TotalPrice = 661 },
        //        User = new User { Id =1, LastName = "Birinci", Name = "Ali" },
        //        Product = new Product { Id = 1, Name = "product1", Price = 772 },
        //    };

        //    //_orderDetailMongoRepository.AddAsync(order);
        //}
        public void InsertOrderDetailToMongoDb(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
