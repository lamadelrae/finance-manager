using FinanceManager.Infrastructure.Data.DataRecords.Base;
using System;

namespace FinanceManager.Infrastructure.Data.DataRecords.Months
{
    internal class MonthExpense : DataRecord
    {
        public Guid MonthId { get; set; }

        public Guid ExpenseId { get; set; }

        public decimal Value { get; set; }

        public string Description { get; set; }
    }
}
