using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Models.ViewModels;
using FinanceManager.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers
{
    public class IncomesController : Controller
    {
        BaseRepository<Models.DataBase.Incomes> Repository = new BaseRepository<Models.DataBase.Incomes>();

        public ActionResult Incomes()
        {
            return View(GetIncomes());
        }

        public ActionResult NewIncome()
        {
            return View("IncomeForm");
        }

        public ActionResult EditIncome(int id)
        {
            var dbObj = Repository.GetById(id);

            var incomeViewModel = new IncomeFormViewModel
            {
                Id = dbObj.Id.ToString(),
                Description = dbObj.Description,
                Value = dbObj.Value.ToString()
            };

            return View("IncomeForm", incomeViewModel);
        }

        public ActionResult SubmitIncome(IncomeFormViewModel incomeViewModel)
        {
            if (incomeViewModel.Id.IsNotNull())
                return UpdateIncome(incomeViewModel);
            else
                return AddIncome(incomeViewModel);
        }

        private ActionResult UpdateIncome(IncomeFormViewModel incomeViewModel)
        {
            var incomeObj = new Models.DataBase.Incomes
            {
                Id = incomeViewModel.Id.ToInt(),
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Description = incomeViewModel.Description,
                Value = incomeViewModel.Value.MoneyToDecimal()
            };

            Repository.Update(incomeObj);

            return Redirect("Incomes");
        }

        private ActionResult AddIncome(IncomeFormViewModel incomeViewModel)
        {
            var incomeObj = new Models.DataBase.Incomes
            {
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Description = incomeViewModel.Description,
                Value = incomeViewModel.Value.MoneyToDecimal()
            };

            Repository.Insert(incomeObj);

            return Redirect("Incomes");
        }

        private List<IncomesViewModel> GetIncomes()
        {
            return Repository.GetAll().Select(i => new IncomesViewModel
            {
                Id = i.Id.ToString(),
                Username = Repository.Context.Users.Find(i.User_Id).Username,
                Description = i.Description,
                Value = i.Value.ToString()
            }).ToList();
        }
    }
}
