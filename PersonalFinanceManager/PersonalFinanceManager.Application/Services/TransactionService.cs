using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceManager.Application.DTOs;
using PersonalFinanceManager.Application.Interfaces;
using PersonalFinanceManager.Domain.Entities;
using PersonalFinanceManager.Domain.Interfaces;

namespace PersonalFinanceManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository repository)
        {
            _transactionRepository = repository;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Date = t.Date,
                CategoryId = t.CategoryId,
                BankAccountId = t.BankAccountId
            });
        }

        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            var t = await _transactionRepository.GetByIdAsync(id);
            return t is null ? null : new TransactionDto
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Date = t.Date,
                CategoryId = t.CategoryId,
                BankAccountId = t.BankAccountId
            };
        }

        public async Task CreateAsync(TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                BankAccountId = dto.BankAccountId
            };
            await _transactionRepository.AddAsync(transaction);
        }

        public async Task UpdateAsync(TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = dto.Id,
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                BankAccountId = dto.BankAccountId
            };
            await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _transactionRepository.DeleteAsync(id);
        }
    }
}
