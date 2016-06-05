using System;
using System.Windows.Forms;

namespace DSS_Alpha1
{
    public partial class Splash : Form
    {
        //這就是Splash阿
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
