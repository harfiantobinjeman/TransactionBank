using JenisTransactionServices.Data;
using JenisTransactionServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenisTransactionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisTransactionController : ControllerBase
    {
        private readonly IJenisTransaction _jenisTransaction;

        public JenisTransactionController(IJenisTransaction jenisTransaction)
        {
            _jenisTransaction = jenisTransaction;
        }

        [HttpGet("jenisTransaction")]
        public async Task<IActionResult> GetJenisTransaction()
        {
            var result = await _jenisTransaction.GetJenisTransaction();
            return Ok(result);
        }
    }
}
