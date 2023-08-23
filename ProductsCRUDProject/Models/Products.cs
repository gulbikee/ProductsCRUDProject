using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductsCRUDProject.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
    }
}
