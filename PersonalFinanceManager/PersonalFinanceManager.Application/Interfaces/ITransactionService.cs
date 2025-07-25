using PersonalFinanceManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto?> GetByIdAsync(int id);
        Task CreateAsync(TransactionDto transactionDto);
        Task UpdateAsync(TransactionDto transactionDto);
        Task DeleteAsync(int id);
    }
}
