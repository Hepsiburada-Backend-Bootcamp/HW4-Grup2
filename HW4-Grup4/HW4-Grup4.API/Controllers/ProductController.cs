using HW4_Grup4.Application.DTOs;
using HW4_Grup4.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HW4_Grup4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ActionResult CreateProduct([FromBody] ProductDto product)
        {
            try
            {
                _productService.AddAsync(product);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
