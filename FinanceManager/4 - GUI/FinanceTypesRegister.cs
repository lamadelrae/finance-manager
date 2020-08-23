using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManager._1___Entity;

namespace FinanceManager._4___GUI
{
    public partial class FinanceTypesRegister : UserControl
    {
        public FinanceTypesRegister()
        {
            InitializeComponent();

            SetComboBox();
        }

        public void SetComboBox()
        {
            TypesCombo.Items.Add("Gain");
            TypesCombo.Items.Add("Debt");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var FinanceType = new FinanceType
            {
                UUID = Guid.NewGuid(),
                Name = this.NameTxtBox.Text, 
                
            };
        }
    }
}
