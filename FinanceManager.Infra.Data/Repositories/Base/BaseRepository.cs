using FinanceManager.Infra.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager.Infra.Data.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
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

        public virtual void Update(T item)
        {
            Context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            Context.Remove(item);
            Context.SaveChanges();
        }
    }
}
