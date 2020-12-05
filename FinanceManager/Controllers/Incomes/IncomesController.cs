using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers
{
    public class IncomesController : Controller
    {
        public ActionResult Incomes()
        {
            return View();
        }
    }
}
