using System.ComponentModel.DataAnnotations;

namespace JenisTransactionServices.Models
{
    public class JenisTransaction
    {
        [Key]
        public int Id { get; set; }
        public string NameTransaction { get; set; }
    }
}
