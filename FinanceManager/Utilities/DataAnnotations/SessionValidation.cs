using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Controllers.Session;
using FinanceManager.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinanceManager.Utilities.DataAnnotations
{
    public class SessionValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WebHelpers.GetSession().IsNull())
                filterContext.Result = new RedirectResult("/");
        }
    }
}
