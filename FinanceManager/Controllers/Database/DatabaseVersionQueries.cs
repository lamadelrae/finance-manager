using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Controllers
{
    public class DatabaseVersionQueries
    {
        public Dictionary<int, string> QueryDictionary = new Dictionary<int, string>();

        public DatabaseVersionQueries()
        {
            QueryDictionary.Add(1, createDatabase);
            QueryDictionary.Add(2, createDataBaseVersion);
            QueryDictionary.Add(3, createUsers);
            QueryDictionary.Add(4, createBills);
            QueryDictionary.Add(5, createMonths);
            QueryDictionary.Add(6, createMonths_Bills);
            QueryDictionary.Add(7, createIncomes);
            QueryDictionary.Add(8, createMonths_Incomes);
            QueryDictionary.Add(9, createSavings);
            QueryDictionary.Add(10, createSavings_Transactions);
        }

        private string createDatabase = @$"CREATE DATABASE FinanceManager ON PRIMARY 
                                                (NAME = FinanceManager, 
                                                FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}\FinanceManager.mdf', 
                                                SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)
                                                LOG ON (NAME = FinanceManager_Log, 
                                                FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}\FinanceManager_Log.ldf', 
                                                SIZE = 1MB, 
                                                MAXSIZE = 10MB, 
                                                FILEGROWTH = 10%)";

        private string createUsers = @" CREATE TABLE Users
                                               (
                                                 Id int identity(1,1) primary key,
                                                 Username varchar(120) not null,
                                                 Password varchar(120) not null,
                                                 Salary decimal (16, 2) not null,
                                                 MaxExpenses decimal (16, 2) not null
                                               );";

        private string createDataBaseVersion = @"CREATE TABLE DatabaseVersion
                                               (
                                                  DbVersion varchar(30) primary key not null
                                               )";

        private string createBills = @"CREATE TABLE Bills
                                               (
                                                 Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                                 User_Id INT NOT NULL,
                                                 Description VARCHAR(120) NOT NULL,
                                                 Value DECIMAL(16, 2) NOT NULL, 
												 Status CHAR(1) NOT NULL
                                               )";

        private string createMonths = @"CREATE TABLE Months
                                        (
                                        	Id int IDENTITY(1,1) primary key NOT NULL,
                                        	User_Id int NOT NULL,
                                        	Month date NOT NULL,
											SalaryIsManualInput bit NOT NULL,
											Salary decimal(16, 2) NOT NULL,
                                        	TotalIncome decimal(16, 2) NOT NULL,
                                        	TotalOutcome decimal(16, 2) NOT NULL,
                                        	TotalProfit decimal(16, 2) NOT NULL,
                                        )";

        private string createMonths_Bills = @"CREATE TABLE Months_Bills
                                               (
                                                 Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
                                                 User_Id INT NOT NULL,
                                                 Month_Id INT NOT NULL,
                                                 Bill_Id INT NOT NULL,
                                                 Description VARCHAR(120) NOT NULL,
                                                 Value DECIMAL(16, 2) NOT NULL
                                               )";

        private string createIncomes = @"CREATE TABLE Incomes
                                         (
                                           Id int identity(1, 1) primary key not null, 
                                           User_Id int not null, 
                                           Description varchar(120) not null, 
                                           Value decimal(16, 2) not null, 
										   Status char(1) not null
                                         )";

        private string createMonths_Incomes = @"CREATE TABLE Months_Incomes
                                                (
                                                  Id int identity(1, 1) primary key not null, 
                                                  User_Id int not null, 
                                                  Month_Id int not null, 
                                                  Income_Id int not null, 
                                                  Description varchar(120) not null,
                                                  Value decimal(16, 2) not null
                                                )";
        private string createSavings = @"CREATE TABLE Savings 
                                         (
                                            Id INT IDENTITY (1, 1) PRIMARY KEY, 
                                            User_Id INT NOT NULL,
                                            Description VARCHAR(1200) NOT NULL,
                                            TotalAmount DECIMAL(16, 2) NOT NULL,
                                            DateCreated DATETIME NOT NULL,
                                            LastModifiedDate DATETIME NOT NULL
                                         )";

        private string createSavings_Transactions = @"CREATE TABLE Savings_Transactions
                                                      (
                                                        Id INT IDENTITY (1, 1) PRIMARY KEY,
                                                        User_Id INT NOT NULL, 
                                                        Savings_Id INT NOT NULL, 
                                                        Description VARCHAR(1200) NOT NULL,
                                                        Type CHAR(1) NOT NULL, 
                                                        Value DECIMAL(16, 2) NOT NULL,
                                                        TransactionDate DATETIME NOT NULL,
                                                        InputDate DATETIME NOT NULL
														)";
    }
}