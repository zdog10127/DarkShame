using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities.Store.Game
{
    public class SpecificationsMaximum
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("idGame")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdGame { get; set; }

        [BsonElement("so")]
        [BsonRepresentation(BsonType.String)]
        public string SO { get; set; }

        [BsonElement("processor")]
        [BsonRepresentation(BsonType.String)]
        public string Processor { get; set; }

        [BsonElement("ram")]
        [BsonRepresentation(BsonType.String)]
        public string RAM { get; set; }

        [BsonElement("videoCard")]
        [BsonRepresentation(BsonType.String)]
        public string VideoCard { get; set; }

        [BsonElement("directX")]
        [BsonRepresentation(BsonType.String)]
        public string DirectX { get; set; }

        [BsonElement("network")]
        [BsonRepresentation(BsonType.String)]
        public string Network { get; set; }

        [BsonElement("storage")]
        [BsonRepresentation(BsonType.String)]
        public string Storage { get; set; }
    }
}
