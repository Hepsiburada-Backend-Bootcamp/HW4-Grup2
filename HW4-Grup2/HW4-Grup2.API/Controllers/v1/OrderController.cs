using HW4_Grup2.Application.DTOs;
using HW4_Grup2.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HW4_Grup2.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult CreateOrder([FromBody] CreateOrderDto order)
        {
            try
            {
                _orderService.AddAsync(order);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult Get() 
        {
            var result = _orderService.GetAll();
            
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get([FromRoute] string id)
        {
            var result = await _orderService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult GetOrderByUserId([FromRoute] int id)
        {
            var result =  _orderService.GetByUserIdAsync(id);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result.ToList());
        }

        //[Route("passive")]
        //[HttpPut]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public IActionResult PassiveCampaign([FromHeader(Name = "x-requestid")] int campaignId)
        //{
        //    var campaign = campaignList.FirstOrDefault(campaign => campaign.Id == campaignId);

        //    if (campaign is not null)
        //    {
        //        campaign.IsActive = false;

        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[Route("{campaignId:int}")]
        //[HttpGet]
        //[ProducesResponseType(typeof(CampaignDto), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public ActionResult<CampaignDto> GetCampaignById(int campaignId)
        //{
        //    var campaign = campaignList.FirstOrDefault(campaign => campaign.Id == campaignId);

        //    if (campaign is not null)
        //    {
        //        return Ok(campaign);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<CampaignDto>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public ActionResult<IEnumerable<CampaignDto>> GetCampaignsAsync()
        //{
        //    if (campaignList.Count > 0)
        //    {
        //        return Ok(campaignList);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        //[HttpDelete]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public ActionResult<CampaignDto> DeleteCampaign(int campaignId)
        //{
        //    var campaign = campaignList.FirstOrDefault(campaign => campaign.Id == campaignId);

        //    if (campaign is not null)
        //    {
        //        campaignList.Remove(campaign);

        //        return Ok(campaign);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[Route("filter")]
        //[HttpPost]
        //[ProducesResponseType(typeof(IEnumerable<CampaignDto>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //public ActionResult<IEnumerable<CampaignDto>> GetCampaignWithFilter(FilterDto filters)
        //{
        //    var resultList = campaignList.Where(campaign => (filters.Name == null || filters.Name.Count == 0 || filters.Name.Contains(campaign.Name))
        //                                        && (filters.StartDate == null || campaign.StartDate == filters.StartDate)
        //                                        && (filters.EndDate == null || campaign.EndDate == filters.EndDate)
        //                                        && filters.IsActive == campaign.IsActive)
        //                                        .ToList();

        //    if (resultList.Count > 0)
        //    {
        //        return Ok(resultList);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }

        //}


        //[HttpGet]
        //public async Task<IActionResult> GetCampaignsAsync()
        //{
        //    await _userService.Add();
        //    //_orderDetailService.InsertOrderDetailToMongoDb(new Domain.Entities.OrderDetail());
        //    return Ok();
        //}
    }
}
