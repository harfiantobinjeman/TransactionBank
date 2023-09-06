using MongoDB.Bson.Serialization.Attributes;

namespace TransactionServices.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class TransactionDetail
    {
        public int IdJenisTransaction { get; set; }
        public string Description { get; set; }
    }
}
