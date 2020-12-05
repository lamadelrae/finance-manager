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

        public ActionResult EditBill(int id)
        {
            var dbObj = Repository.GetById(id);

            var billViewModel = new BillViewModel
            {
                Id = dbObj.Id.ToString(),
                Description = dbObj.Description,
                Value = dbObj.Value.ToString()
            };

            return View("BillForm", billViewModel);
        }

        public ActionResult SubmitBill(BillViewModel billViewModel)
        {
            if (billViewModel.Id.IsNotNull())
                return UpdateBill(billViewModel);
            else
                return AddBill(billViewModel);
        }

        private ActionResult UpdateBill(BillViewModel billViewModel)
        {
            var billObj = new Models.DataBase.Bills
            {
                Id = billViewModel.Id.ToInt(),
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Description = billViewModel.Description,
                Value = billViewModel.Value.MoneyToDecimal()
            };

            Repository.Update(billObj);

            return Redirect("Bills");
        }

        private ActionResult AddBill(BillViewModel billViewModel)
        {
            var billObj = new Models.DataBase.Bills
            {
                User_Id = Session.SessionController.GetInstance.Session.UserId,
                Description = billViewModel.Description,
                Value = billViewModel.Value.MoneyToDecimal()
            };

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
