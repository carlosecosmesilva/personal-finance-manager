using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManager.Domain.Entities;
using PersonalFinanceManager.Domain.Interfaces;

namespace PersonalFinanceManager.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
            => await _context.Transactions.Include(t => t.Category).ToListAsync();

        public async Task<Transaction?> GetByIdAsync(int id)
            => await _context.Transactions.Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Transaction>> GetByMonthAsync(int month, int year)
            => await _context.Transactions
                .Where(t => t.Date.Month == month && t.Date.Year == year)
                .ToListAsync();

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Transactions.FindAsync(id);
            if (item is not null)
            {
                _context.Transactions.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
