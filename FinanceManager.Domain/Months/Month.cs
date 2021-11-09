using FinanceManager.Domain.Base;
using System;
using System.Collections.Generic;

namespace FinanceManager.Domain.Months
{
    public class Month : Entity
    {
        public DateTime Date { get; private set; }

        public List<MonthExpense> MonthExpenses { get; private set; }

        public List<MonthIncome> MonthIncomes { get; private set; }

        public Month(Guid id, 
                     DateTime createdAt, 
                     bool isDeleted, 
                     DateTime date,
                     List<MonthExpense> monthExpenses,
                     List<MonthIncome> monthIncomes) : base(id, createdAt, isDeleted) 
        {
            Date = date;
            MonthExpenses = monthExpenses;
            MonthIncomes = monthIncomes;
        }

        public void AddExpense(MonthExpense expense)
            => MonthExpenses.Add(expense);

        public void AddIncome(MonthIncome income)
            => MonthIncomes.Add(income);

        public void RemoveExpense(Guid id)
            => MonthExpenses.Remove(MonthExpenses.Find(x => x.Id == id));

        public void RemoveIncome(Guid id)
            => MonthIncomes.Remove(MonthIncomes.Find(x => x.Id == id));
    }
}
