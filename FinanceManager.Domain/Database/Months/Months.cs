using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Domain.DataBase.Months
{
    public class Months
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }

        public DateTime Month { get; set; }

        public decimal Salary { get; set; }

        public bool SalaryIsManualInput { get; set; }

        public decimal TotalIncome { get; set; }

        public decimal TotalOutcome { get; set; }

        public decimal TotalProfit { get; set; }
    }
}
