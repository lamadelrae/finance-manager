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

        private const string versionOne = @"IF object_id('Users') IS NOT NULL
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
                                               )

                                               IF OBJECT_ID('Bills') IS NOT NULL
                                               CREATE TABLE Bills
                                               (
                                                 Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                                 User_Id INT NOT NULL,
                                                 Description VARCHAR(120) NOT NULL,
                                                 Value DECIMAL(16, 2) NOT NULL
                                               )
                                               
                                               IF OBJECT_ID('Months') IS NOT NULL
                                               CREATE TABLE Months
                                               (
                                                Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                                User_Id INT NOT NULL,
                                                Month DATE NOT NULL, 
                                                TotalIncome DECIMAL (16, 2) NOT NULL,
                                                TotalOutcome DECIMAL(16, 2) NOT NULL,
                                               )
                                               
                                               IF OBJECT_ID('Months_Bills') IS NOT NULL
                                               CREATE TABLE Months_Bills
                                               (
                                                 Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL, 
                                                 User_Id INT NOT NULL,
                                                 Month_Id INT NOT NULL,
                                                 Bill_Id INT NOT NULL,
                                                 Description VARCHAR(120) NOT NULL,
                                                 Value DECIMAL(16, 2) NOT NULL
                                               )";
    }
}
