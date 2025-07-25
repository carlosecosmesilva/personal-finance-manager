using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Application.DTOs;
using PersonalFinanceManager.Domain.Interfaces;
using PersonalFinanceManager.Domain.Entities;
using PersonalFinanceManager.Application.Interfaces;

namespace PersonalFinanceManager.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task CreateAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
            return _categoryRepository.AddAsync(category);
        }

        public Task DeleteAsync(Guid id)
        {
            return _categoryRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = _categoryRepository.GetAllAsync();
            return categories.ContinueWith(task =>
                task.Result.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }));
        }

        public Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = _categoryRepository.GetByIdAsync(id);
            return category.ContinueWith(task =>
            {
                var c = task.Result;
                return c is null ? null : new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsIncomeCategory = c.IsIncomeCategory,
                    BankAccountId = c.BankAccountId
                };
            });
        }

        public Task UpdateAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                IsIncomeCategory = categoryDto.IsIncomeCategory,
                BankAccountId = categoryDto.BankAccountId
            };
            return _categoryRepository.UpdateAsync(category);
        }
    }
}
