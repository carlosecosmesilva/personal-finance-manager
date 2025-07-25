using PersonalFinanceManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public TransactionType Type { get; set; } // Income or Expense
    }
}
