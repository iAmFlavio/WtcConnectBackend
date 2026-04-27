using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WtcConnectBackend.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        
        // Campos de CRM exigidos no escopo
        public string Segment { get; set; } = null!; // Ex: VIP, Corporativo
        public List<string> Tags { get; set; } = new(); // Ex: #importante, #promo
        public int Score { get; set; } // 0 a 100
        public string Status { get; set; } = "Ativo"; // Ativo, Inativo
        
        // Histórico para a visão 360°
        public DateTime LastInteraction { get; set; } = DateTime.UtcNow;
    }
}