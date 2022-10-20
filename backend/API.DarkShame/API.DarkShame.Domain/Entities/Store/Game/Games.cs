using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace API.DarkShame.Domain.Entities.Store.Game
{
    public class Games
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("nameGame")]
        [BsonRepresentation(BsonType.String)]
        public string NameGame { get; set; }

        [BsonElement("price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; }

        [BsonElement("summary")]
        [BsonRepresentation(BsonType.String)]
        public string Summary { get; set; }

        [BsonElement("developer")]
        [BsonRepresentation(BsonType.String)]
        public string Developer { get; set; }

        [BsonElement("distributor")]
        [BsonRepresentation(BsonType.String)]
        public string Distributor { get; set; }

        [BsonElement("releaseDate")]
        [BsonRepresentation(BsonType.String)]
        public string RealeaseDate { get; set; }

        [BsonElement("available")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Available { get; set; }

        [BsonElement("preSale")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool PreSale { get; set; }

        [BsonElement("promotion")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Promotion { get; set; }

        [BsonElement("discount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Discount { get; set; }

        [BsonElement("profileUrl")]
        [BsonRepresentation(BsonType.String)]
        public string ProfileUrl { get; set; }

        [BsonElement("images")]
        public List<string> Images { get; set; }

        [BsonElement("allAnalysis")]
        [BsonRepresentation(BsonType.Int32)]
        public int AllAnalysis { get; set; }

        [BsonElement("analysis")]
        public List<Analysis> Analysis { get; set; }

        [BsonElement("resources")]
        public Resources Resources { get; set; }

        [BsonElement("languages")]
        public List<Languages> Languages { get; set; }

        [BsonElement("parentalRating")]
        [BsonRepresentation(BsonType.Int32)]
        public int ParentalRating { get; set; }

        [BsonElement("specificationsMinimum")]
        public SpecificationsMinimum SpecificationsMinimum { get; set; }

        [BsonElement("specificationsMaximum")]
        public SpecificationsMaximum SpecificationsMaximum { get; set; }
    }
}
