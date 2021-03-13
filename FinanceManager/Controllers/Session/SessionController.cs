using FinanceManager.Models;
using FinanceManager.Models.DataBase;
using FinanceManager.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Controllers.Session
{
    public class WebHelpers
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext HttpContext
        {
            get { return _httpContextAccessor.HttpContext; }
        }

        public static void SetSession(Users obj)
        {
            SessionModel session = new SessionModel();
            session.UserId = obj.Id;
            session.Username = obj.Username;

            HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(session));
        }

        public static void DestorySession()
        {
            HttpContext.Session.SetString("UserSession", string.Empty);
        }

        public static SessionModel GetSession()
        {
            string json = HttpContext.Session.GetString("UserSession");

            return JsonConvert.DeserializeObject<SessionModel>(json);
        }
    }
}
