using FinanceManager._4___GUI;
using FinanceManager.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class Form1 : Form
    {
        private PersonRegister PersonRegister;
        private FinanceTypesRegister FinanceTypesRegister;
        public Form1()
        {
            InitializeComponent();
        }

        public void DisposeOfAny()
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.Remove(PersonRegister);
                this.MainPanel.Controls.Remove(FinanceTypesRegister);
            }
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            DisposeOfAny();
            PersonRegister = new PersonRegister();
            this.MainPanel.Controls.Add(PersonRegister);
        }

        private void btnFinanceTypes_Click(object sender, EventArgs e)
        {
            DisposeOfAny();
            FinanceTypesRegister = new FinanceTypesRegister();
            this.MainPanel.Controls.Add(FinanceTypesRegister);
        }

        private void btnFinances_Click(object sender, EventArgs e)
        {

        }

    }
}
