using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WtcConnectBackend.Data;
using WtcConnectBackend.Models;

namespace WtcConnectBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public CampaignsController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campaign>>> Get()
        {
            var campaigns = await _context.Campaigns.Find(_ => true).ToListAsync();
            return Ok(campaigns);
        }

        [HttpPost]
        public async Task<ActionResult<Campaign>> Post(Campaign campaign)
        {
            await _context.Campaigns.InsertOneAsync(campaign);
            return CreatedAtAction(nameof(Get), new { id = campaign.Id }, campaign);
        }
    }
}