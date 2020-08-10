namespace FinanceManager.UI
{
    partial class PersonRegister
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
            this.PersonName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.ToolTipLabel = new System.Windows.Forms.Label();
            this.PersonAge = new System.Windows.Forms.NumericUpDown();
            this.PersonMonthly = new System.Windows.Forms.MaskedTextBox();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            ((System.ComponentModel.ISupportInitialize)(this.PersonAge)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person Registration";
            // 
            // PersonName
            // 
            this.PersonName.Location = new System.Drawing.Point(8, 47);
            this.PersonName.Name = "PersonName";
            this.PersonName.Size = new System.Drawing.Size(186, 20);
            this.PersonName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monthly Income";
            // 
            // btnImg
            // 
            this.btnImg.Location = new System.Drawing.Point(8, 125);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(90, 23);
            this.btnImg.TabIndex = 8;
            this.btnImg.Text = "Image";
            this.btnImg.UseVisualStyleBackColor = true;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ToolTipLabel
            // 
            this.ToolTipLabel.AutoSize = true;
            this.ToolTipLabel.Location = new System.Drawing.Point(8, 198);
            this.ToolTipLabel.Name = "ToolTipLabel";
            this.ToolTipLabel.Size = new System.Drawing.Size(0, 13);
            this.ToolTipLabel.TabIndex = 10;
            // 
            // PersonAge
            // 
            this.PersonAge.Location = new System.Drawing.Point(8, 73);
            this.PersonAge.Name = "PersonAge";
            this.PersonAge.Size = new System.Drawing.Size(90, 20);
            this.PersonAge.TabIndex = 11;
            // 
            // PersonMonthly
            // 
            this.PersonMonthly.Location = new System.Drawing.Point(8, 99);
            this.PersonMonthly.Mask = "$000,000.00";
            this.PersonMonthly.Name = "PersonMonthly";
            this.PersonMonthly.Size = new System.Drawing.Size(90, 20);
            this.PersonMonthly.TabIndex = 12;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // PersonRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PersonMonthly);
            this.Controls.Add(this.PersonAge);
            this.Controls.Add(this.ToolTipLabel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PersonName);
            this.Controls.Add(this.label1);
            this.Name = "PersonRegister";
            this.Size = new System.Drawing.Size(444, 389);
            ((System.ComponentModel.ISupportInitialize)(this.PersonAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PersonName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label ToolTipLabel;
        private System.Windows.Forms.NumericUpDown PersonAge;
        private System.Windows.Forms.MaskedTextBox PersonMonthly;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
    }
}
