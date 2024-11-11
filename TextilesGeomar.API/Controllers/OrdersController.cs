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
        private readonly IRabbitMqProducerService _rabbitMqProducerService;

        public OrdersController(IOrderService orderService, IRabbitMqProducerService rabbitMqProducerService)
        {
            _orderService = orderService;
            _rabbitMqProducerService = rabbitMqProducerService;
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
                return StatusCode(500, BaseResponse<IEnumerable<OrderDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<string>>> Order([FromBody] OrderDto order)
        {
            try
            {
                // Send the order to RabbitMQ
                await _rabbitMqProducerService.SendOrderToQueueAsync(order);

                return Ok(BaseResponse<string>.SuccessResponse("Order has been sent to the queue."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, BaseResponse<string>.ErrorResponse(ex.Message));
            }
        }
    }
}
