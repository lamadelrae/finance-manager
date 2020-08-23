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
        public Form1()
        {
            InitializeComponent();
        }
        private void btnPerson_Click(object sender, EventArgs e)
        {
            var PersonRegister = new PersonRegister();
            this.MainPanel.Controls.Add(PersonRegister);
        }
        private void btnFinanceTypes_Click(object sender, EventArgs e)
        {

        }

        private void btnFinances_Click(object sender, EventArgs e)
        {

        }

    }
}
