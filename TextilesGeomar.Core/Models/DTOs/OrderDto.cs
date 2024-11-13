namespace TextilesGeomar.Core.Models.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; } 
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? ClientName { get; set; } 
        public string? InstitutionName { get; set; }  
    }
}
