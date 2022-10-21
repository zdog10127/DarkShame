using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Entities.Store.Payment
{
    public class Payments
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("namePayment")]
        [BsonRepresentation(BsonType.String)]
        public string NamePayment { get; set; }

        [BsonElement("codePayment")]
        [BsonRepresentation(BsonType.Int32)]
        public int CodePayment { get; set; }
    }
}
