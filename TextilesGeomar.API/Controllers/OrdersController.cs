using Microsoft.AspNetCore.Mvc;
using TextilesGeomar.Common.Responses; // Add this namespace for BaseResponse
using TextilesGeomar.Models.DTOs;
using TextilesGeomar.Services;

namespace TextilesGeomar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<OrderDto>>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrdersAsync();

                return Ok(BaseResponse<IEnumerable<OrderDto>>.SuccessResponse(orders));
            }
            catch (Exception ex)
            {
                return StatusCode(500, BaseResponse<IEnumerable<OrderDto>>.ErrorResponse("An error occurred while fetching orders."));
            }
        }
    }
}
