using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISupportTicket
    {
        public List<SupportTicket> GetAllSupportTickets();
        public SupportTicket GetSupportTicketById(int id);
        void CreateSupportTicket(SupportTicketCreateDTO supportTicketDTO);
        void UpdateSupportTicket(int id, SupportTicketUpdateDTO supportTicketDTO);
    }
}