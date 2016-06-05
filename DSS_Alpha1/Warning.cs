using System;
using System.Windows.Forms;

namespace DSS_Alpha1
{
    public partial class Warning : Form
    {
        //If DB doesn't exist show this
        public Warning()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
