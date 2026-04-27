using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WtcConnectBackend.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; } = null!;

        public string Sender { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}