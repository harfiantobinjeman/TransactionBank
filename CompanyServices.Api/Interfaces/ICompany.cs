using CompanyServices.Api.Dto;
using CompanyServices.Api.Models;

namespace CompanyServices.Api.Interfaces
{
    public interface ICompany
    {
        Task<Response<List<CompanyDto>>> GetCompany();
        Task<Response<bool>>AddCompany(CompanyDto companyDto);
        Task<Response<bool>>RemoveCompany(Company company);
        Task<Response<bool>> UpdateCompany(int id);
    }
}
