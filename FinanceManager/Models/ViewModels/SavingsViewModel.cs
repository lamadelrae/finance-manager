using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class SavingsViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string TotalAmount { get; set; }

        public string LastTransaction { get; set; }
    }

    public class SavingsFormViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string TotalAmount { get; set; }

        public TransactionsFormViewModel TransactionForm { get; set; }

        public List<TransactionsViewModel> Transactions { get; set; } = new List<TransactionsViewModel>();
    }

    public class TransactionsFormViewModel
    { 
        public string Description { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string InputDate { get; set; }
    }

    public class TransactionsViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string InputDate { get; set; }
    }
}
