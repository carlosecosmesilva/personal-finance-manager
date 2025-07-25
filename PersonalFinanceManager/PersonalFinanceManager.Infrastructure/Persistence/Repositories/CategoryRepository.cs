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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            var item = _context.Categories.Find(id);
            if (item is not null)
            {
                _context.Categories.Remove(item);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category ?? throw new InvalidOperationException($"Categoria com Id '{id}' não encontrada.");
        }

        public Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChangesAsync();
        }
    }
}
