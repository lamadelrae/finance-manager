using FinanceManager.Infra.Crosscutting.Extenstions;
using FinanceManager.Infra.Data.Repositories.Users;
using FinanceManager.Services.Database;
using FinanceManager.Services.DTO.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Services.Users
{
    public class UsersService
    {
        DatabaseService DatabaseService = new DatabaseService();

        UsersData UsersData = new UsersData();

        public void Login(UserDTO user)
        {
            DatabaseService.CheckDb();

            var userObj = UsersData.GetByName(user.Name);

            userObj.IsNull().Then(() => throw new Exception("No user in database"));
        }
    }
}
