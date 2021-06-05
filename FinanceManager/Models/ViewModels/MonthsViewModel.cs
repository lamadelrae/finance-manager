using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class MonthsViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Month { get; set; }

        public string TotalIncome { get; set; }

        public string TotalExpense { get; set; }
    }

    public class MonthsFormViewModel
    {
        public int Id { get; set; }

        public string Month { get; set; }

        public string TotalIncome { get; set; }

        public string TotalExpense { get; set; }

        public string TotalProfit { get; set; }

        public string Salary { get; set; }

        public bool SalaryIsManualInput { get; set; }

        public List<Months_BillsViewModel> Months_Bills { get; set; } = new List<Months_BillsViewModel>();

        public List<Months_IncomesViewModel> Months_Incomes { get; set; } = new List<Months_IncomesViewModel>();

        public List<SelectListItem> Months_BillsDropDown { get; set; }

        public List<SelectListItem> Months_IncomesDropDown { get; set; }
    }

    public class Months_BillsViewModel
    {
        public int Id { get; set; }

        public int MonthId { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }
    }

    public class Months_IncomesViewModel
    {
        public int Id { get; set; }

        public int MonthId { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }
    }
}
