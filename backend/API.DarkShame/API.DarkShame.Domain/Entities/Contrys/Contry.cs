using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities.Contrys
{
    public class Contry
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("contryId")]
        [BsonRepresentation(BsonType.Int32)]
        public int ContryId { get; set; }

        [BsonElement("nameContry")]
        [BsonRepresentation(BsonType.String)]
        public string NameContry { get; set; }
    }
}
