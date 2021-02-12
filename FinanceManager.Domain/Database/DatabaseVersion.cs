using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Domain.DataBase
{
    public class DatabaseVersion
    {
        [Key]
        public string DbVersion { get; set; }
    }
}
