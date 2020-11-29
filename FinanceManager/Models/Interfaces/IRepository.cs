using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Models.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);

        List<T> GetAll();

        void Insert(T item);

        void Update(T item);

        void Delete(T item);
    }
}
