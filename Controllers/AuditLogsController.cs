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
    public class AuditLogsController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public AuditLogsController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> Get()
        {
            var logs = await _context.AuditLogs.Find(_ => true).SortByDescending(l => l.Timestamp).ToListAsync();
            return Ok(logs);
        }

        [HttpPost]
        public async Task<ActionResult<AuditLog>> Post(AuditLog log)
        {
            await _context.AuditLogs.InsertOneAsync(log);
            return CreatedAtAction(nameof(Get), new { id = log.Id }, log);
        }
    }
}