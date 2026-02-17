using Domain.Entities;
using Application.Interfaces;
using Application.DTO;

namespace Application.Services.Campaigns
{
   public class CampaignService : ICampaignService
    {
         
        private readonly ICampaign _campaign;
    
        //constructor
        public CampaignService(ICampaign campaign)
        {
            _campaign = campaign;
        }
        public Campaign GetCampaignById(int id)
        {
            return _campaign.GetCampaignById(id);
        }
        public List<Campaign> GetAllCampaigns()
        {  
            List<Campaign> campaigns = _campaign.GetAllCampaigns();
            return campaigns; 
        }
        public void CreateCampaign(CampaignCreateDTO campaignDTO)
        {
            _campaign.CreateCampaign(campaignDTO);
        }
        public void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO)
        {
                _campaign.UpdateCampaign(id, campaignDTO);
        }
    }
}