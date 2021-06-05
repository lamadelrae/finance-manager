using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Utilities.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;
using FinanceManager.Models;

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
            SessionModel session = WebHelpers.GetSession();
            List<Months_Bills> billsPaid = Context.Months_Bills.Where(i => i.User_Id == session.UserId).ToList();
            List<Months_Incomes> incomesPaid = Context.Months_Incomes.Where(i => i.User_Id == session.UserId).ToList();

            return new HomeViewModel
            {
                BillsCount = billsPaid.Count(),
                IncomesCount = incomesPaid.Count(),
                TotalBillsPaid =  billsPaid.Sum(i => i.Value).ToString("C3"),
                TotalIncomesPaid = incomesPaid.Sum(i => i.Value).ToString("C3") 
            };
        }
    }
}
