using AutoMapper;
using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Application.ServiceInterfaces;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW4_Grup4.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDapperRepository _orderDapperRepository;
        private readonly IOrderMongoRepository _orderMongoRepository;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository
            , IOrderDapperRepository orderDapperRepository
            , IOrderMongoRepository orderMongoRepository
            , IMapper mapper
            , IUserService userService
            , IProductService productService)
        {
            _orderRepository = orderRepository;
            _orderDapperRepository = orderDapperRepository;
            _mapper = mapper;
            _orderMongoRepository = orderMongoRepository;
            _userService = userService;
            _productService = productService;
        }

        public async Task AddRangeAsync(IEnumerable<OrderDto> entities)
        {
            var orderDbObjectList = _mapper.Map<List<Order>>(entities);

            await _orderRepository.AddRangeAsync(orderDbObjectList);
        }

        public async Task AddAsync(OrderDto entity)
        {
            //var orderItemList = new List<OrderItem>();

            //var orderItemObjectList = _mapper.Map<List<OrderItem>>(entity.OrderItems);

            var orderItemObjectListWithoutMapper = new List<OrderItem>();

            foreach (var item in entity.OrderItems)
            {
                var tmpOrderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    ItemPrice = item.Price,
                    Quantity = item.Quantity
                };

                orderItemObjectListWithoutMapper.Add(tmpOrderItem);
            }

            var order = new Order
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Address = entity.Address,
                CreatedAt = DateTime.Now,
                OrderItems = orderItemObjectListWithoutMapper,
                OrderNumber = entity.OrderNumber,
                TotalPrice = entity.TotalPrice,
                User = new User { Id = entity.UserId }
            };

            //OrderDetailService.instance.WriteDataToMongo(entity)

            var orderId = await _orderDapperRepository.AddOrderAsync(order);

            order.Id = orderId;

            var result = await AddOrderInformationToMongoDb(order);
        }

        public async Task<bool> AddOrderInformationToMongoDb(Order order)
        {
            var user = await _userService.GetUserById(order.UserId);
            var orderItems = await _orderDapperRepository.GetOrderItemsAsync(order.Id);
            var productIds = orderItems.Select(x => x.ProductId).ToList();
            var productItems = await _productService.GetProductsById(productIds);

            foreach (var item in orderItems)
            {
                var tmpProduct = productItems.Where(x => x.Id == item.ProductId).FirstOrDefault();
                item.Product = new Product { Id = tmpProduct.Id, Name = tmpProduct.Name, Price = tmpProduct.Price };
            }

            OrderDetail orderDetail = new OrderDetail
            {
                Order = new Order
                {
                    Address = order.Address,
                    CreatedAt = order.CreatedAt,
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    TotalPrice = order.TotalPrice,
                    UserId = order.UserId,
                    User = new User { Id = user.Id, LastName = user.LastName, Name = user.Name },
                    OrderItems = orderItems
                }
            };

            _orderMongoRepository.AddAsync(orderDetail);

            return true;
        }

    }
}
