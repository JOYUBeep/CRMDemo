using Domain.Entities;
using Application.Interfaces;
using Application.DTO;

namespace Application.Services.SupportTickets
{
  public class SupportTicketService : ISupportTicketService
    {
      private readonly ISupportTicket _supportTicket;

      //constructor
     public SupportTicketService(ISupportTicket supportTicket)
      {
          _supportTicket = supportTicket;
      }
      public SupportTicket GetSupportTicketById(int id)
      {
          return _supportTicket.GetSupportTicketById(id);
      }
      public List<SupportTicket> GetAllSupportTickets()
      {  
          List<SupportTicket> supportTickets = _supportTicket.GetAllSupportTickets();
          return supportTickets; 
      }
      public void CreateSupportTicket(SupportTicketCreateDTO supportTicketDTO)
        {
            _supportTicket.CreateSupportTicket(supportTicketDTO);
        }
     public void UpdateSupportTicket(int id, SupportTicketUpdateDTO supportTicketDTO)
        {
             _supportTicket.UpdateSupportTicket(id, supportTicketDTO);
        }
    }
}
