using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities.Contrys
{
    public class State
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("stateId")]
        [BsonRepresentation(BsonType.Int32)]
        public int StateId { get; set; }

        [BsonElement("stateName")]
        [BsonRepresentation(BsonType.String)]
        public string StateName { get; set; }

        [BsonElement("contryId")]
        [BsonRepresentation(BsonType.Int32)]
        public int ContryId { get; set; }
    }
}
