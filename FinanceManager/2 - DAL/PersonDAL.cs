using FinanceManager._1___Entity;
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

        public List<Person> SelectPeople()
        {
            List<Person> PeopleList = new List<Person>();

            using (var context = new FMEntities())
            {
                var Query = (from p in context.People
                             select p).ToList();

                foreach(var Person in Query)
                {
                    PeopleList.Add(Person);
                }
            }
            return PeopleList;
        }
    }
}
