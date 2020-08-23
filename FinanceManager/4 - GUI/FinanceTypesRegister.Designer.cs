namespace FinanceManager._4___GUI
{
    partial class FinanceTypesRegister
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TypesCombo = new System.Windows.Forms.ComboBox();
            this.PriceTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Finance Type Registration";
            // 
            // TypesCombo
            // 
            this.TypesCombo.FormattingEnabled = true;
            this.TypesCombo.Location = new System.Drawing.Point(40, 54);
            this.TypesCombo.Name = "TypesCombo";
            this.TypesCombo.Size = new System.Drawing.Size(144, 21);
            this.TypesCombo.TabIndex = 2;
            // 
            // PriceTxtBox
            // 
            this.PriceTxtBox.Location = new System.Drawing.Point(40, 112);
            this.PriceTxtBox.Name = "PriceTxtBox";
            this.PriceTxtBox.Size = new System.Drawing.Size(144, 20);
            this.PriceTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name";
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(40, 83);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(144, 20);
            this.NameTxtBox.TabIndex = 7;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(40, 135);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 22);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FinanceTypesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PriceTxtBox);
            this.Controls.Add(this.TypesCombo);
            this.Controls.Add(this.label1);
            this.Name = "FinanceTypesRegister";
            this.Size = new System.Drawing.Size(480, 388);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TypesCombo;
        private System.Windows.Forms.TextBox PriceTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.Button SaveBtn;
    }
}
