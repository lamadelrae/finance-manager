using System;

namespace FinanceManager.Infrastructure.Data.DataRecords.Months
{
    internal class MonthIncome
    {
        public Guid MonthId { get; set; }

        public Guid IncomeId { get; set; }

        public decimal Value { get; set; }

        public string Description { get; set; }
    }
}
