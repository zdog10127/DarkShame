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
    public class ServerInfo
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("serverTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ServerTime { get; set; }

        [BsonElement("serverTimeString")]
        [BsonRepresentation(BsonType.String)]
        public string ServerTimeString { get; set; }
    }
}
