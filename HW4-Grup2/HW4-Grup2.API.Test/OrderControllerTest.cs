using HW4_Grup2.API.Controllers.v1;
using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HW4_Grup2.API.Test
{
    public class OrderControllerTest
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly OrderController _controller;

        private List<CreateOrderDto> orders;
        private List<OrderDetail> orderDetails;

        public OrderControllerTest()
        {
            _mockOrderService = new Mock<IOrderService>();
            _controller = new OrderController(_mockOrderService.Object);

            orders = new List<CreateOrderDto>()
            {
                new CreateOrderDto
                {
                    TotalPrice = 1000,
                    Address = "Ihlamurkuyu",
                    OrderItems = new List<OrderItemDto>()
                    {
                        new OrderItemDto
                        {
                            ProductId = 1,
                            Quantity = 3,
                            Price = 500,
                            TotalPrice = 1500
                        }
                    },
                    UserId = 3
                }
            };

            orderDetails = new List<OrderDetail>() {
                new OrderDetail
                {
                    Id = "1234",
                    TotalPrice = 1000,
                    Address = "Taşkent Sk.",
                    CreatedAt = DateTime.Now
                }
            };
        }

        [Fact]
        public void CreateOrder_ActionExecutes_ReturnOkResult()
        {
            var result = _controller.CreateOrder(orders.First());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void CreateOrder_ThrowException_ReturnBadRequest()
        {
            _mockOrderService.Setup(service => service.AddAsync(orders.First())).Throws(new Exception("Exception occured"));

            var result = _controller.CreateOrder(orders.First());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Get_ResultIsNotNull_ReturnOkResult()
        {
            _mockOrderService.Setup(service => service.GetAll()).Returns(orderDetails.AsQueryable());

            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ResultIsNull_ReturnNotFound()
        {

            IQueryable<OrderDetail> orderDetails = Enumerable.Empty<OrderDetail>().AsQueryable();

            _mockOrderService.Setup(service => service.GetAll()).Returns(orderDetails);

            var result = _controller.Get();
            Assert.IsType<NotFoundResult>(result);

        }

        [Theory]
        [InlineData("1234")]
        public async void Get_IdIsNotNullResult_ReturnOkResult(string id)
        {
            var orderDetail = orderDetails.SingleOrDefault(x => x.Id == id);
            _mockOrderService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(orderDetail);

            var result = await _controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
        }


        [Theory]
        [InlineData("12345")]
        public async void Get_IdIsNullResult_ReturnNotFound(string id)
        {
            var orderDetail = orderDetails.SingleOrDefault(x => x.Id == id);
            _mockOrderService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(orderDetail);

            var result = await _controller.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public void GetOrderByUserId_IdIsNotNullResult_ReturnOkResult(int id)
        {
            _mockOrderService.Setup(service => service.GetByUserIdAsync(id)).Returns(orderDetails.AsQueryable);

            var result = _controller.GetOrderByUserId(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public void GetOrderByUserId_IdIsNullResult_ReturnNotFound(int id)
        {
            IQueryable<OrderDetail> orderDetails = Enumerable.Empty<OrderDetail>().AsQueryable();

            _mockOrderService.Setup(service => service.GetByUserIdAsync(id)).Returns(orderDetails);

            var result = _controller.GetOrderByUserId(id);

            Assert.IsType<NotFoundResult>(result);
        }

    }
}
