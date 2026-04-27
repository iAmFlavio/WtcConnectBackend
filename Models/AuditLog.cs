using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WtcConnectBackend.Models
{
    public class AuditLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string OperatorEmail { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}