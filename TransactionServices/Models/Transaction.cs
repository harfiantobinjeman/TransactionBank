using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TransactionServices.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }
        public int IdCompany { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public DateTime TransactionOn { get; set; }
        public List<TransactionDetail> TransactionDetails { get; set; }
    }
}
