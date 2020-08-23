namespace FinanceManager
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinances = new System.Windows.Forms.Button();
            this.btnFinanceTypes = new System.Windows.Forms.Button();
            this.btnPerson = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnFinances);
            this.panel1.Controls.Add(this.btnFinanceTypes);
            this.panel1.Controls.Add(this.btnPerson);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 392);
            this.panel1.TabIndex = 0;
            // 
            // btnFinances
            // 
            this.btnFinances.BackColor = System.Drawing.SystemColors.Menu;
            this.btnFinances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinances.Location = new System.Drawing.Point(3, 61);
            this.btnFinances.Name = "btnFinances";
            this.btnFinances.Size = new System.Drawing.Size(154, 23);
            this.btnFinances.TabIndex = 2;
            this.btnFinances.Text = "Finances";
            this.btnFinances.UseVisualStyleBackColor = false;
            this.btnFinances.Click += new System.EventHandler(this.btnFinances_Click);
            // 
            // btnFinanceTypes
            // 
            this.btnFinanceTypes.BackColor = System.Drawing.SystemColors.Menu;
            this.btnFinanceTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceTypes.Location = new System.Drawing.Point(3, 32);
            this.btnFinanceTypes.Name = "btnFinanceTypes";
            this.btnFinanceTypes.Size = new System.Drawing.Size(154, 23);
            this.btnFinanceTypes.TabIndex = 1;
            this.btnFinanceTypes.Text = "Finance Types";
            this.btnFinanceTypes.UseVisualStyleBackColor = false;
            this.btnFinanceTypes.Click += new System.EventHandler(this.btnFinanceTypes_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.BackColor = System.Drawing.SystemColors.Menu;
            this.btnPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerson.Location = new System.Drawing.Point(3, 3);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(154, 23);
            this.btnPerson.TabIndex = 0;
            this.btnPerson.Text = "People";
            this.btnPerson.UseVisualStyleBackColor = false;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(178, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(444, 392);
            this.MainPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 416);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinances;
        private System.Windows.Forms.Button btnFinanceTypes;
        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Panel MainPanel;
    }
}

