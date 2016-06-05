namespace DSS_Alpha1
{
    partial class Data_Input
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
            this.List = new System.Windows.Forms.ListBox();
            this.Sem_Box = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.College = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.TextBox();
            this.Class = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Effect_Rate = new System.Windows.Forms.TextBox();
            this.Learning_Total_Rate = new System.Windows.Forms.TextBox();
            this.Meterial_Rate = new System.Windows.Forms.TextBox();
            this.Method_Rate = new System.Windows.Forms.TextBox();
            this.Professional_Rate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.C4 = new System.Windows.Forms.TextBox();
            this.C3 = new System.Windows.Forms.TextBox();
            this.C2 = new System.Windows.Forms.TextBox();
            this.C1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 12;
            this.List.Location = new System.Drawing.Point(304, 62);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(148, 88);
            this.List.TabIndex = 0;
            this.List.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            // 
            // Sem_Box
            // 
            this.Sem_Box.FormattingEnabled = true;
            this.Sem_Box.Location = new System.Drawing.Point(32, 62);
            this.Sem_Box.Name = "Sem_Box";
            this.Sem_Box.Size = new System.Drawing.Size(121, 20);
            this.Sem_Box.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "學期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "科目別";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Sem_Box);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.List);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 182);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本資料";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.College);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Department);
            this.groupBox2.Controls.Add(this.Class);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Effect_Rate);
            this.groupBox2.Controls.Add(this.Learning_Total_Rate);
            this.groupBox2.Controls.Add(this.Meterial_Rate);
            this.groupBox2.Controls.Add(this.Method_Rate);
            this.groupBox2.Controls.Add(this.Professional_Rate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 184);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分數指標";
            // 
            // College
            // 
            this.College.Location = new System.Drawing.Point(327, 80);
            this.College.Name = "College";
            this.College.Size = new System.Drawing.Size(100, 22);
            this.College.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "本院 : ";
            // 
            // Department
            // 
            this.Department.Location = new System.Drawing.Point(327, 52);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(100, 22);
            this.Department.TabIndex = 13;
            // 
            // Class
            // 
            this.Class.Location = new System.Drawing.Point(327, 21);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(100, 22);
            this.Class.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "本系 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "本班 : ";
            // 
            // Effect_Rate
            // 
            this.Effect_Rate.Location = new System.Drawing.Point(74, 135);
            this.Effect_Rate.Name = "Effect_Rate";
            this.Effect_Rate.Size = new System.Drawing.Size(80, 22);
            this.Effect_Rate.TabIndex = 9;
            // 
            // Learning_Total_Rate
            // 
            this.Learning_Total_Rate.Location = new System.Drawing.Point(74, 106);
            this.Learning_Total_Rate.Name = "Learning_Total_Rate";
            this.Learning_Total_Rate.Size = new System.Drawing.Size(80, 22);
            this.Learning_Total_Rate.TabIndex = 8;
            // 
            // Meterial_Rate
            // 
            this.Meterial_Rate.Location = new System.Drawing.Point(74, 77);
            this.Meterial_Rate.Name = "Meterial_Rate";
            this.Meterial_Rate.Size = new System.Drawing.Size(80, 22);
            this.Meterial_Rate.TabIndex = 7;
            // 
            // Method_Rate
            // 
            this.Method_Rate.Location = new System.Drawing.Point(74, 49);
            this.Method_Rate.Name = "Method_Rate";
            this.Method_Rate.Size = new System.Drawing.Size(80, 22);
            this.Method_Rate.TabIndex = 6;
            // 
            // Professional_Rate
            // 
            this.Professional_Rate.Location = new System.Drawing.Point(74, 21);
            this.Professional_Rate.Name = "Professional_Rate";
            this.Professional_Rate.Size = new System.Drawing.Size(80, 22);
            this.Professional_Rate.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "教學總分 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "學習效果 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "教學內容 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "教學方法 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "專業態度 : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.C4);
            this.groupBox3.Controls.Add(this.C3);
            this.groupBox3.Controls.Add(this.C2);
            this.groupBox3.Controls.Add(this.C1);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(12, 391);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 143);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "缺點反映";
            // 
            // C4
            // 
            this.C4.Location = new System.Drawing.Point(75, 103);
            this.C4.Name = "C4";
            this.C4.Size = new System.Drawing.Size(80, 22);
            this.C4.TabIndex = 16;
            // 
            // C3
            // 
            this.C3.Location = new System.Drawing.Point(75, 74);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(80, 22);
            this.C3.TabIndex = 15;
            // 
            // C2
            // 
            this.C2.Location = new System.Drawing.Point(75, 46);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(80, 22);
            this.C2.TabIndex = 14;
            // 
            // C1
            // 
            this.C1.Location = new System.Drawing.Point(75, 18);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(80, 22);
            this.C1.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 106);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "字體太小 : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 77);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "方法不好 : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 49);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "課程無聊 : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "聽不懂 : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "重新整理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Reflash);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "儲存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(413, 546);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "回主畫面";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Abort);
            // 
            // Data_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 581);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Data_Input";
            this.Text = "輸入";
            this.Load += new System.EventHandler(this.DataInput_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.ComboBox Sem_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Effect_Rate;
        private System.Windows.Forms.TextBox Learning_Total_Rate;
        private System.Windows.Forms.TextBox Meterial_Rate;
        private System.Windows.Forms.TextBox Method_Rate;
        private System.Windows.Forms.TextBox Professional_Rate;
        private System.Windows.Forms.TextBox College;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Department;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox C4;
        private System.Windows.Forms.TextBox C3;
        private System.Windows.Forms.TextBox C2;
        private System.Windows.Forms.TextBox C1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}