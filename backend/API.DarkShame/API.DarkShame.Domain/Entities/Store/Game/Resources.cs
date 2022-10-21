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
    public class Resources
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("idGame")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdGame { get; set; }

        [BsonElement("onePlayer")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool OnePlayer { get; set; }

        [BsonElement("cooperative")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Cooperative { get; set; }

        [BsonElement("achievements")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Achievements { get; set; }

        [BsonElement("controllerCompatible")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool ControllerCompatible { get; set; }

        [BsonElement("collectibleCards")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool CollectibleCards { get; set; }

        [BsonElement("cloud")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Cloud { get; set; }
    }
}
