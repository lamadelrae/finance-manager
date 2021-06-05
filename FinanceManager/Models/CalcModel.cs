using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models
{
    public class CalcModel
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal TotalProfit
        {
            get
            {
                return TotalIncome - TotalExpense;
            }
        }
    }
}
