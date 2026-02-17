using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CampaignRepository : ICampaign
    {
        private readonly ApplicationDbContext _dbContext;
        public CampaignRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        //Retrieving Campaigns
      public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> campaigns = _dbContext.Campaigns.ToList();
            return campaigns;
        }
        public Campaign GetCampaignById(int id)
        {
               return _dbContext.Campaigns.FirstOrDefault(c => c.Id == id);
        }
        public void CreateCampaign(CampaignCreateDTO CampaignDTO)
        {
            Campaign campaign = new()
            {
                Name = CampaignDTO.Name,
                Description = CampaignDTO.Description,
                Status = CampaignDTO.Status,
                CampaignType = CampaignDTO.CampaignType,
                StartDate = CampaignDTO.StartDate,
                EndDate = CampaignDTO.EndDate,
                CreatedAt = DateTime.Now,
                CreatedById = 1
            };
            _dbContext.Campaigns.Add(campaign);
            _dbContext.SaveChanges();
        }
       public void UpdateCamapaign(int id, CampaignUpdateDTO campaignDTO)
        {
            var campaign = _dbContext.Campaigns.Find(id);
            if (campaign == null) return;
            {
                campaign.Name = campaignDTO.Name;
                campaign.Description = campaignDTO.Description;
                campaign.Status = campaignDTO.Status;
                campaign.CampaignType = campaignDTO.CampaignType;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateCampaign(int id, CampaignUpdateDTO campaignDTO)
        {
            throw new NotImplementedException();
        }
    }
}