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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //資料鍵入畫面
        private void button1_Click(object sender, EventArgs e)
        {
            DataInput frm = new DataInput();
            frm.ShowDialog();
        }
        //關於畫面
        private void 關於ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DSS分析系統alpha1.0", "關於", MessageBoxButtons.OK);
        }
        //離開
        private void Exit_But_Click(object sender, EventArgs e) {
            DialogResult exit_Result;
            exit_Result = MessageBox.Show("確定離開?", "警告", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (exit_Result == DialogResult.OK)
                Application.ExitThread();
        }
        //下拉選單/科目
        private void Menu_Subject_Click(object sender, EventArgs e)
        {
            Subject_Input subFrm = new Subject_Input();
            subFrm.ShowDialog();
        }
    }
}
