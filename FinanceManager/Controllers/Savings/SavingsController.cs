using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;
using FinanceManager.Utilities.Extensions;

namespace FinanceManager.Controllers.Savings
{
    public class SavingsController : Controller
    {
        BaseRepository<Models.DataBase.Savings> BaseRepository = new BaseRepository<Models.DataBase.Savings>();

        public ActionResult Savings()
        {
            return View("Savings", GetSavings());
        }

        public ActionResult NewSavings()
        {
            return View("SavingsForm", new SavingsFormViewModel());
        }

        public ActionResult EditSavings(int id)
        {
            return View("SavingsForm", GetSavingsObj(BaseRepository.GetById(id)));
        }

        public ActionResult SubmitSavings(SavingsFormViewModel viewModelObj)
        {
            if (viewModelObj.Id.IsNotNull())
                return AddSavings(viewModelObj);
            else
                return UpdateSavings(viewModelObj);
        }

        private ActionResult AddSavings(SavingsFormViewModel viewModelObj)
        {
            BaseRepository.Insert(new Models.DataBase.Savings
            {
                User_Id = SessionController.GetInstance.Session.UserId,
                Description = viewModelObj.Description,
                DateCreated = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            return Redirect("Savings");
        }

        private ActionResult UpdateSavings(SavingsFormViewModel viewModelObj)
        {
            var savingsObj = BaseRepository.GetById(viewModelObj.Id.ToInt());
            savingsObj.Description = viewModelObj.Description;
            savingsObj.LastModifiedDate = DateTime.Now;

            return Redirect("Savings");
        }

        private SavingsFormViewModel GetSavingsObj(Models.DataBase.Savings savingsObj)
        {
            return savingsObj.Map(i => new SavingsFormViewModel 
            {
                Id = i.Id.ToString(),
                Description = i.Description,
                Transactions = BaseRepository.Context.Savings_Transactions.Select(k => new SavingsFormTransactionViewModel 
                {
                    Id = k.Id.ToString(),
                    Description = k.Description,
                    Value = k.Description
                }).ToList()
            });
        }

        private List<SavingsViewModel> GetSavings()
        {
            List<SavingsViewModel> savingsList = new List<SavingsViewModel>();

            var savings = BaseRepository.Context.Savings
                .Where(i => i.User_Id == SessionController.GetInstance.Session.UserId).ToList();

            foreach (var saving in savings)
            {
                var lastTransaction = BaseRepository.Context.Savings_Transactions
                    .Where(i => i.Savings_Id == saving.Id).ToList().LastOrDefault();

                savingsList.Add(new SavingsViewModel
                {
                    Description = saving.Description,
                    TotalAmount = saving.TotalAmount.ToString(),
                    LastTransaction = lastTransaction.IsNull() ? "No transaction Found." : $"{lastTransaction.Description} || {lastTransaction.InputDate}"
                });
            }

            return savingsList;
        }
    }
}