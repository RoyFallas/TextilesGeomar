using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Models.DTOs
{    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ClientEmail { get; set; }
        public int? InstitutionId { get; set; }      
        public string InstitutionName { get; set; }
        public int StatusId { get; set; }
        public string OrderStatus { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime? OrderCompletedDate { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }

}
