using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salary { get; set; }

        public string MaxExpenses { get; set; }
    }
}
