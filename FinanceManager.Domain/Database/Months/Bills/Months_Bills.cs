using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Domain.DataBase.Months.Bills
{
    public class Months_Bills
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }

        public int Month_Id { get; set; }

        public int Bill_Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }
}
