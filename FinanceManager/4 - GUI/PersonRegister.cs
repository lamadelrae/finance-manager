using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManager.Controller;
using FinanceManager.Entity;
using FinanceManager._1___Entity;

namespace FinanceManager.UI
{
    public partial class PersonRegister : UserControl
    {
        public PersonRegister()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var PersonObject = new Person
            {
                UUID = Guid.NewGuid(),
                PersonName = this.PersonName.Text,
                PersonAge = Convert.ToInt32(this.PersonAge.Text),
                PersonMonthlyIncome = Convert.ToDecimal(this.PersonMonthly.Text),
                Status = "A"
            };

            var PersonController = new PersonController();
            PersonController.SaveNewPerson(this, PersonObject);
        }
    }
}
