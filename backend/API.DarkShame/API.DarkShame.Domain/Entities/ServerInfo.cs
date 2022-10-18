using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities
{
    public class ServerInfo
    {
        [BsonElement("serverTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ServerTime { get; set; }

        [BsonElement("serverTimeString")]
        [BsonRepresentation(BsonType.String)]
        public string ServerTimeString { get; set; }
    }
}
