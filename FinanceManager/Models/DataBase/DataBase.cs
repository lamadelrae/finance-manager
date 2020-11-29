using Microsoft.EntityFrameworkCore;
using System;
using System.Xml;
using FinanceManager.Utilities.Extensions;
using Microsoft.Data.SqlClient;

namespace FinanceManager.Models.DataBase
{
    public class FinanceManagerContext : DbContext
    {
        private readonly static string ConfigFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\Config.txt";

        public static string DbVersion { get; private set; } = "1";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnection());
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<DatabaseVersion> DatabaseVersion { get; set; }

        public DbSet<Bills> Bills { get; set; }

        public DbSet<Months> Months { get; set; }

        public DbSet<Months_Bills> Months_Bills { get; set; }

        public static string GetServerConnection()
        {
            try
            {
                var xmlConfig = new XmlDocument();
                xmlConfig.Load(ConfigFile);

                return new SqlConnectionStringBuilder
                {
                    DataSource = xmlConfig.GetElementsByTagName("datasource")[0].InnerText,
                    UserID = xmlConfig.GetElementsByTagName("userid")[0].InnerText,
                    Password = xmlConfig.GetElementsByTagName("password")[0].InnerText,
                    MultipleActiveResultSets = true,
                    ConnectTimeout = xmlConfig.GetElementsByTagName("timeout")[0].InnerText.ToInt()
                }.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetConnection()
        {
            try
            {
                var xmlConfig = new XmlDocument();
                xmlConfig.Load(ConfigFile);

                return new SqlConnectionStringBuilder
                {
                    DataSource = xmlConfig.GetElementsByTagName("datasource")[0].InnerText,
                    UserID = xmlConfig.GetElementsByTagName("userid")[0].InnerText,
                    Password = xmlConfig.GetElementsByTagName("password")[0].InnerText,
                    InitialCatalog = "FinanceManager",
                    ApplicationName = "EntityFramework",
                    MultipleActiveResultSets = true,
                    ConnectTimeout = xmlConfig.GetElementsByTagName("timeout")[0].InnerText.ToInt()
                }.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}