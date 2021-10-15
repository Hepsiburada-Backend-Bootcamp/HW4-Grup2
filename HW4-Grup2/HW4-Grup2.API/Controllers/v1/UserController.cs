using HW4_Grup2.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HW4_Grup2.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]    
    [Route("api/v{version:apiVersion}/users")]
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
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _userService.GetAllAsync();

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var result = await _userService.GetUserById(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
