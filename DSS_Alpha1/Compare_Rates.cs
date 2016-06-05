using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

/// <summary>
/// 此FRM為主頁面學期比較之雛形
/// 尚有部分程式皆須修改
/// 留做未來程式擴充之參考
/// </summary>





namespace DSS_Alpha1
{
    public partial class Compare_Rates : Form
    {
        public Compare_Rates()
        {
            InitializeComponent();
        }


        int StartY = 0, EndY = 0;

        //載入比較的學期
        private void Compare_Rates_Load(object sender, EventArgs e)
        {
            ConnectDB();//open connection
            Sync_Box();//reflash data first
            Single_Sem_RadioBox.Checked = true;
            try
            {
                Current_Sem.SelectedText = show_Semester();//set the first item in list
                Last_Sem.SelectedIndex = Current_Sem.Items.Count-2;
            }
            catch (Exception)
            {
                MessageBox.Show("Data Loss Or One Data(Semester) Only");
            }
        }

        
        public string Current_TextBox
        {
            get { return Current_Sem.Text; }
            set { Current_Sem.Text = value; }
        }
        public string Last_TextBox
        {
            get { return Last_Sem.Text; }
            set { Last_Sem.Text = value; }
        }
        

        private void Current_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label ParentCurr = (Label)this.Owner.Controls.Find("Parent_Current_Label", true)[0];
            ParentCurr.Text = Current_Sem.Text;

        }

        private void Single_Sem_RadioBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Single_Sem_RadioBox.Checked)
            {
                End.Enabled = false;
                Start.Enabled = false;
                Last_Sem.Enabled = true;
            }
            else
            {
                End.Enabled = true;
                Start.Enabled = true;
                Last_Sem.Enabled = false;
            }
        }

        private void CompareRates_confirm_Click(object sender, EventArgs e)
        {
            Close();   
        }

        private void Last_Sem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label ParentLast = (Label)this.Owner.Controls.Find("Parent_Last", true)[0];
            ParentLast.Text = Last_Sem.Text;
        }

        private void Start_TextChanged(object sender, EventArgs e)
        {
            StartY = Convert.ToInt32(Start.Text);
        }

        private void End_TextChanged(object sender, EventArgs e)
        {
            EndY = Convert.ToInt32(End.Text);
        }

        private void Multi_Sem_RadioBox_Click(object sender, EventArgs e)
        {
            Label ParentLast = (Label)this.Owner.Controls.Find("Parent_Last", true)[0];
            Last_TextBox = Convert.ToString(StartY) + " ~ " + Convert.ToString(EndY);
            ParentLast.Text = Last_Sem.Text;
        }

        /********************************************************/
        /* S Q L  Code Start 'CLEAN' For Compare_Rates.cs ONLY  */
        /********************************************************/

        //hold Connection
        SQLiteConnection db_Conn;

        //create DB
        public void ConnectDB()
        {
            string dirPath = "Data.db";

            //declare connection obj
            try
            {
                db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3;");
                //connect to db !!!!!!!!!DONT FORGET TO CLOSE!!!!!!!!!!!!!
                db_Conn.Open();
                //setup New Table
                if (!TableExists("DSS", db_Conn))
                {
                    MessageBox.Show("Setup Initial Setting First");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Setup Initial Setting First");
            }
        }

        //SQL Command
        public void DB_Command(string SQL_CMD_LINE)
        {
            try
            {
                SQLiteCommand s_CMD = new SQLiteCommand(SQL_CMD_LINE, db_Conn);
                s_CMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                Close();
            }
        }

        public void Sync_Box()
        {
            //read year
            Last_Sem.Items.Clear();//clean !IMPORTANT  (flush)
            SQLiteCommand sql_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) obj
            sql_CMD = db_Conn.CreateCommand();//create command
            sql_CMD.CommandText = "SELECT * FROM Semester"; //select table
            try
            {
                SQLiteDataReader sqlite_datareader = sql_CMD.ExecuteReader();
                while (sqlite_datareader.Read()) //read every data
                {
                    string name_load = sqlite_datareader["Year"].ToString();
                    Current_Sem.Items.Add(name_load);
                    Last_Sem.Items.Add(name_load);
                }
                Last_Sem.Items.RemoveAt(Current_Sem.Items.Count - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Checks the database to see if the table exists
        public bool TableExists(string tableName, SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT COUNT(*) AS QtRecords FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.AddWithValue("@name", tableName);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    return false;
                else
                    return true;
            }
        }

        /********************************************************/
        /*                S Q L  Code END                       */
        /********************************************************/
        public string show_Semester()//Get time now
        {
            int y = 0, m = 0;
            DateTime time = DateTime.Now;
            y = time.Year;
            m = time.Month;
            if (m < 9)
            {
                if (m > 2)
                    return Convert.ToString(y - 1911 - 1) + "02";//01 02 is required 
                else
                {
                    return Convert.ToString(y - 1911 - 1) + "01";//01 02 is required 
                }
            }
            else
                return Convert.ToString(y - 1911) + "01";
        }

    }
}
