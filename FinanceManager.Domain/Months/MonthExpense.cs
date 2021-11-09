using FinanceManager.Domain.Base;
using System;

namespace FinanceManager.Domain.Months
{
    public class MonthExpense : Entity
    {
        public MonthExpense(Guid id, DateTime createdAt, bool isDeleted) : base(id, createdAt, isDeleted)
        {
        }
    }
}
