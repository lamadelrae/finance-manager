using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Utilities.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers
{
    [SessionValidation]
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}
