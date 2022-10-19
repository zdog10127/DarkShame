using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace API.DarkShame.Domain.Dto.Request
{
    public class UserLastLogOffRequestDto
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("lastLogoff")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastLogoff { get; set; }
    }
}
