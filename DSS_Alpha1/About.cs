using System;
using System.Windows.Forms;

namespace DSS_Alpha1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            label1.Text =
                "Decision Support System \nVER 0.5 Beta-Release\n" +
                "Lead by Dr.Chu Liou\n\n" +
                "Developed By\n" +
                "ChenMT, HungYF, VJ Lu\n\n" +
                "IIT 2016 © All rights reserved\n" +
                "Contact \n gene31105@gmail.com\n" +
                "h40906h@yahoo.com.tw";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
