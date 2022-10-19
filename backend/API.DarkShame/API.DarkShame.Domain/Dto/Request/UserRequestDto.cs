using API.DarkShame.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Dto.Request
{
    public class UserRequestDto
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

        [BsonElement("locationContry")]
        [BsonRepresentation(BsonType.String)]
        public string locationContry { get; set; }

        [BsonElement("locationState")]
        [BsonRepresentation(BsonType.String)]
        public string locationState { get; set; }

        [BsonElement("locationCityId")]
        [BsonRepresentation(BsonType.Int32)]
        public string locationCity { get; set; }

        [BsonElement("summary")]
        [BsonRepresentation(BsonType.String)]
        public string Summary { get; set; }
    }
}
