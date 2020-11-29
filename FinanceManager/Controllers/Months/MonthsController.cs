using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Months
{
    public class MonthsController : Controller
    {
        public ActionResult Months()
        {
            return View();
        }
    }
}
