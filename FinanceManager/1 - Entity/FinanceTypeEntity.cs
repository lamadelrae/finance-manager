using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager._1___Entity
{
    public class FinanceTypeEntity
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public Types Types { get; set; }
        public decimal Price { get; set; }
        public char Status { get; set; }
    }

    public enum Types
    { 
        gain, 
        debt
    }
}
