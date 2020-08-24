using FinanceManager.DAL;
using FinanceManager._1___Entity;
using FinanceManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Controller
{
    public class PersonController 
    {
        public void SaveNewPerson(PersonRegister Form, Person Person)
        {
            var PersonDAL = new PersonDAL();
            PersonDAL.InsertPerson(Person);

            Form.ToolTipLabel.Text = "Saved with succes!";
        }

        public List<Person> GetPeople()
        {
            var PersonDAL = new PersonDAL();
            var People = PersonDAL.SelectPeople();
            return People;
        }
    }
}
