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
    public class GroupInfo
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("creationDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime creationDate { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("headLine")]
        [BsonRepresentation(BsonType.String)]
        public string HeadLine { get; set; }

        [BsonElement("summary")]
        [BsonRepresentation(BsonType.String)]
        public string Summary { get; set; }

        [BsonElement("abbreviation")]
        [BsonRepresentation(BsonType.String)]
        public string Abbreviation { get; set; }

        [BsonElement("profileUrl")]
        [BsonRepresentation(BsonType.String)]
        public string ProfileUrl { get; set; }

        [BsonElement("avatarUrl")]
        [BsonRepresentation(BsonType.String)]
        public string AvatarUrl { get; set; }

        [BsonElement("locationContry")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationContry { get; set; }

        [BsonElement("locationState")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationState { get; set; }

        [BsonElement("locationCity")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationCity { get; set; }

        [BsonElement("favoriteAppId")]
        [BsonRepresentation(BsonType.Int32)]
        public int FavoriteAppId { get; set; }

        [BsonElement("members")]
        [BsonRepresentation(BsonType.Int32)]
        public int Members { get; set; }

        [BsonElement("usersOnline")]
        [BsonRepresentation(BsonType.Int32)]
        public int UsersOnline { get; set; }

        [BsonElement("usersInChat")]
        [BsonRepresentation(BsonType.Int32)]
        public int UsersInChat { get; set; }

        [BsonElement("usersInGame")]
        [BsonRepresentation(BsonType.Int32)]
        public int UsersInGame { get; set; }

        [BsonElement("owner")]
        [BsonRepresentation(BsonType.String)]
        public string Owner { get; set; }
    }
}
