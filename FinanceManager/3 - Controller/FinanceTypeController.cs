using FinanceManager._1___Entity;
using FinanceManager._2___DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager._3___Controller
{
    public class FinanceTypeController
    {
        public void AddFinanceType(FinanceType financetype)
        {
            var FinanceTypeDAL = new FinanceTypeDAL();

            FinanceTypeDAL.InsertFinanceType(financetype);
        }
    }
}
