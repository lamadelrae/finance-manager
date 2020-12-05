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
