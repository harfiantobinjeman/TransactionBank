using CompanyServices.Api.Dto;
using CompanyServices.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompany()
        {
            var result  = await _company.GetCompany();
            return Ok(result);
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCustomers([FromBody] CompanyDto companyDto)
        {
            var res = await _company.AddCompany(companyDto);
            return Ok(res);
        }
    }
}
