using FinanceManager.Domain.Base;
using System;

namespace FinanceManager.Domain.Expenses
{
    public class Expense : Entity
    {
        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public Expense(Guid id,
                       DateTime createdAt,
                       bool isDeleted,
                       string description,
                       decimal value) : base(id, createdAt, isDeleted)
        {
            Description = description;
            Value = value;
        }
    }
}
