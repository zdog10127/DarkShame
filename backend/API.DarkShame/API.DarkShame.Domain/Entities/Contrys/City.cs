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
    public class City
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("cityId")]
        [BsonRepresentation(BsonType.Int32)]
        public int CityId { get; set; }

        [BsonElement("cityName")]
        [BsonRepresentation(BsonType.String)]
        public string CityName { get; set; }

        [BsonElement("stateId")]
        [BsonRepresentation(BsonType.Int32)]
        public int StateId { get; set; }
    }
}
