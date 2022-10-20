using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Dto.Request.Groups
{
    public class GroupInfoRequestDto
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

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
        [BsonRepresentation(BsonType.String)]
        public int LocationContry { get; set; }

        [BsonElement("locationState")]
        [BsonRepresentation(BsonType.String)]
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
