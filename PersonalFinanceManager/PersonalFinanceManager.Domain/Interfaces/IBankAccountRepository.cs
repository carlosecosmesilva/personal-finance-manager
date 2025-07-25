using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Domain.Entities;

namespace PersonalFinanceManager.Domain.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();
        Task<BankAccount> GetByIdAsync(Guid id);
        Task AddAsync(BankAccount bankAccount);
        Task UpdateAsync(BankAccount bankAccount);
        Task DeleteAsync(Guid id);
    }
}
