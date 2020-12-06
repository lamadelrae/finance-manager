using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using System.Linq;
using FinanceManager.Models;
using FinanceManager.Utilities.Extensions;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;
using System;
using FinanceManager.Models.Exeptions;
using System.Threading.Tasks;

namespace FinanceManager.Controllers.Login
{
    public class LoginController : Controller
    {
        public DatabaseContext context = new DatabaseContext();

        public ActionResult Login()
        {
            ViewBag.IsFirstAccess = false;

            return View();
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult SubmitLogin(LoginViewModel loginObj)
        {
            try
            {
                var db = new DatabaseController();

                if (db.DbNotExists())
                    db.CreateDatabase();

                if (db.DbIsNotRequiredVersion())
                    db.UpdateDatabase();

                if (context.Users.ToList().Count() == 0)
                    throw new FirstAccessException("No users in DataBase, please register.");

                var userObj = context.Users.Where(i => i.Username == loginObj.Username).FirstOrDefault();

                if (IsLoginOk(loginObj, userObj))
                {
                    if (LastYearIsNotThisYear())
                        InsertMonths(userObj.Id);

                    SessionController.GetInstance.SetSession(userObj);

                    return Redirect("/Home/Home");
                }
                else
                    throw new Exception("Wrong password");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                ViewBag.IsFirstAccess = ex is FirstAccessException;

                return View("Login");
            }
        }

        private bool IsLoginOk(LoginViewModel loginObj, Users userObj)
        {
            if (userObj.IsNull())
                throw new Exception("User not found.");

            return loginObj.Password.Trim().ToSha256() == userObj.Password;
        }

        public ActionResult SaveUser(RegisterViewModel registerObj)
        {
            try
            {
                context.Users.Add(new Users
                {
                    Username = registerObj.Username,
                    Password = registerObj.Password.Trim().ToSha256(),
                    Salary = registerObj.Salary.MoneyToDecimal(),
                    MaxExpenses = registerObj.MaxExpenses.MoneyToDecimal()
                });

                context.SaveChanges();

                ViewBag.IsFirstAccess = false;

                return View("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("Regiser");
            }
        }

        public bool LastYearIsNotThisYear()
        {
            var lastMonth = context.Months.ToList();

            if (lastMonth.Count == 0)
                return true;
            else
                return lastMonth.OrderByDescending(i => i.Month)
                    .Take(1).FirstOrDefault()
                    .Month.Year < DateTime.Now.Year;
        }

        public void InsertMonths(int userId)
        {
            for (int i = 1; i <= 12; i++)
            {
                context.Months.Add(new Models.DataBase.Months
                {
                    User_Id = userId,
                    Month = Convert.ToDateTime($"{DateTime.Now.Year}-{i}-01"),
                    TotalIncome = 0,
                    TotalOutcome = 0,
                    TotalProfit = 0,
                    Salary = 0,
                    SalaryIsManualInput = false
                });
            }

            context.SaveChanges();
        }
    }
}