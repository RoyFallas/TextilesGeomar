using Microsoft.AspNetCore.Mvc;
using TextilesGeomar.API.Services;
using TextilesGeomar.Common.Responses;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Services;
using TextilesGeomar.Core.Models.DTOs;


namespace TextilesGeomar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRabbitMqProducerService _rabbitMqProducerService;

        public OrderController(IOrderService orderService, IRabbitMqProducerService rabbitMqProducerService)
        {
            _orderService = orderService;
            _rabbitMqProducerService = rabbitMqProducerService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<OrderDto>>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrders();

                return Ok(BaseResponse<IEnumerable<OrderDto>>.SuccessResponse(orders));
            }
            catch (Exception ex)
            {
                return StatusCode(500, BaseResponse<IEnumerable<OrderDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<OrderDto>>> GetOrderById(int id)
        {
            try
            {
                var orders = await _orderService.GetOrderById(id);

                return Ok(BaseResponse<IEnumerable<OrderDto>>.SuccessResponse(orders));
            }
            catch (Exception ex)
            {
                return StatusCode(500, BaseResponse<IEnumerable<OrderDto>>.ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<string>>> Order([FromBody] Order order)
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
