namespace DSS_Alpha1
{
    partial class Compare_Rates
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Last_Sem = new System.Windows.Forms.ComboBox();
            this.End = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.TextBox();
            this.Multi_Sem_RadioBox = new System.Windows.Forms.RadioButton();
            this.Single_Sem_RadioBox = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Current_Sem = new System.Windows.Forms.ComboBox();
            this.CompareRates_confirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Last_Sem);
            this.groupBox1.Controls.Add(this.End);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.Multi_Sem_RadioBox);
            this.groupBox1.Controls.Add(this.Single_Sem_RadioBox);
            this.groupBox1.Location = new System.Drawing.Point(43, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "上次";
            // 
            // Last_Sem
            // 
            this.Last_Sem.FormattingEnabled = true;
            this.Last_Sem.Location = new System.Drawing.Point(111, 47);
            this.Last_Sem.Name = "Last_Sem";
            this.Last_Sem.Size = new System.Drawing.Size(102, 20);
            this.Last_Sem.TabIndex = 1;
            this.Last_Sem.SelectedIndexChanged += new System.EventHandler(this.Last_Sem_SelectedIndexChanged);
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(175, 85);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(38, 22);
            this.End.TabIndex = 8;
            this.End.Visible = false;
            this.End.TextChanged += new System.EventHandler(this.End_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "~";
            this.label3.Visible = false;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(111, 85);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(41, 22);
            this.Start.TabIndex = 6;
            this.Start.Visible = false;
            this.Start.TextChanged += new System.EventHandler(this.Start_TextChanged);
            // 
            // Multi_Sem_RadioBox
            // 
            this.Multi_Sem_RadioBox.AutoSize = true;
            this.Multi_Sem_RadioBox.Location = new System.Drawing.Point(34, 88);
            this.Multi_Sem_RadioBox.Name = "Multi_Sem_RadioBox";
            this.Multi_Sem_RadioBox.Size = new System.Drawing.Size(59, 16);
            this.Multi_Sem_RadioBox.TabIndex = 4;
            this.Multi_Sem_RadioBox.TabStop = true;
            this.Multi_Sem_RadioBox.Text = "多學期";
            this.Multi_Sem_RadioBox.UseVisualStyleBackColor = true;
            this.Multi_Sem_RadioBox.Visible = false;
            this.Multi_Sem_RadioBox.Click += new System.EventHandler(this.Multi_Sem_RadioBox_Click);
            // 
            // Single_Sem_RadioBox
            // 
            this.Single_Sem_RadioBox.AutoSize = true;
            this.Single_Sem_RadioBox.Location = new System.Drawing.Point(34, 48);
            this.Single_Sem_RadioBox.Name = "Single_Sem_RadioBox";
            this.Single_Sem_RadioBox.Size = new System.Drawing.Size(71, 16);
            this.Single_Sem_RadioBox.TabIndex = 3;
            this.Single_Sem_RadioBox.TabStop = true;
            this.Single_Sem_RadioBox.Text = "單一學期";
            this.Single_Sem_RadioBox.UseVisualStyleBackColor = true;
            this.Single_Sem_RadioBox.CheckedChanged += new System.EventHandler(this.Single_Sem_RadioBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Current_Sem);
            this.groupBox2.Location = new System.Drawing.Point(307, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本次";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "單一學期";
            // 
            // Current_Sem
            // 
            this.Current_Sem.FormattingEnabled = true;
            this.Current_Sem.Location = new System.Drawing.Point(106, 47);
            this.Current_Sem.Name = "Current_Sem";
            this.Current_Sem.Size = new System.Drawing.Size(86, 20);
            this.Current_Sem.TabIndex = 5;
            this.Current_Sem.SelectedIndexChanged += new System.EventHandler(this.Current_SelectedIndexChanged);
            // 
            // CompareRates_confirm
            // 
            this.CompareRates_confirm.Location = new System.Drawing.Point(247, 244);
            this.CompareRates_confirm.Name = "CompareRates_confirm";
            this.CompareRates_confirm.Size = new System.Drawing.Size(78, 23);
            this.CompareRates_confirm.TabIndex = 2;
            this.CompareRates_confirm.Text = "確定";
            this.CompareRates_confirm.UseVisualStyleBackColor = true;
            this.CompareRates_confirm.Click += new System.EventHandler(this.CompareRates_confirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(79, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "請標明學期序! ex.10301,10402";
            this.label2.Visible = false;
            // 
            // Compare_Rates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 279);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CompareRates_confirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "Compare_Rates";
            this.Text = "Compare_Rates";
            this.Load += new System.EventHandler(this.Compare_Rates_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Start;
        private System.Windows.Forms.ComboBox Current_Sem;
        private System.Windows.Forms.RadioButton Multi_Sem_RadioBox;
        private System.Windows.Forms.RadioButton Single_Sem_RadioBox;
        private System.Windows.Forms.ComboBox Last_Sem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CompareRates_confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox End;
        private System.Windows.Forms.Label label3;
    }
}