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
using FinanceManager._3___Controller;

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
  
            var Gain = new ComboxItem
            {
                Value = 1,
                Name = "Gain"
            };

            var Debt = new ComboxItem
            {
                Value = 2,
                Name = "Debt"
            };

            TypesCombo.Items.Add(Gain);
            TypesCombo.Items.Add(Debt);

            TypesCombo.SelectedIndex = 0;
            TypesCombo.DisplayMember = "Name";
            TypesCombo.ValueMember = "Value";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var SelectedItem = TypesCombo.SelectedItem as ComboxItem;

            var FinanceTypesController = new FinanceTypeController();

            var FinanceType = new FinanceType
            {
                UUID = Guid.NewGuid(),
                Name = this.NameTxtBox.Text, 
                Type = Convert.ToInt32(SelectedItem.Value),
                Price = Convert.ToDecimal(this.PriceTxtBox.Text),
                Status = "A"
            };

            FinanceTypesController.AddFinanceType(FinanceType);
        }
    }
}
