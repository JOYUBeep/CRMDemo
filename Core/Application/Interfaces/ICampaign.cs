using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICampaign
    {
       public List<Campaign> GetAllCampaigns();
       public Campaign GetCampaignById(int id);
       void CreateCampaign(CampaignCreateDTO campaignDTO);
       void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO);
    }
}