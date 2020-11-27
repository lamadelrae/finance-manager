using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Models.DataBase
{
    public class FinanceManagerContext : DbContext
    {   
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Localhost\sql2019;Database=FinanceManager;User Id=sa;Password=pass;");
        }
    }
}