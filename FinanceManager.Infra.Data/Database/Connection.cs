using FinanceManager.Infra.Crosscutting.Extenstions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace FinanceManager.Infra.Data.Database
{
    public static class Connection
    {
        private readonly static string ConfigFile = $@"{AppDomain.CurrentDomain.BaseDirectory}\Config.txt";

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
