using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.ViewModels;

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
            return View("SavingsForm");
        }

        private List<SavingsViewModel> GetSavings()
        {
            List<SavingsViewModel> savingsList = new List<SavingsViewModel>();

            BaseRepository.Context.Savings.Where(k => k.User_Id == Session.SessionController.GetInstance.Session.UserId).AsParallel().ForAll(i =>
            {
                Savings_Transactions lastTransaction = BaseRepository.Context.Savings_Transactions
                .Where(k => k.Savings_Id == i.Id)
                .ToList()
                .LastOrDefault();

                savingsList.Add(new SavingsViewModel
                {
                    Description = i.Description,
                    LastTransaction = $"{lastTransaction.Description}|{lastTransaction.InputDate}",
                    TotalAmount = i.TotalAmount.ToString()
                });
            });

            return savingsList;
        }
    }
}
