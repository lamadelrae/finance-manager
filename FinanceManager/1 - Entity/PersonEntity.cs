using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Entity
{
    public class PersonEntity
    {
        [Key]
        public Guid UUID { get; set; }

        public string PersonName { get; set; }

        public int PersonAge { get; set; }

        public decimal PersonMonthlyIncome { get; set; }

        public string Status { get; set; }
    }
}
