using FinanceManager.Infra.Crosscutting.Extenstions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infra.Data.Database
{
    public class DatabaseData
    {
        public static string DbVersion { get; private set; } = "10";
        public object DatabaseContext { get; private set; }

        public string GetDatabaseName()
        {
            using (var con = new SqlConnection(Connection.GetServerConnection()))
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

                return name;
            }
        }

        public string GetDbVersion()
        {
            using (var con = new SqlConnection(Connection.GetConnection()))
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

        public void CreateDatabase()
        {
            using (var con = new SqlConnection(Connection.GetServerConnection()))
            {
                con.Open();
                var query = new DatabaseVersionQueries().QueryDictionary[1];
                new SqlCommand(query, con).ExecuteNonQuery();
                con.Close();
            }

            using (var con = new SqlConnection(Connection.GetConnection()))
            {
                con.Open();

                Parallel.ForEach(new DatabaseVersionQueries().QueryDictionary.Where(i => i.Key > 1), i =>
                {
                    new SqlCommand(i.Value, con).ExecuteNonQuery();
                });

                var insertVersion = $"INSERT INTO DatabaseVersion VALUES ({DbVersion})";

                new SqlCommand(insertVersion, con).ExecuteNonQuery();

                con.Close();
            }
        }

        public void UpdateDatabase()
        {
            using (var con = new SqlConnection(Connection.GetConnection()))
            {
                con.Open();

                var queryList = new DatabaseVersionQueries().QueryDictionary
                    .Where(i => i.Key > GetDbVersion().ToInt()).ToList();

                Parallel.ForEach(queryList, query =>
                {
                    new SqlCommand(query.Value, con).ExecuteNonQuery();
                });

                string updateVersion = $"UPDATE DatabaseVersion SET DbVersion = '{DbVersion}'";

                new SqlCommand(updateVersion, con).ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
