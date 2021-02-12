using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Database.Savings
{
    public class Savings
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModifiedDate { get; set; }

    }
}
