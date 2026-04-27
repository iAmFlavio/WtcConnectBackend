using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WtcConnectBackend.Models
{
    public class Campaign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string TargetSegment { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string? Url { get; set; }

        public List<ActionItem> Actions { get; set; } = new();
        public Dictionary<string, string> ActionUrls { get; set; } = new();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pendente"; 
    }
}