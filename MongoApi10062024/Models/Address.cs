using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoApi10062024.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string CEP { get; set; }
    }
}
