using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class HomeViewModel
    {
        public int BillsCount { get; set; }

        public int IncomesCount { get; set; }

        public string TotalBillsPaid {get; set;}

        public string TotalIncomesPaid { get; set; }
    }
}
