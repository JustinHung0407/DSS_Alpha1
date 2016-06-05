using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DSS_Alpha1
{
    public partial class DataInput : Form
    {
        public DataInput()
        {
            InitializeComponent();
        }

        //科目選單選中項目改變時 
        //重新整理分數指標
        private void Sub_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fresh();
            string get_Subject_Item = Convert.ToString(Sub_List.SelectedItem);
            string get_Semester_Item = Sem_Box.Text;
            Read_Data(get_Subject_Item, get_Semester_Item);
        }

        //學期選單選中項目改變時 
        //重新整理分數指標
        private void Sem_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fresh();
            string get_Subject_Item = Convert.ToString(Sub_List.SelectedItem);
            string get_Semester_Item = Sem_Box.Text;
            Read_Data(get_Subject_Item, get_Semester_Item);
        }

        //將分數指標存回DB
        private void Save (object sender, EventArgs e)
        {
            try
            {
                //判斷分數指標符合條件
                if (
                    Convert.ToSingle(Professional_Rate.Text) > 6 ||
                    Convert.ToSingle(Professional_Rate.Text) < 1 ||

                    Convert.ToSingle(Method_Rate.Text) > 6 ||
                    Convert.ToSingle(Method_Rate.Text) < 1 ||

                    Convert.ToSingle(Meterial_Rate.Text) > 6 ||
                    Convert.ToSingle(Meterial_Rate.Text) < 1 ||

                    Convert.ToSingle(Learning_Total_Rate.Text) > 6 ||
                    Convert.ToSingle(Learning_Total_Rate.Text) < 1 ||

                    Convert.ToSingle(Effect_Rate.Text) > 6 ||
                    Convert.ToSingle(Effect_Rate.Text) < 1 ||

                    Convert.ToSingle(Class.Text) > 6 ||
                    Convert.ToSingle(Class.Text) < 1 ||

                    Convert.ToSingle(Department.Text) > 6 ||
                    Convert.ToSingle(Department.Text) < 1 ||

                    Convert.ToSingle(College.Text) > 6 ||
                    Convert.ToSingle(College.Text) < 1 ||

                    Convert.ToInt32(C1.Text) <= 0 ||
                    Convert.ToInt32(C2.Text) <= 0 ||
                    Convert.ToInt32(C3.Text) <= 0 ||
                    Convert.ToInt32(C4.Text) <= 0 )
                {
                    throw new FormatException();
                }
                else
                {
                    Insert_Data_Sets(
                    //list main data
                    //呼叫func存回DB
                    Sub_List.SelectedItem.ToString(),
                    Convert.ToInt32(Sem_Box.SelectedItem.ToString()),//convert to int
                                                                     //RATES
                    Convert.ToSingle(Professional_Rate.Text),
                    Convert.ToSingle(Method_Rate.Text),
                    Convert.ToSingle(Meterial_Rate.Text),
                    Convert.ToSingle(Learning_Total_Rate.Text),
                    Convert.ToSingle(Effect_Rate.Text),
                    Convert.ToSingle(Class.Text),
                    Convert.ToSingle(Department.Text),
                    Convert.ToSingle(College.Text),
                    //CONS
                    Convert.ToInt32(C1.Text),
                    Convert.ToInt32(C2.Text),
                    Convert.ToInt32(C3.Text),
                    Convert.ToInt32(C4.Text)
                    );
                    MessageBox.Show("Success", "Database IO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wrong Value");
                Optimize_DB();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data Incorrect");
                Optimize_DB();
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow");
            }

        }

        //reflash
        //重新整理分數指標中的數值
        private void Reflash_Button(object sender, EventArgs e)
        {
            Fresh();
            Sync_Box();//flush func. already build-in.
        }

        //回主畫面之按鈕
        private void Abort (object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Sure to Exit ?\n Remember to Save Before Leave or Data may not Save","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                Close();
            }
            
        }

        //載入輸入資料之頁面
        private void DataInput_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();//open connection
                Optimize_DB();//optimize first
                Sync_Box();//reflash data first
                Sub_List.SetSelected(0, true);//set the first item in list
                Sem_Box.SelectedIndex = 0;//set the first item in list

                string get_Subject_Item = Convert.ToString(Sub_List.SelectedItem);
                string get_Semester_Item = Sem_Box.Text;
                Read_Data(get_Subject_Item, get_Semester_Item);
            }
            catch (Exception)
            {
                MessageBox.Show("Setup Data First (Empty Subject)");
            }
        }

        /********************************************************/
        /*     S Q L  Code Start 'CLEAN'  For DataInput.cs ONLY */
        /********************************************************/

        //hold Connection
        SQLiteConnection db_Conn;

        //create DB
        public void ConnectDB()
        {
            string dirPath = "Data.db";

            //declare connection obj
            db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3;");
            //connect to db !!!!!!!!!DONT FORGET TO CLOSE!!!!!!!!!!!!!
            db_Conn.Open();
            //setup New Table
            if (!TableExists("DSS", db_Conn))
            {
                string sqlCreate = "CREATE TABLE DSS (SubjectName text ,SemesterYear float, Profession float,Method float,Meterial float,TeachingTotal float, Effect float, MClass float ,MDepartment float,MCollege float,Con1 int ,Con2 int,Con3 int,Con4 int);";
                DB_Command(sqlCreate);
            }
            Sync_Box();

        }
        //insert grid datas
        public void Insert_Data_Sets(String SN, int SY, float Pro, float Meth, float Meter, float TechT, float Eff,float MClass,float MDepartment, float MCollege, int C1, int C2, int C3,int C4)
        {
            DB_Command("INSERT INTO DSS VALUES  ('" + SN + "','" + SY + "','" + Pro + "','" + Meth + "','" + Meter + "','" + TechT + "','" + Eff + "','" + MClass + "','" + MDepartment + "','" + MCollege + "','" + C1 + "','" + C2 + "','" + C3 + "','" + C4 + "');");
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

        /*sync to listbox
         *clean code is needed!
         * Maybe try to <include> sqlite command?
         * Or try class?
         * 
         * REMEMBER to flush data before sync 
         */
        public void Sync_Box()
        {

            //1
            Sub_List.Items.Clear();//clean !IMPORTANT  (flush)
            SQLiteCommand sql_CMD_1 = new SQLiteCommand(); //declare SCML(sqlite command line) 
            sql_CMD_1 = db_Conn.CreateCommand();//create command
            sql_CMD_1.CommandText = "SELECT * FROM SubjectData"; //select table
            try
            {
                SQLiteDataReader sqlite_datareader_1 = sql_CMD_1.ExecuteReader();//read data from sql
                while (sqlite_datareader_1.Read()) //read every data
                {
                    string name_load_1 = sqlite_datareader_1["Subject"].ToString();//read from spicific row
                    Sub_List.Items.Add(name_load_1);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //2
            Sem_Box.Items.Clear();//clean !IMPORTANT  (flush)
            SQLiteCommand sql_CMD_2 = new SQLiteCommand(); //declare SCML(sqlite command line) obj
            sql_CMD_2 = db_Conn.CreateCommand();//create command
            sql_CMD_2.CommandText = "SELECT * FROM Semester"; //select table
            try
            {
                SQLiteDataReader sqlite_datareader_2 = sql_CMD_2.ExecuteReader();
                while (sqlite_datareader_2.Read()) //read every data
                {
                    string name_load_2 = sqlite_datareader_2["Year"].ToString();
                    Sem_Box.Items.Add(name_load_2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //NULL data delete func.
            Optimize_DB();
        }

        //DEL NULL DATA
        public void Optimize_DB()
        {
            DB_Command("DELETE FROM DSS WHERE SubjectName IS NULL;");
            DB_Command("DELETE FROM DSS WHERE SubjectName =\"\" ;");
            DB_Command("DELETE FROM DSS WHERE SemesterYear IS NULL;");
            DB_Command("DELETE FROM DSS WHERE SemesterYear =\"\" ;");
            DB_Command("DELETE FROM DSS WHERE rowid NOT IN(SELECT MAX(rowid) FROM DSS GROUP BY SubjectName, SemesterYear);");
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

        public void Read_Data(string sub, string semester)
        {
            SQLiteCommand sql_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) 
            sql_CMD = db_Conn.CreateCommand();//create command
            sql_CMD.CommandText = "SELECT * FROM DSS WHERE SubjectName = \"" + sub + "\" AND SemesterYear =\" " + semester + "\" ;"; //select table
            try
            {
                SQLiteDataReader sqlite_datareader_1 = sql_CMD.ExecuteReader();//read data from sql
                while (sqlite_datareader_1.Read()) //read every data
                {
                    Professional_Rate.Text = sqlite_datareader_1["Profession"].ToString();//read from spicific row
                    Method_Rate.Text = sqlite_datareader_1["Method"].ToString();//read from spicific row
                    Meterial_Rate.Text = sqlite_datareader_1["Meterial"].ToString();//read from spicific row
                    Learning_Total_Rate.Text = sqlite_datareader_1["TeachingTotal"].ToString();//read from spicific row
                    Effect_Rate.Text = sqlite_datareader_1["Effect"].ToString();//read from spicific row
                    Class.Text = sqlite_datareader_1["MClass"].ToString();//read from spicific row
                    Department.Text = sqlite_datareader_1["MDepartment"].ToString();//read from spicific row
                    College.Text = sqlite_datareader_1["MCollege"].ToString();//read from spicific row
                    C1.Text = sqlite_datareader_1["Con1"].ToString();//read from spicific row
                    C2.Text = sqlite_datareader_1["Con2"].ToString();//read from spicific row
                    C3.Text = sqlite_datareader_1["Con3"].ToString();//read from spicific row
                    C4.Text = sqlite_datareader_1["Con4"].ToString();//read from spicific row
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Fresh()//fresh data good for health
        {
            Professional_Rate.Text = null;
            Method_Rate.Text = null;
            Meterial_Rate.Text = null;
            Learning_Total_Rate.Text = null;
            Effect_Rate.Text = null;
            Class.Text = null;
            Department.Text = null;
            College.Text = null;
            C1.Text = null;
            C2.Text = null;
            C3.Text = null;
            C4.Text = null;
        }


        /********************************************************/
        /*                S Q L  Code END                       */
        /********************************************************/

    }
}
