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
using FinanceManager._1___Entity;

namespace FinanceManager._4___GUI
{
    public partial class Finances : UserControl
    {
        public Finances()
        {
            InitializeComponent();

            PopulateCombo();
        }

        public void PopulateCombo()
        {
            var PersonController = new PersonController();
            var People = PersonController.GetPeople();

            foreach(var Person in People)
            {
                var PersonObj = new Person
                {
                    PersonName = Person.PersonName,
                    UUID = Person.UUID
                };

                PersonCombo.Items.Add(PersonObj);
            }

            PersonCombo.DisplayMember = "PersonName";
            PersonCombo.ValueMember = "UUID";

            PersonCombo.SelectedIndex = 0;
        }
    }
}
