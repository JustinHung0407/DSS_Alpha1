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
    public partial class Semester : Form
    {
        public Semester()
        {
            InitializeComponent();

            N_Time_Lable.Text = show_Time_Now();

        }
        //show this semester
        public string show_Time_Now()
        {
            int y = 0 , m = 0 ;
            DateTime time = DateTime.Now;
            y = time.Year;
            m = time.Month;
            if (m < 9)
            {
                return "目前是 : " + Convert.ToString(y - 1911 - 1) + " 學年度" ;
            }
            else
                return "目前是 : " + Convert.ToString(y - 1911) + " 學年度" ;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
