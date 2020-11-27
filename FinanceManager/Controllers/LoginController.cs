using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using System.Linq;
using FinanceManager.Models;
using FinanceManager.Utilities.Extensions;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;
using System;
using FinanceManager.Models.Exeptions;

namespace FinanceManager.Controllers.Login
{
    public class LoginController : Controller
    {

        public FinanceManagerContext context = new FinanceManagerContext();

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
                if (context.Users.ToList().Count() == 0)
                    throw new FirstAccessException("No users in DataBase, please register.");

                var userObj = context.Users.Where(i => loginObj.Username == loginObj.Username).FirstOrDefault();

                if (IsLoginOk(loginObj, userObj))
                {
                    SessionController.GetInstance.SetSession(userObj);

                    return View("Home");
                }
                else
                    throw new Exception("Wrong password");
            }
            catch (Exception ex)
            {
                ViewBag.IsFirstAccess = ex is FirstAccessException;

                return View("Login");
            }

        }

        public bool IsLoginOk(LoginViewModel loginObj, Users userObj)
        {
            if (userObj.IsNull())
                throw new Exception("User not found.");

            return loginObj.Password.ToSha256() == userObj.Password;
        }
    }
}