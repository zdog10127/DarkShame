using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities
{
    public class Friend
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("blocked")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Blocked { get; set; }

        [BsonElement("friendSince")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime FriendSince { get; set; }
    }
}
