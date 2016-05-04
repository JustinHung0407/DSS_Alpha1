namespace DSS_Alpha1
{
    partial class Subject_Input
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
            this.Sub_List = new System.Windows.Forms.ListBox();
            this.New_Item = new System.Windows.Forms.Button();
            this.Delete_Item = new System.Windows.Forms.Button();
            this.Exit_Diag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sub_List
            // 
            this.Sub_List.FormattingEnabled = true;
            this.Sub_List.ItemHeight = 12;
            this.Sub_List.Location = new System.Drawing.Point(12, 12);
            this.Sub_List.Name = "Sub_List";
            this.Sub_List.Size = new System.Drawing.Size(168, 208);
            this.Sub_List.TabIndex = 0;
            // 
            // New_Item
            // 
            this.New_Item.Location = new System.Drawing.Point(246, 139);
            this.New_Item.Name = "New_Item";
            this.New_Item.Size = new System.Drawing.Size(75, 23);
            this.New_Item.TabIndex = 1;
            this.New_Item.Text = "新增";
            this.New_Item.UseVisualStyleBackColor = true;
            this.New_Item.Click += new System.EventHandler(this.New_Item_Click);
            // 
            // Delete_Item
            // 
            this.Delete_Item.Location = new System.Drawing.Point(246, 168);
            this.Delete_Item.Name = "Delete_Item";
            this.Delete_Item.Size = new System.Drawing.Size(75, 23);
            this.Delete_Item.TabIndex = 2;
            this.Delete_Item.Text = "刪除";
            this.Delete_Item.UseVisualStyleBackColor = true;
            this.Delete_Item.Click += new System.EventHandler(this.Delete_Item_Click);
            // 
            // Exit_Diag
            // 
            this.Exit_Diag.Location = new System.Drawing.Point(246, 197);
            this.Exit_Diag.Name = "Exit_Diag";
            this.Exit_Diag.Size = new System.Drawing.Size(75, 23);
            this.Exit_Diag.TabIndex = 3;
            this.Exit_Diag.Text = "確定";
            this.Exit_Diag.UseVisualStyleBackColor = true;
            this.Exit_Diag.Click += new System.EventHandler(this.Exit_Diag_Click);
            // 
            // Subject_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 240);
            this.Controls.Add(this.Exit_Diag);
            this.Controls.Add(this.Delete_Item);
            this.Controls.Add(this.New_Item);
            this.Controls.Add(this.Sub_List);
            this.Name = "Subject_Input";
            this.Text = "科目";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Sub_List;
        private System.Windows.Forms.Button New_Item;
        private System.Windows.Forms.Button Delete_Item;
        private System.Windows.Forms.Button Exit_Diag;
    }
}