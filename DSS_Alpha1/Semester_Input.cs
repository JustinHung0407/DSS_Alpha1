using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DSS_Alpha1
{
    public partial class Semester_Input : Form
    {
        public Semester_Input()
        {
            InitializeComponent();

            N_Time_Lable.Text = show_Time_Now();

        }
        //show this semester
        //顯示現在的學年度
        public string show_Time_Now()//Get time now
        {
            int y = 0, m = 0;
            DateTime time = DateTime.Now;
            y = time.Year;
            m = time.Month;
            if (m < 9)
            {
                return "目前是 : " + Convert.ToString(y - 1911 - 1) + " 學年度";
            }
            else
                return "目前是 : " + Convert.ToString(y - 1911) + " 學年度";
        }

        //存入總共的學期
        //每學年分兩學期(上，下)存入DB
        private void save_Click(object sender, EventArgs e)
        {
            //refresh while re-enter ui 
            DB_Command("DELETE FROM Semester");
            //get 
            string get_StartYear = textBox1.Text;
            string get_EndYear = textBox2.Text;
       
            CreateDB();
            try
            {
                int Count_Start_Year = Convert.ToInt32(get_StartYear);
                //loop for making single semester to double semester into database
                for (int i = Count_Start_Year; i <= Convert.ToInt32(get_EndYear); i++)
                {
                    DB_Command("INSERT INTO Semester (Year) VALUES (" + i + "01);");//01semester
                    DB_Command("INSERT INTO Semester (Year) VALUES (" + i + "02);");//02semester
                }
            }
            catch (FormatException)//catch non-number input
            {
                MessageBox.Show("Input A Number","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            Optimize_DB();//optimize data in descending  order

            db_Conn.Close();
            if (Convert.ToString(db_Conn.State) != "OPEN")
            {
                db_Conn.Open();
            }
            Close();
            
        }

        /********************************************************/
        /*                S Q L  Code Start                     */
        /********************************************************/

        //hold Connection

        SQLiteConnection db_Conn;

        public void CreateDB()
        {

            string dirPath = "Data.db";

            if (!File.Exists(dirPath))
            {
                SQLiteConnection.CreateFile(dirPath);
            }

            db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3");
            db_Conn.Open();
            //!!!!!!!!!!!  DO NOT FORGET TO CLOSE CONNECTION   !!!!!!!!!!!!!!!!!!!
        }

        //檢查有無table 
        //若沒有則建立一個
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

        //SQL 指令
        //建立SQL指令物件並呼叫
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
            }
        }

        //按照升幕排序重新整理學期
        public void Optimize_DB()
        {
            DB_Command("SELECT Year FROM Semester ORDER BY Year DESC;");
            /*to delete dumplicated value*/
            DB_Command("DELETE FROM DSS WHERE rowid NOT IN(SELECT MIN(rowid) FROM DSS GROUP BY SubjectName, SemesterYear);");
        }


        /*DELETE FROM DSS WHERE rowid NOT IN(SELECT MIN(rowid) FROM DSS GROUP BY SubjectName, SemesterYear);*/
        /*to delete dumplicated value*/
        /********************************************************/
        /*                S Q L  Code End                       */
        /********************************************************/

        //???dumplicate func.........
        //but still need it :)
        //顯示現在的學年
        public int Defult_Set()
        {
            int y = 0, m = 0;
            DateTime time = DateTime.Now;
            y = time.Year;
            m = time.Month;
            if (m < 9)
            {
                return (y - 1911 - 1);
            }
            else
                return (y - 1911);
        }
        //SHOW semester 
        public void SHOW_FUNCT()
        {
            try
            {
                SQLiteCommand pick_MIN = new SQLiteCommand("SELECT MIN (Year) FROM Semester;", db_Conn);//pick min
                SQLiteCommand pick_MAX = new SQLiteCommand("SELECT MAX (Year) FROM Semester;", db_Conn);//pick max
                textBox1.Text = Convert.ToString((Convert.ToInt32(pick_MIN.ExecuteScalar()) / 100));//some stupid stuff ;)
                textBox2.Text = Convert.ToString((Convert.ToInt32(pick_MAX.ExecuteScalar()) / 100));//some stupid stuff :)

            }
            catch (Exception) {
                MessageBox.Show("Database Error");
            }
        }
       
        //載入學期頁面確認有無資料庫
        private void Semester_Load(object sender, EventArgs e)
        {

            CreateDB();
            if (!TableExists("Semester", db_Conn))
            {
                DB_Command("CREATE TABLE Semester (Year int);");//create TABLE
                DB_Command("INSERT INTO Semester (Year) VALUES (" + Defult_Set() + "01); ");//set to current semester or may cause error
            }
            Optimize_DB();

            SHOW_FUNCT();
        }

    }
}
