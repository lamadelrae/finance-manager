using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;
using FinanceManager.Controllers.Session;
using FinanceManager.Utilities.Extensions;
using FinanceManager.Models;
using FinanceManager.Utilities.DataAnnotations;

namespace FinanceManager.Controllers.Savings
{
    [SessionValidation]
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
                return UpdateSavings(viewModelObj);
            else
                return AddSavings(viewModelObj);
        }

        public ActionResult AddTransaction(SavingsFormViewModel savingsObj)
        {
            BaseRepository.Context.Savings_Transactions.Add(new Savings_Transactions
            {
                Savings_Id = savingsObj.Id.ToInt(),
                User_Id = WebHelpers.GetSession().UserId,
                Description = savingsObj.TransactionForm.Description,
                InputDate = savingsObj.TransactionForm.InputDate.ToDateTime(),
                TransactionDate = DateTime.Now,
                Type = savingsObj.TransactionForm.Type,
                Value = savingsObj.TransactionForm.Value.MoneyToDecimal()
            });

            BaseRepository.Context.SaveChanges();

            CalculateSavings(savingsObj.Id.ToInt());

            return Redirect($"EditSavings?id={savingsObj.Id}");
        }

        private void CalculateSavings(int savingsId)
        {
            List<Savings_Transactions> savingsList = BaseRepository.Context.Savings_Transactions
                .Where(i => i.Savings_Id == savingsId)
                .ToList();

            CalcModel calcObj = new CalcModel();

            foreach (var transaction in savingsList)
            {
                if (transaction.Type == "I")
                    calcObj.TotalIncome += transaction.Value;
                else
                    calcObj.TotalOutcome += transaction.Value;
            }

            Models.DataBase.Savings savingsObj = BaseRepository.GetById(savingsId);
            savingsObj.TotalAmount = calcObj.TotalProfit;

            BaseRepository.Context.SaveChanges();
        }

        private ActionResult AddSavings(SavingsFormViewModel viewModelObj)
        {
            BaseRepository.Insert(new Models.DataBase.Savings
            {
                User_Id = WebHelpers.GetSession().UserId,
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

            BaseRepository.Context.SaveChanges();

            return Redirect("Savings");
        }

        private SavingsFormViewModel GetSavingsObj(Models.DataBase.Savings savingsObj)
        {
            return savingsObj.Map(i => new SavingsFormViewModel
            {
                Id = i.Id.ToString(),
                Description = i.Description,
                Transactions = BaseRepository.Context.Savings_Transactions.Where(u => u.Savings_Id == i.Id).Select(k => new TransactionsViewModel
                {
                    Id = k.Id.ToString(),
                    Description = k.Description,
                    Type = k.Type,
                    Value = k.Value.ToString("C3"),
                    InputDate = k.InputDate.ToString("dd/MM/yyyy")
                }).ToList(),
                TotalAmount = savingsObj.TotalAmount.ToString("C3")
            });
        }

        private List<SavingsViewModel> GetSavings()
        {
            List<SavingsViewModel> savingsList = new List<SavingsViewModel>();

            var savings = BaseRepository.Context.Savings
                .Where(i => i.User_Id == WebHelpers.GetSession().UserId).ToList();

            foreach (var saving in savings)
            {
                var lastTransaction = BaseRepository.Context.Savings_Transactions
                    .Where(i => i.Savings_Id == saving.Id).ToList().LastOrDefault();

                savingsList.Add(new SavingsViewModel
                {
                    Id = saving.Id.ToString(),
                    Description = saving.Description,
                    TotalAmount = saving.TotalAmount.ToString(),
                    LastTransaction = lastTransaction.IsNull() ? "No transaction Found." : $"{lastTransaction.Description} || {lastTransaction.InputDate}"
                });
            }

            return savingsList;
        }
    }
}