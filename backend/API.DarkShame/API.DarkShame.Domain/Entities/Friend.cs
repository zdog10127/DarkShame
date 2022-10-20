using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace API.DarkShame.Domain.Entities
{
    public class Friend
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("blocked")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Blocked { get; set; }

        [BsonElement("friendSince")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime FriendSince { get; set; }
    }
}
