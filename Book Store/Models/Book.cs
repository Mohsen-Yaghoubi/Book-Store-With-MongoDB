using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Book_Store.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
