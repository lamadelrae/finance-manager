using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FinanceManager.Models.DataBase;
using FinanceManager.Utilities.Extensions;
using System.Data.SqlClient;

namespace FinanceManager.Controllers
{
    public class DatabaseController : Controller
    {
        public ActionResult Database()
        {
            return View("Database");
        }

        public bool DbNotExists()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetServerConnection()))
            {
                string query = @"SELECT name 
                                 FROM master.dbo.sysdatabases 
                                 WHERE ('[' + name + ']' = 'FinanceManager'
                                 OR name = 'FinanceManager')";

                var sqlCommand = new SqlCommand(query, con);

                string name = string.Empty;

                con.Open();
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                    name = (string)reader["name"];

                con.Close();

                return name != "FinanceManager";
            }
        }

        public bool DbIsNotRequiredVersion()
        {
            return GetDbVersion() != FinanceManagerContext.DbVersion;
        }

        public void CreateDatabase()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetServerConnection()))
            {
                con.Open();
                var query = new DatabaseVersionQueries().QueryDictionary[1];
                new SqlCommand(query, con).ExecuteNonQuery();
                con.Close();
            }

            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                con.Open();

                Parallel.ForEach(new DatabaseVersionQueries().QueryDictionary.Where(i => i.Key > 1), i =>
                {
                    new SqlCommand(i.Value, con).ExecuteNonQuery();
                });

                var insertVersion = $"INSERT INTO DatabaseVersion VALUES ({FinanceManagerContext.DbVersion})";

                new SqlCommand(insertVersion, con).ExecuteNonQuery();

                con.Close();
            }
        }

        public void UpdateDatabase()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                con.Open();

                var queryList = new DatabaseVersionQueries().QueryDictionary
                    .Where(i => i.Key > GetDbVersion().ToInt()).ToList();

                Parallel.ForEach(queryList, query =>
                {
                    new SqlCommand(query.Value, con).ExecuteNonQuery();
                });

                string updateVersion = $"UPDATE DatabaseVersion SET DbVersion = '{FinanceManagerContext.DbVersion}'";

                new SqlCommand(updateVersion, con).ExecuteNonQuery();

                con.Close();
            }
        }

        private string GetDbVersion()
        {
            using (var con = new SqlConnection(FinanceManagerContext.GetConnection()))
            {
                string query = @"SELECT * FROM DatabaseVersion";

                var sqlCommand = new SqlCommand(query, con);

                string version = string.Empty;
                con.Open();

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    version = (string)reader["DbVersion"];
                }

                con.Close();

                return version;
            }
        }
    }
}
