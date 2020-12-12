using FinanceManager.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.ViewModels
{
    public class SettingsViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<Users> UsersList { get; set; } = new List<Users>();
    }
}
