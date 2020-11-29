using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Models.DataBase;
using FinanceManager.Models.Interfaces;

namespace FinanceManager.Controllers
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public FinanceManagerContext Context = new FinanceManagerContext();

        public virtual T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual void Insert(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }

        public void Update(T item)
        {
            Context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(T item)
        {
            Context.Remove(item);
            Context.SaveChanges();
        }
    }
}
