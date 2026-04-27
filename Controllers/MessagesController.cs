using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WtcConnectBackend.Data;
using WtcConnectBackend.Models;
using WtcConnectBackend.Services; // <-- Puxa a pasta de serviços

namespace WtcConnectBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly MongoDbContext _context;
        private readonly FirebaseService _firebaseService;

        public MessagesController(MongoDbContext context, FirebaseService firebaseService)
        {
            _context = context;
            _firebaseService = firebaseService;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetCustomerInbox(string customerId)
        {
            var messages = await _context.Messages.Find(m => m.CustomerId == customerId).ToListAsync();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            await _context.Messages.InsertOneAsync(message);

            await _firebaseService.SendPushNotificationAsync(
                deviceToken: "TOKEN_FICTICIO_PARA_TESTE", 
                title: $"Nova mensagem de {message.Sender}", 
                body: message.Content
            );

            return CreatedAtAction(nameof(GetCustomerInbox), new { customerId = message.CustomerId }, message);
        }
    }
}