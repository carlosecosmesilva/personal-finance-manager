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
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository repository)
        {
            _bankAccountRepository = repository;
        }

        public async Task<IEnumerable<BankAccountDto>> GetAllAsync()
        {
            var accounts = await _bankAccountRepository.GetAllAsync();
            return accounts.Select(a => new BankAccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Balance = a.Balance,
            });
        }

        public async Task<BankAccountDto?> GetByIdAsync(Guid id)
        {
            var account = await _bankAccountRepository.GetByIdAsync(id);
            return account is null ? null : new BankAccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
            };
        }

        public async Task CreateAsync(BankAccountDto bankAccountDto)
        {
            var bankAccount = new BankAccount
            {
                Name = bankAccountDto.Name,
                Balance = bankAccountDto.Balance,
            };
            await _bankAccountRepository.AddAsync(bankAccount);
        }

        public async Task UpdateAsync(BankAccountDto bankAccountDto)
        {
            var bankAccount = new BankAccount
            {
                Id = bankAccountDto.Id,
                Name = bankAccountDto.Name,
                Balance = bankAccountDto.Balance,
            };
            await _bankAccountRepository.UpdateAsync(bankAccount);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bankAccountRepository.DeleteAsync(id);
        }
    }
}
