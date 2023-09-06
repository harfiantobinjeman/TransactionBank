using JenisTransactionServices.Data;
using JenisTransactionServices.Dto;
using JenisTransactionServices.Interfaces;
using JenisTransactionServices.Models;
using Microsoft.EntityFrameworkCore;

namespace JenisTransactionServices.Services
{
    public class JenisTransactionServis : IJenisTransaction
    {
        private readonly JenisTransactionDbContext _jenisTransactionDbContext;

        public JenisTransactionServis(JenisTransactionDbContext jenisTransactionDbContext)
        {
            _jenisTransactionDbContext = jenisTransactionDbContext;
        }
        public Task<Response<bool>> AddJenisTransaction(JenisTransactionDto jenisTransactionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<JenisTransactionDto>>> GetJenisTransaction()
        {
            var response = new Response<List<JenisTransactionDto>>();
            try
            {
                //List<Company> listCompany = new List<Company>();
                //listCompany = (from DataRow dr in )
                var jenisTrans = await _jenisTransactionDbContext.jenisTransactions.ToListAsync();
                var result = new List<JenisTransactionDto>();
                result = (from com in jenisTrans
                          select new JenisTransactionDto
                          {
                              NameTransaction = jenisTrans.FirstOrDefault().NameTransaction
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

        public Task<Response<bool>> RemoveJenisTransaction(JenisTransaction jenisTransaction)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateJenisTransaction(int id)
        {
            throw new NotImplementedException();
        }
    }
}
