namespace TextilesGeomar.Models.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }  // Assuming you renamed SaleId to OrderId
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ClientName { get; set; }
        public string InstitutionName { get; set; }
    }
}
