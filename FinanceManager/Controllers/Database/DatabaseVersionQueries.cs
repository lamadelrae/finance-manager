using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Controllers
{
    public static class DatabaseVersionQueries
    {
        public static Dictionary<int, string> QueryDictionary = new Dictionary<int, string>
        {
            {1, versionOne}
        };

        private static string versionOne = @"IF object_id('Users') IS NOT NULL
                                               CREATE TABLE Users
                                               (
                                                 Id int identity(1,1) primary key,
                                                 Username varchar(120) not null,
                                                 Password varchar(120) not null,
                                                 Salary decimal(16, 2) not null,
                                                 MaxExpenses decimal(16, 2) not null
                                               );
                                               
                                               IF OBJECT_ID('DatabaseVersion') IS NOT NULL
                                               CREATE TABLE DatabaseVersion
                                               (
                                                  DbVersion varchar(30) primary key not null
                                               )";
    }
}
