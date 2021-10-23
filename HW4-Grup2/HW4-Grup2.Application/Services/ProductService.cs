using AutoMapper;
using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDapperRepository _productDapperRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductDapperRepository productDapperRepository, IMapper mapper, IProductRepository productRepository)
        {
            _productDapperRepository = productDapperRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDto entity)
        {
            var productDbObject = _mapper.Map<Product>(entity);
            await _productDapperRepository.AddProductAsync(productDbObject);
        }

        public async Task<List<Product>> GetProducts(FilterDto filter)
        {
            var result = await _productRepository.Where(x =>
                    (String.IsNullOrWhiteSpace(filter.Name) || x.Name.ToLower().Contains(filter.Name.ToLower()))
                    && (filter.MinPrice == null || x.Price > filter.MinPrice)
                    && (filter.MaxPrice == null || x.Price < filter.MaxPrice));

            return result.OrderBy(x => x.Name).ThenBy(x => x.Price).Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
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
