using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Utilities.DataAnnotations;
using FinanceManager.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Settings
{
    [SessionValidation]
    public class SettingsController : Controller
    {
        BaseRepository<Users> Repository = new BaseRepository<Users>();

        public ActionResult Settings() => View("Settings", GetViewModel());

        public ActionResult UpdateUser(Users userObj)
        {
            var dbObj = Repository.GetById(userObj.Id);

            dbObj.Username = userObj.Username;
            dbObj.Password = userObj.Password.ToSha256();

            Repository.Context.SaveChanges();

            return Redirect(@"\Settings\Settings");
        }

        private SettingsViewModel GetViewModel()
        {
            var userObj = Repository.GetById(Session.SessionController.GetInstance.Session.UserId);

            return new SettingsViewModel
            {
                Id = userObj.Id,
                Username = userObj.Username,
                UsersList = Repository.GetAll()
            };
        }
    }
}
