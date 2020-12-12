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

            return new HomeViewModel
            {
                BillsCount = Context.Months_Bills.ToList().Count(i => i.User_Id == sessionObj.UserId),
                IncomesCount = Context.Months_Incomes.ToList().Count(i => i.User_Id == sessionObj.UserId),
                TotalBillsPaid = Context.Bills.Where(i => i.User_Id == sessionObj.UserId).Max(k => k.Value).ToString("C3"),
                TotalIncomesPaid = Context.Incomes.Where(i => i.User_Id == sessionObj.UserId).Max(k => k.Value).ToString("C3")
            };
        }
    }
}
