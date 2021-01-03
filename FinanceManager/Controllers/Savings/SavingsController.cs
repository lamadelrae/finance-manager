using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Savings
{
    public class SavingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
