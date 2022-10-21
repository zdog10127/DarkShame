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
    public class Analysis
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("idGame")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdGame { get; set; }

        [BsonElement("nickName")]
        [BsonRepresentation(BsonType.String)]
        public string NickName { get; set; }

        [BsonElement("hoursGameplay")]
        [BsonRepresentation(BsonType.String)]
        public string HoursGameplay { get; set; }

        [BsonElement("note")]
        [BsonRepresentation(BsonType.Int32)]
        public int Note { get; set; }

        [BsonElement("comment")]
        [BsonRepresentation(BsonType.String)]
        public string Comment { get; set; }

        [BsonElement("evaluation")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Evaluation { get; set; }
    }
}
