using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Infra.Data.Repositories.Base
{
    public interface IRepository<T> where T : class, new()
    {
        T GetById(int id);

        List<T> GetAll();

        void Insert(T item);

        void Update(T item);

        void Delete(T item);
    }
}
