namespace TextilesGeomar.Core.DTOs
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalItemPrice => Quantity * ItemPrice;
    }

}
