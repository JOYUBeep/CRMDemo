namespace Application.DTO;
public class SupportTicketCreateDTO
{
        public int CustomerId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
}
public class SupportTicketUpdateDTO
{
        public int CustomerId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
}