using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManager.Domain.Interfaces;
using PersonalFinanceManager.Domain.Entities;

namespace PersonalFinanceManager.Infrastructure.Persistence.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly AppDbContext _context;
        public BankAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
            => await _context.BankAccounts.ToListAsync();

        public async Task<BankAccount?> GetByIdAsync(int id)
            => await _context.BankAccounts.FindAsync(id);

        public async Task<BankAccount> GetByIdAsync(Guid id) => await _context.BankAccounts.Include(b => b.Id)
                .FirstOrDefaultAsync(b => b.Id == id);
        
        public async Task AddAsync(BankAccount bankAccount)
        {
            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.BankAccounts.FindAsync(id);
            if (item is not null)
            {
                _context.BankAccounts.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
