using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SupportTicketRepository : ISupportTicket
    {
        private readonly ApplicationDbContext _dbContext;
        public SupportTicketRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // Retrieving Support Tickets
        public List<SupportTicket> GetAllSupportTickets()
        {
            List<SupportTicket> tickets = _dbContext.SupportTickets.ToList();
            return tickets;
        }

        public SupportTicket GetSupportTicketById(int id)
        {
            return _dbContext.SupportTickets.FirstOrDefault(t => t.Id == id);
        }
         public void CreateSupportTicket(SupportTicketCreateDTO supportTicketDTO)
        {
            SupportTicket supportTicket = new()
            {
                CustomerId = supportTicketDTO.CustomerId,
                Subject = supportTicketDTO.Subject,
                Description = supportTicketDTO.Description,
                Status = supportTicketDTO.Status,
                CreatedAt = DateTime.Now,
                CreatedById = 1
            };
            _dbContext.SupportTickets.Add(supportTicket);
            _dbContext.SaveChanges();
        }
        public void UpdateSupportTicket(int id, SupportTicketUpdateDTO supportTicketDTO)
        {
            var supportTicket = _dbContext.SupportTickets.Find(id);
            if (supportTicket == null) return;
            {
                supportTicket.Subject = supportTicketDTO.Subject;
                supportTicket.Description = supportTicketDTO.Description;
                supportTicket.Status = supportTicketDTO.Status;
                _dbContext.SaveChanges();
            }
        }
    }
}