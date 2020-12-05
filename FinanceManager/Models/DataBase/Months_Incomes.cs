using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.DataBase
{
    public class Months_Incomes
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public int Month_Id { get; set; }

        public int Income_Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }
}
