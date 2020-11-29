using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FinanceManager.Models.DataBase;
using FinanceManager.Utilities.Extensions;

namespace FinanceManager.Controllers
{
    public class DatabaseController : Controller
    {
        public ActionResult Database()
        {
            return View("Database");
        }

        public ActionResult AttachDataBase()
        {
            try
            {
                var connection = new SqlConnection(Models.DataBase.FinanceManagerContext.GetServerConnection());

                string command = $@"CREATE DATABASE FinanceManager ON PRIMARY 
                                   (NAME = FinanceManager, 
                                   FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}\FinanceManager.mdf', 
                                   SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)
                                   LOG ON (NAME = FinanceManager_Log, 
                                   FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}\FinanceManager_Log.ldf', 
                                   SIZE = 1MB, 
                                   MAXSIZE = 5MB, 
                                   FILEGROWTH = 10%)
								   FOR ATTACH;";

                var sqlCommand = new SqlCommand(command, connection);

                connection.Open();
                sqlCommand.ExecuteNonQuery();

                return View("~/Views/Login/Login.cshtml");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDatabase()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                if (DbNotExists())
                    new SqlCommand(DatabaseVersionQueries.QueryDictionary[1], con);

                if (DbIsNotRequiredVersion())
                {
                    con.Open();

                    var queryList = DatabaseVersionQueries.QueryDictionary
                        .Where(i => i.Key > GetDbVersion().ToInt()).ToList();

                    Parallel.ForEach(queryList, query =>
                    {
                        new SqlCommand(query.Value, con);
                    });

                    con.Close();
                }
            }
        }

        public bool DbNotExists()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                string query = @"SELECT name 
                                 FROM master.dbo.sysdatabases 
                                 WHERE ('[' + name + ']' = 'FinanceManager'
                                 OR name = 'FinanceManager')";

                var sqlCommand = new SqlCommand(query, con);

                con.Open();
                var reader = sqlCommand.ExecuteReader();
                con.Close();

                return (string)reader["name"] == "FinanceManager";
            }
        }

        public string GetDbVersion()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                string query = @"SELECT * FROM DatabaseVersion";

                var sqlCommand = new SqlCommand(query, con);

                string version = string.Empty;
                con.Open();
                var result = sqlCommand.ExecuteReader();

                while (result.IsNotNull())
                    version = (string)result["DbVersion"];

                con.Close();

                return version;
            }
        }

        public bool DbIsNotRequiredVersion()
        {
            return GetDbVersion() == FinanceManagerContext.DbVersion;
        }
    }
}
