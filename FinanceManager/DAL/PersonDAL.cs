using FinanceManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.DAL
{
    public class PersonDAL
    {
        public void InsertPerson(Person Person)
        {
            using (var context = new FMEntities())
            {
                context.People.Add(Person);

                context.SaveChanges();
            }
        }
    }
}
