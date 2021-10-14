using AutoMapper;
using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Application.ServiceInterfaces;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper; 
        }

        public async Task AddRangeAsync(IEnumerable<OrderDto> entities)
        {
            var orderDbObjectList = _mapper.Map<List<Order>>(entities);

            await _orderRepository.AddRangeAsync(orderDbObjectList);
        }

        public async Task AddAsync(OrderDto entity)
        {
            var orderDbObject = _mapper.Map<Order>(entity);

            await _orderRepository.AddAsync(orderDbObject);

        }
    }
}
