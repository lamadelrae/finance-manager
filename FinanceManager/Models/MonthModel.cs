using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Models.DataBase;

namespace FinanceManager.Models
{
    public class MonthModel
    {
        public Months Month { get; set; }

        public List<Months_Bills> Months_Bills { get; set; }

        public List<Months_Incomes> Months_Incomes { get; set; }
    }
}
