using HW4_Grup2.API.Controllers.v1;
using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
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
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IOrderDetailService> _mockOrderDetailService;
        private readonly UserController _controller;
        private List<UserDto> usersDto;
        public UserControllerTest()
        {
            _mockUserService = new Mock<IUserService>();
            _mockOrderDetailService = new Mock<IOrderDetailService>();
            _controller = new UserController(_mockUserService.Object, _mockOrderDetailService.Object);

            usersDto = new List<UserDto>()
            {
                new UserDto
                {
                    Id = 1,
                    Name = "İlker",
                    LastName = "Baltacı"
                },
                new UserDto
                {
                    Id = 2,
                    Name = "Ali",
                    LastName = "Birinci"
                }
            };
        }

        [Fact]
        public async void GetUsersAsync_ResultIsNotNull_ReturnOkResult()
        {
            _mockUserService.Setup(service => service.GetAllAsync()).ReturnsAsync(usersDto);

            var result = await _controller.GetUsersAsync();
            var OkResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<UserDto>>(OkResult.Value);
        }

        [Fact]
        public async void GetUsersAsync_ResultIsNull_ReturnNotFound()
        {
            List<UserDto> users = null;
            _mockUserService.Setup(service => service.GetAllAsync()).ReturnsAsync(users);

            var result = await _controller.GetUsersAsync();
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public async void GetUserByIdAsync_ResultIsNotNull_ReturnOkResult(int id)
        {
            UserDto user = usersDto.Find(x => x.Id == id);
            
            _mockUserService.Setup(service => service.GetUserById(id)).ReturnsAsync(user);

            var result = await _controller.GetUserByIdAsync(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(3)]
        public async void GetUserByIdAsync_ResultIsNull_ReturnNotFound(int id)
        {
            UserDto user = usersDto.Find(x => x.Id == id);

            _mockUserService.Setup(service => service.GetUserById(id)).ReturnsAsync(user);

            var result = await _controller.GetUserByIdAsync(id);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
