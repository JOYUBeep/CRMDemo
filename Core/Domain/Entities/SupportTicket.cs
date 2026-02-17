namespace Domain.Entities
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ResolvedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }

        
    }
}
