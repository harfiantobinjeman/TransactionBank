using CompanyServices.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyServices.Api.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext>options): base(options) { }

        public DbSet<Company> Company { get; set; }
    }
}
