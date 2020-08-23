using FinanceManager._1___Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager._2___DAL
{
    public class FinanceTypeDAL
    {
        public void InsertFinanceType(FinanceType financetype)
        {
            using (var context = new FMEntities())
            {
                context.FinanceTypes.Add(financetype);
                context.SaveChanges();
            }
        }
    }
}
