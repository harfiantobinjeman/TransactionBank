using JenisTransactionServices.Dto;
using JenisTransactionServices.Models;

namespace JenisTransactionServices.Interfaces
{
    public interface IJenisTransaction
    {
        Task<Response<List<JenisTransactionDto>>> GetJenisTransaction();
        Task<Response<bool>> AddJenisTransaction(JenisTransactionDto jenisTransactionDto);
        Task<Response<bool>> RemoveJenisTransaction(JenisTransaction jenisTransaction);
        Task<Response<bool>> UpdateJenisTransaction(int id);
    }
}
