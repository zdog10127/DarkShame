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
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("profileVisibility")]
        public ProfileVisibility ProfileVisibility { get; set; }

        [BsonElement("profileState")]
        [BsonRepresentation(BsonType.Int32)]
        public int ProfileState { get; set; }

        [BsonElement("nickName")]
        [BsonRepresentation(BsonType.String)]
        public string NickName { get; set; }

        [BsonElement("lastLogoff")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastLogoff { get; set; }

        [BsonElement("profileUrl")]
        [BsonRepresentation(BsonType.String)]
        public string ProfileUrl { get; set; }

        [BsonElement("avatarUrl")]
        [BsonRepresentation(BsonType.String)]
        public string AvatarUrl { get; set; }

        [BsonElement("status")]
        public UserStatus Status { get; set; }

        [BsonElement("realName")]
        [BsonRepresentation(BsonType.String)]
        public string RealName { get; set; }

        [BsonElement("primaryGroupId")]
        [BsonRepresentation(BsonType.String)]
        public string PrimaryGroupId { get; set; }

        [BsonElement("joinDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime joinDate { get; set; }

        [BsonElement("locationContry")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationContry { get; set; }

        [BsonElement("locationState")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationState { get; set; }

        [BsonElement("locationCity")]
        [BsonRepresentation(BsonType.Int32)]
        public int LocationCity { get; set; }

        [BsonElement("summary")]
        [BsonRepresentation(BsonType.String)]
        public string Summary { get; set; }
    }
}
