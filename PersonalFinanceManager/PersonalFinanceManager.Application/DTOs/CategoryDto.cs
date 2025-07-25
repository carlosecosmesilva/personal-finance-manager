using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceManager.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsIncomeCategory { get; set; } // True for income categories, false for expense categories
        public Guid BankAccountId { get; set; } // Associated bank account ID
    }
}
