using HW4_Grup2.API.Controllers.v1;
using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
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
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductController _controller;

        private List<ProductDto> products;

        public ProductControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductController(_mockProductService.Object);
            products = new List<ProductDto>()
            {
                new ProductDto
                {
                    
                    Name = "Telefon",
                    Price = 2500
                },
                new ProductDto
                {
                    
                    Name = "Bilgisayar",
                    Price = 5000
                }
            };
        }

        [Fact]
        public async void CreateProduct_ActionExecutes_ReturnOkResult()
        {
            ProductDto product = products.First();
            var result = await _controller.CreateProduct(product);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void CreateProduct_ActionExecutes_AddAsyncMethodExecute()
        {
            ProductDto product = products.First();
            _mockProductService.Setup(repo => repo.AddAsync(product));

            var result = await _controller.CreateProduct(product);
            _mockProductService.Verify(repo => repo.AddAsync(It.IsAny<ProductDto>()), Times.Once);

        }

        [Fact]
        public async void GetProducts_ActionExecutes_ReturnOkResult()
        {
            List<Product> product = null;
            _mockProductService.Setup(repo => repo.GetProducts(new FilterDto())).ReturnsAsync(product);
            var result = await _controller.GetProducts(new FilterDto());
            var OkObejectResult = Assert.IsType<OkObjectResult>(result);
            //Assert.IsType<List<Product>>(OkObejectResult.Value);
            _mockProductService.Verify(repo => repo.GetProducts(new FilterDto()), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetProductById_ActionExecutes_ReturnOkResultWithProduct(int id)
        {
            _mockProductService.Setup(repo => repo.GetProductsById(new List<int>() { id })).ReturnsAsync(products);

            var result = await _controller.GetProductById(id);
            var OkResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductDto>>(OkResult.Value);
        }


        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public async void GetProductById_ActionExecutes_ReturnBadRequest(int id)
        {
            List<ProductDto> productList = null;
            _mockProductService.Setup(repo => repo.GetProductsById(new List<int>() { id })).ReturnsAsync(productList);

            var result = await _controller.GetProductById(id);
            var OkResult = Assert.IsType<BadRequestResult>(result);
            
        }

        [Fact]
        public void Delete_ActionExecutes_ReturnNoContent()
        {
            var result = _controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public void Delete_ActionExecutes_DeleteMethodExecute(int id)
        {
            _mockProductService.Setup(repo => repo.Delete(id));
            var result = _controller.Delete(id);

            _mockProductService.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
