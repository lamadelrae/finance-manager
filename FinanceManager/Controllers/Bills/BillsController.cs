using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Utilities.Extensions;

namespace FinanceManager.Controllers.Bills
{
    public class BillsController : Controller
    {
        BaseRepository<Models.DataBase.Bills> Repository = new BaseRepository<Models.DataBase.Bills>();

        public ActionResult Bills()
        {
            return View(GetBills());
        }

        public ActionResult NewBill()
        {
            return View("BillForm");
        }

        public ActionResult AddBill(Models.DataBase.Bills billObj)
        {
            billObj.User_Id = Session.SessionController.GetInstance.Session.UserId;
            billObj.Value = billObj.Value.ToString().MoneyToDecimal();

            Repository.Insert(billObj);

            return Redirect("Bills");
        }

        private List<BillsViewModel> GetBills()
        {
            return Repository.GetAll().Select(i => new BillsViewModel
            {
                Id = i.Id.ToString(),
                Username = Repository.Context.Users.Find(i.User_Id).Username,
                Description = i.Description,
                Value = i.Value.ToString()
            }).ToList();
        }
    }
}
