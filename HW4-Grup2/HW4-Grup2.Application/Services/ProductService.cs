using AutoMapper;
using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDapperRepository _productDapperRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductDapperRepository productDapperRepository, IMapper mapper)
        {
            _productDapperRepository = productDapperRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDto entity)
        {
            var productDbObject = _mapper.Map<Product>(entity);
            await _productDapperRepository.AddProductAsync(productDbObject);
        }

        public async Task<List<Product>> GetProducts()
        {
            var result = await _productDapperRepository.GetProductsAsync();

            return result;
        }

        public async Task<List<ProductDto>> GetProductsById(List<int> productIdList)
        { 
            var result = await _productDapperRepository.GetProductsById(productIdList);
            var productDtoList = _mapper.Map<List<ProductDto>>(result);
            return productDtoList;
        }

        public async Task<List<Product>> GetProductsByIdProduct(List<int> productIdList)
        {
            var result = await _productDapperRepository.GetProductsById(productIdList);
            return result;
        }

        public void Delete(int id)
        {
            _productDapperRepository.Delete(id);
        }
    }
}
