using API.DarkShame.Domain.Entities.Contrys;
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
    public class Languages
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("idGame")]
        [BsonRepresentation(BsonType.String)]
        public string IdGame { get; set; }

        [BsonElement("languageName")]
        [BsonRepresentation(BsonType.String)]
        public string LanguageName { get; set; }

        [BsonElement("contry")]
        [BsonRepresentation(BsonType.Int32)]
        public int Contry { get; set; }

        [BsonElement("interface")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Interface { get; set; }

        [BsonElement("dubbing")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Dubbing { get; set; }

        [BsonElement("substitles")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Subtitles { get; set; }
    }
}
