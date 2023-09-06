using JenisTransactionServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.X509Certificates;

namespace JenisTransactionServices.Data
{
    public class JenisTransactionDbContext : DbContext
    {
		public DbSet<JenisTransaction>jenisTransactions { get; set; }
        public JenisTransactionDbContext(DbContextOptions<JenisTransactionDbContext>dbContextOptions):base(dbContextOptions)
        {
			try
			{
				var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (databaseCreator != null)
				{
					if (!databaseCreator.CanConnect()) databaseCreator.Create();

					if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
