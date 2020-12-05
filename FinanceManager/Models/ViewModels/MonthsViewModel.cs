using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class MonthsViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Month { get; set; }

        public string TotalIncome { get; set; }

        public string TotalOutcome { get; set; }
    }
}
