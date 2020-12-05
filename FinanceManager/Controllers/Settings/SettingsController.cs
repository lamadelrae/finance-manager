using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Settings
{
    public class SettingsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
