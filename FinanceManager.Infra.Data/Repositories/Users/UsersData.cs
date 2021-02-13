using FinanceManager.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using FinanceManager.Domain.Database.Users;
using System.Linq;

namespace FinanceManager.Infra.Data.Repositories.Users
{
    public class UsersData : BaseRepository<Domain.Database.Users.Users>
    {
        public Domain.Database.Users.Users GetByName(string name) =>
            Context.Users.Where(i => i.Username == name).FirstOrDefault();

    }
}
