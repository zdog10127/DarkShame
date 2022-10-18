using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities
{
    public class Update
    {
        [BsonElement("timestamp")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Timestamp { get; set; }

        [BsonElement("origin")]
        [BsonRepresentation(BsonType.String)]
        public string Origin { get; set; }

        [BsonElement("localMessage")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool LocalMessage { get; set; }

        [BsonElement("type")]
        public UpdateType Type { get; set; }

        [BsonElement("message")]
        [BsonRepresentation(BsonType.String)]
        public string Message { get; set; }

        [BsonElement("status")]
        public UserStatus Status { get; set; }

        [BsonElement("nick")]
        [BsonRepresentation(BsonType.String)]
        public string Nick { get; set; }
    }
}
