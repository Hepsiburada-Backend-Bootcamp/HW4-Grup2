using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using HW4_Grup2.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HW4_Grup2.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto product)
        {
            
             await _productService.AddAsync(product);

             return Ok();
            
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(FilterDto filter)
        {
            var result = await _productService.GetProducts(filter);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            List<int> ids = new List<int>();
            ids.Add(id);
            var result = await _productService.GetProductsById(ids);
            if (result == null)
            {
                return BadRequest();
            } 
            else
            {
                return Ok(result);
            }
            
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return NoContent();
            
        }
        
    }
}
