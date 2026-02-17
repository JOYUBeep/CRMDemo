using Application.DTO;
using Domain.Entities;

namespace Application.Services.SupportTickets
{
public interface ISupportTicketService
    {
        SupportTicket GetSupportTicketById(int id);
         List<SupportTicket> GetAllSupportTickets();
         void CreateSupportTicket(SupportTicketCreateDTO supportTicketDTO);
        void UpdateSupportTicket(int id, SupportTicketUpdateDTO supportTicketDTO);
    }
}