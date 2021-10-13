using HW4_Grup4.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;

        public UserController(IUserService userService, IOrderDetailService orderDetailService)
        {
            _userService = userService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public IActionResult GetCampaignsAsync()
        {
            _userService.Add();
            _orderDetailService.InsertOrderDetailToMongoDb(new Domain.Entities.OrderDetail());
            return Ok();
        }
    }
}
