using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_Alpha1
{
    public partial class Subject_Input : Form
    {
        public Subject_Input()
        {
            InitializeComponent();

        }
        //add item
        private void New_Item_Click(object sender, EventArgs e)
        {
            
            string get_Item = Microsoft.VisualBasic.Interaction.InputBox("新增科目", "科目新增","離散數學");

            if (Sub_List.Items.Contains(get_Item) == true)
                MessageBox.Show("重複科目!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else            
                Sub_List.Items.Add(get_Item);
        }

        //save & exit
        private void Exit_Diag_Click(object sender, EventArgs e)
        {
            Close();
        }

        //delete
        private void Delete_Item_Click(object sender, EventArgs e)
        {
            Sub_List.Items.RemoveAt(Sub_List.SelectedIndex);
        }
    }
}
