using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.DataBase
{
    public class Savings_Transactions
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public int Savings_Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime InputDate { get; set; }

    }
}
