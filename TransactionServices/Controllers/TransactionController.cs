using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TransactionServices.Models;

namespace TransactionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMongoCollection<Transaction> _transactions;
        public TransactionController()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _transactions = database.GetCollection<Transaction>("transaction");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransaction()
        {
            return await _transactions.Find(Builders<Transaction>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{transactionId}")]
        public async Task<ActionResult<Transaction>>GetById(int id)
        {
            var filterDefinition = Builders<Transaction>.Filter.Eq(x => x.IdTransaction, id);
            return await _transactions.Find(filterDefinition).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult>CreateTransaction(Transaction transaction)
        {
            await _transactions.InsertOneAsync(transaction);
            return Ok(transaction);
        }

        [HttpPut]
        public async Task<ActionResult>UpdateTransaction(Transaction transaction)
        {
            var filterDefinition = Builders<Transaction>.Filter.Eq(x => x.IdTransaction, transaction.IdTransaction);
            await _transactions.ReplaceOneAsync(filterDefinition,transaction);
            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>DeleteTransaction(int id)
        {
            var filterDefinition = Builders<Transaction>.Filter.Eq(x => x.IdTransaction, id);
            await _transactions.DeleteOneAsync(filterDefinition);
            return Ok();
        }
    }
}
