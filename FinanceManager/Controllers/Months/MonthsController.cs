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
using FinanceManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View("MonthsForm", GetMonthViewModel(monthId));
        }

        public ActionResult AddBillToMonth(int monthId, int billId)
        {
            var dbObj = Repository.Context.Bills.Find(billId);

            Repository.Context.Months_Bills.Add(new Months_Bills
            {
                Bill_Id = dbObj.Id.IsNotNull(out int result) ? result : 0,
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Month_Id = monthId,
                Description = dbObj.Description,
                Value = dbObj.Value.ToString().MoneyToDecimal()
            });

            Repository.Context.SaveChanges();

            CalculateMonth(monthId);

            return Redirect($"EditMonth?monthId={monthId}");
        }

        public ActionResult AddIncomeToMonth(int monthId, int incomeId)
        {
            var dbObj = Repository.Context.Incomes.Find(incomeId);

            Repository.Context.Months_Incomes.Add(new Months_Incomes
            {
                Income_Id = dbObj.Id.IsNotNull(out int result) ? result : 0,
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Month_Id = monthId,
                Description = dbObj.Description,
                Value = dbObj.Value.ToString().MoneyToDecimal()
            });

            var monthObj = Repository.GetById(monthId);

            Repository.Context.SaveChanges();

            CalculateMonth(monthId);

            return Redirect($"EditMonth?monthId={monthId}");
        }

        public ActionResult RemoveIncomeFromMonth(int id)
        {
            var obj = Repository.Context.Months_Incomes.Find(id);

            Repository.Context.Months_Incomes.Remove(obj);

            Repository.Context.SaveChanges();

            CalculateMonth(obj.Month_Id);

            return Redirect($"EditMonth?monthId={obj.Month_Id}");
        }

        public ActionResult RemoveBillFromMonth(int id)
        {
            var obj = Repository.Context.Months_Bills.Find(id);

            Repository.Context.Months_Bills.Remove(obj);

            Repository.Context.SaveChanges();


            CalculateMonth(obj.Month_Id);

            return Redirect($"EditMonth?monthId={obj.Month_Id}");
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

        private void CalculateMonth(int monthId)
        {
            var dbObj = GetMonthObj(monthId);

            var calcObj = new CalcModel();

            calcObj.TotalIncome += dbObj.Month.Salary;

            Parallel.ForEach(dbObj.Months_Incomes, i => 
            {
                calcObj.TotalIncome += i.Value;
            });

            Parallel.ForEach(dbObj.Months_Bills, i => 
            {
                calcObj.TotalOutcome += i.Value;
            });

            dbObj.Month.TotalIncome = calcObj.TotalIncome;
            dbObj.Month.TotalOutcome = calcObj.TotalOutcome;
            dbObj.Month.TotalProfit = calcObj.TotalProfit;

            Repository.Context.SaveChanges();
        }

        private MonthsFormViewModel GetMonthViewModel(int monthId)
        {
            return GetMonthObj(monthId).Map(i => new MonthsFormViewModel
            {
                Id = i.Month.Id,
                Month = i.Month.Month.ToString("MM/yyyy"),
                Salary = i.Month.Salary.ToString(),
                SalaryIsManualInput = i.Month.SalaryIsManualInput,
                TotalIncome = i.Month.TotalIncome.ToString(),
                TotalOutcome = i.Month.TotalOutcome.ToString(),
                TotalProfit = i.Month.TotalProfit.ToString(),
                Months_Bills = i.Months_Bills.Select(i => new Months_BillsViewModel
                {
                    Id = i.Id,
                    MonthId = i.Month_Id,
                    Description = i.Description,
                    Value = i.Value.ToString()
                }).ToList(),
                Months_Incomes = i.Months_Incomes.Select(i => new Months_IncomesViewModel
                {
                    Id = i.Id,
                    MonthId = i.Month_Id,
                    Description = i.Description,
                    Value = i.Value.ToString()
                }).ToList(),
                Months_BillsDropDown = Repository.Context.Bills.ToList().Select(i => new SelectListItem 
                {
                    Text = i.Description,
                    Value = i.Id.ToString()
                }).ToList(),
                Months_IncomesDropDown = Repository.Context.Incomes.ToList().Select(i => new SelectListItem 
                {
                    Text = i.Description,
                    Value = i.Id.ToString()
                }).ToList()
            });
        }

        private MonthModel GetMonthObj(int monthId)
        {
            return new MonthModel
            {
                Month = Repository.GetById(monthId),
                Months_Bills = Repository.Context.Months_Bills.Where(i => i.Month_Id == monthId).ToList(),
                Months_Incomes = Repository.Context.Months_Incomes.Where(i => i.Month_Id == monthId).ToList()
            };
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