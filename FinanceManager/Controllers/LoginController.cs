using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers.Login
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
    }
}