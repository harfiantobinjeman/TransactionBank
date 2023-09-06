using System.ComponentModel.DataAnnotations;

namespace CompanyServices.Api.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public decimal DanaAwal { get; set; }
    }
}
