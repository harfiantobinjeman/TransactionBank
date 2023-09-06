using CompanyServices.Api.Data;
using CompanyServices.Api.Dto;
using CompanyServices.Api.Interfaces;
using CompanyServices.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace TransactionBankServices.Api.Services
{
    public class CompanyService : ICompany
    {
        private readonly TransactionDbContext _transactionDbContext;

        public CompanyService(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }
        public async Task<Response<bool>> AddCompany(CompanyDto companyDto)
        {
            var response = new Response<bool>();
            try
            {
                var createCompany = new Company()
                {
                    NameCompany = companyDto.NameCompany,
                    DanaAwal = companyDto.DanaAwal
                };
                await _transactionDbContext.Company.AddAsync(createCompany);
                await _transactionDbContext.SaveChangesAsync();
                if (createCompany != null)
                {
                    response.StatusCode = 200;
                    response.ErrorMessage = "";
                    response.Data = true;
                    response.IsSuccess = true;
                }
                else
                {
                    response.StatusCode = 500;
                    response.ErrorMessage = "Opps.., Failed insert data!";
                    response.Data = false;
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Data = false;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response<List<CompanyDto>>> GetCompany()
        {
            var response = new Response<List<CompanyDto>>();
            try
            {
                //List<Company> listCompany = new List<Company>();
                //listCompany = (from DataRow dr in )
                var company = await _transactionDbContext.Company.ToListAsync();
                var result = new List<CompanyDto>();
                result = (from com in company
                          select new CompanyDto
                          {
                              NameCompany = com.NameCompany,
                              DanaAwal = com.DanaAwal
                          }).ToList();
                if (result.Count > 0)
                {
                    response.StatusCode = 200;
                    response.ErrorMessage = "";
                    response.Data = result;
                    response.IsSuccess = true;
                }
                else
                {
                    response.StatusCode = 404;
                    response.ErrorMessage = "Data tidak ditemukan!";
                    response.Data = null;
                    response.IsSuccess = false;

                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                response.IsSuccess = false;
            }
            return response;
        }

        public Task<Response<bool>> RemoveCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}
