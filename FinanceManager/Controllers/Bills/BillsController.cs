using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Bills
{
    public class BillsController : Controller
    {
        public ActionResult Bills()
        {
            return View();
        }
    }
}
