using PersonalFinanceManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Application.Interfaces
{
    public interface IBankAccountService
    {
        Task<IEnumerable<BankAccountDto>> GetAllAsync();
        Task<BankAccountDto?> GetByIdAsync(Guid id);
        Task CreateAsync(BankAccountDto bankAccountDto);
        Task UpdateAsync(BankAccountDto bankAccountDto);
        Task DeleteAsync(Guid id);
    }
}
