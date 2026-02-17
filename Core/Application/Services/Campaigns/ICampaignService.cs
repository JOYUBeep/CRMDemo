using Application.DTO;
using Domain.Entities;
namespace Application.Services.Campaigns
{
    public interface ICampaignService
    {
        Campaign GetCampaignById(int Id);
        List<Campaign> GetAllCampaigns();
        void CreateCampaign(CampaignCreateDTO campaignDTO);
       void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO);
    }
}