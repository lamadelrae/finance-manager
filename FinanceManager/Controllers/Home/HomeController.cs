using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Utilities.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;

namespace FinanceManager.Controllers
{
    [SessionValidation]
    public class HomeController : Controller
    {
        public DatabaseContext Context = new DatabaseContext();

        public ActionResult Home()
        {
            return View(GetViewModel());
        }

        private HomeViewModel GetViewModel()
        {
            var sessionObj = SessionController.GetInstance.Session;

            var billsPaid = Context.Months_Bills.ToList();
            var incomesPaid = Context.Months_Incomes.ToList();
            var bills = Context.Bills.Where(i => i.User_Id == sessionObj.UserId);
            var incomes = Context.Incomes.Where(i => i.User_Id == sessionObj.UserId);

            return new HomeViewModel
            {
                BillsCount = bills.Count() > 0 ? bills.Count(i => i.User_Id == sessionObj.UserId) : 0,
                IncomesCount = incomes.Count() > 0 ? incomes.Count(i => i.User_Id == sessionObj.UserId) : 0,
                TotalBillsPaid = billsPaid.Count() > 0 ? billsPaid.Max(i => i.Value).ToString("C3") : "0",
                TotalIncomesPaid = incomesPaid.Count() > 0 ? incomesPaid.Max(i => i.Value).ToString("C3") : "0"
            };
        }
    }
}
