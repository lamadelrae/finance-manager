using FinanceManager.Domain.Base;
using System;

namespace FinanceManager.Domain.Months
{
    public class MonthIncome : Entity
    {
        public MonthIncome(Guid id, DateTime createdAt, bool isDeleted) : base(id, createdAt, isDeleted)
        {
        }
    }
}
