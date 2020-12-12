using FinanceManager.Models;
using FinanceManager.Models.DataBase;
using FinanceManager.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Controllers.Session
{
    public sealed class SessionController
    {
        SessionController(){ }

        public SessionModel Session { get; private set; }

        private static SessionController Instance = null;

        public static SessionController GetInstance
        {
            get
            {
                if (Instance.IsNull())
                    Instance = new SessionController();

                return Instance;
            }
        }

        public void SetSession(Users userObj)
        {
            if (Session.IsNull())
                Session = new SessionModel();

            Session.UserId = userObj.Id;
            Session.Username = userObj.Username;
        }
        
        public void DestroyInstance()
        {
            Session = null;
            Instance = null;
        }
    }
}
