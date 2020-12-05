using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Utilities.Extensions;
using FinanceManager.Utilities.DataAnnotations;
using System.Linq.Expressions;

namespace FinanceManager.Controllers.Months
{
    [SessionValidation]
    public class MonthsController : Controller
    {
        private BaseRepository<Models.DataBase.Months> Repository = new BaseRepository<Models.DataBase.Months>();

        public ActionResult Months()
        {
            try
            {
                return View(GetAllMonths());
            }
            catch (Exception ex)
            {
                ViewBag.Messahe = ex.Message;

                return View("Months", new List<MonthsViewModel>());
            }
        }

        public ActionResult EditMonth(int monthId)
        {
            return View("MonthsForm", GetMonthObj(monthId));
        }

        public ActionResult AddBillToMonth(Months_BillsViewModel billObj)
        {
            Repository.Context.Months_Bills.Add(new Months_Bills
            {
                Bill_Id = billObj.Id.IsNotNull(out int result) ? result : 0,
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Month_Id = billObj.MonthId,
                Description = billObj.Description,
                Value = billObj.Value.MoneyToDecimal()
            });

            return Redirect($"MonthsForm?monthId={billObj.MonthId}");
        }

        public ActionResult AddIncomeToMonth(Months_IncomesViewModel incomeObj)
        {
            Repository.Context.Months_Incomes.Add(new Months_Incomes
            {
                Income_Id = incomeObj.Id.IsNotNull(out int result) ? result : 0,
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Month_Id = incomeObj.MonthId,
                Description = incomeObj.Description,
                Value = incomeObj.Value.MoneyToDecimal()
            });

            return Redirect($"MonthsForm?monthId={incomeObj.MonthId}");
        }

        public ActionResult Search(DateTime initialDate, DateTime finalDate)
        {
            try
            {
                return View("Months", GetMonthsByDate(initialDate, finalDate));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("Months", new List<MonthsViewModel>());
            }
        }

        private MonthsFormViewModel GetMonthObj(int monthId)
        {
            return Repository.GetById(monthId).Map(i => new MonthsFormViewModel
            {
                Id = i.Id,
                TotalIncome = i.TotalIncome,
                TotalOutcome = i.TotalOutcome,
                Months_Bills = Repository.Context.Months_Bills.Select(i => new Months_BillsViewModel
                {
                    Id = i.Id,
                    MonthId = i.Month_Id,
                    Description = i.Description,
                    Value = i.Value.ToString()
                }).ToList(),
                Months_Incomes = Repository.Context.Months_Incomes.Select(i => new Months_IncomesViewModel
                {
                    Id = i.Id,
                    MonthId = i.Month_Id,
                    Description = i.Description,
                    Value = i.Value.ToString()
                }).ToList()
            });
        }

        private List<MonthsViewModel> GetAllMonths()
        {
            return Repository.GetAll().Select(i => new MonthsViewModel
            {
                Id = i.Id.ToString(),
                Username = Repository.Context.Users.Find(i.User_Id).Username,
                Month = i.Month.ToString("MM/yyyy"),
                TotalIncome = i.TotalIncome.ToString(),
                TotalOutcome = i.TotalOutcome.ToString()
            }).ToList();
        }

        private List<MonthsViewModel> GetMonthsByDate(DateTime initialDate, DateTime finalDate)
        {
            if (initialDate == DateTime.MinValue)
                throw new Exception("Fill the Initial Date at least");

            Expression<Func<Models.DataBase.Months, bool>> expression = i => i.Month > initialDate;

            if (finalDate != DateTime.MinValue)
                expression = expression.And(i => i.Month < finalDate);

            var listMonths = Repository.Context.Months.Where(expression).ToList();

            return listMonths.Select(i => new MonthsViewModel
            {
                Id = i.Id.ToString(),
                Month = i.Month.ToString("MM/yyyy"),
                Username = Repository.Context.Users.Find(i.User_Id).Username,
                TotalIncome = i.TotalIncome.ToString(),
                TotalOutcome = i.TotalOutcome.ToString()
            }).ToList();
        }
    }
}
