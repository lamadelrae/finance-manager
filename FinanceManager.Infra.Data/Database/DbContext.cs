using FinanceManager.Domain.Database.Savings;
using FinanceManager.Domain.DataBase;
using FinanceManager.Domain.DataBase.Months;
using FinanceManager.Domain.DataBase.Months.Bills;
using FinanceManager.Domain.DataBase.Months.Incomes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Infra.Data.Database
{
    public class FinanceManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.GetConnection());
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<DatabaseVersion> DatabaseVersion { get; set; }

        public DbSet<Bills> Bills { get; set; }

        public DbSet<Months> Months { get; set; }

        public DbSet<Months_Bills> Months_Bills { get; set; }

        public DbSet<Incomes> Incomes { get; set; }

        public DbSet<Months_Incomes> Months_Incomes { get; set; }

        public DbSet<Savings> Savings { get; set; }

        public DbSet<Savings_Transactions> Savings_Transactions { get; set; }
    }
}
