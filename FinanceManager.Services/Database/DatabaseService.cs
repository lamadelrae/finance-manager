using FinanceManager.Infra.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Database
{
    public class DatabaseService
    {
        DatabaseData DatabaseData = new DatabaseData();

        public bool DbNotExists() => DatabaseData.GetDatabaseName() != "FinanceManager";

        public bool DbNotRequiredVersion() => DatabaseData.GetDbVersion() != DatabaseData.DbVersion;

        public void CheckDb()
        {
            if (DbNotExists())
                DatabaseData.CreateDatabase();
            if (DbNotRequiredVersion())
                DatabaseData.UpdateDatabase();
        }
    }
}
