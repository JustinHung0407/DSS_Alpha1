using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace DSS_Alpha1
{
    public partial class Data_Input : Form
    {
        public Data_Input()
        {
            InitializeComponent();
        }

        private void Save (object sender, EventArgs e)
        {
            /*
            *list main data
            *List.SelectedItem.ToString();
            *Convert.ToInt32(Sem_Box.SelectedItem.ToString());//convert to int
            * //RATES
            *Convert.ToInt32(Professional_Rate.Text);
            *Convert.ToInt32(Method_Rate.Text);
            *Convert.ToInt32(Meterial_Rate.Text);
            *Convert.ToInt32(Learning_Total_Rate.Text);
            *Convert.ToInt32(Effect_Rate.Text);
            *Convert.ToInt32(Class.Text);
            *Convert.ToInt32(Department.Text);
            *Convert.ToInt32(College.Text);
            * //CONS
            *Convert.ToInt32(C1.Text);
            *Convert.ToInt32(C2.Text);
            *Convert.ToInt32(C3.Text);
            *Convert.ToInt32(C4.Text);*/

            //Insert
            try
            {
                Insert_Data_Sets(
                    //list main data
                    List.SelectedItem.ToString(),
                    Convert.ToInt32(Sem_Box.SelectedItem.ToString()),//convert to int
                                                                     //RATES
                    Convert.ToInt32(Professional_Rate.Text),
                    Convert.ToInt32(Method_Rate.Text),
                    Convert.ToInt32(Meterial_Rate.Text),
                    Convert.ToInt32(Learning_Total_Rate.Text),
                    Convert.ToInt32(Effect_Rate.Text),
                    Convert.ToInt32(Class.Text),
                    Convert.ToInt32(Department.Text),
                    Convert.ToInt32(College.Text),
                    //CONS
                    Convert.ToInt32(C1.Text),
                    Convert.ToInt32(C2.Text),
                    Convert.ToInt32(C3.Text),
                    Convert.ToInt32(C4.Text)
                    );
                MessageBox.Show("Success", "Database IO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wrong Value");
                Optimize_DB();
                //Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data Incorrect");
                Optimize_DB();
                //Close();
            }


        }

        //reflash
        private void Reflash(object sender, EventArgs e)
        {
            Sync_Box();//flush func. already build-in.
        }

        private void DataInput_Load(object sender, EventArgs e)
        {
            ConnectDB();//open connection
            Optimize_DB();//optimize first
            Sync_Box();//reflash data first

            //Insert_Data_Sets("ASDFG", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);// FOR TESTING
        }

        private void Abort (object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Sure to Exit ?\n Remember to Save Before Leave or Data may not Save","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                Close();
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

            /*if (!File.Exists(dirPath))
            {
                //if not, ask to set up initial setting
                MessageBox.Show("Plz Finish Initial Setup First !", "Initial Setup Unseted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }*/

            //declare connection obj
            db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3;");
            //connect to db !!!!!!!!!DONT FORGET TO CLOSE!!!!!!!!!!!!!
            db_Conn.Open();
            //setup New Table
            if (!TableExists("DSS", db_Conn))
            {
                string sqlCreate = "CREATE TABLE DSS (SubjectName text ,SemesterYear int, Profession int,Method int,Meterial int,TeachingTotal int, Effect int, MClass int ,MDepartment int,MCollege int,Con1 int ,Con2 int,Con3 int,Con4 int);";
                DB_Command(sqlCreate);
            }
            Sync_Box();

        }
        //insert grid datas
        public void Insert_Data_Sets(String SN, int SY, int Pro, int Meth, int Meter, int TechT, int Eff,int MClass,int MDepartment, int MCollege, int C1, int C2, int C3,int C4)
        {
            DB_Command("INSERT INTO DSS VALUES  ('" + SN + "','" + SY + "','" + Pro + "','" + Meth + "','" + Meter + "','" + TechT + "','" + Eff + "','" + MClass + "','" + MDepartment + "','" + MCollege + "','" + C1 + "','" + C2 + "','" + C3 + "','" + C4 + "');");
        }
        //Delete row
        public void Delete_Data_Sets(int Year)
        {

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
            List.Items.Clear();//clean !IMPORTANT  (flush)
            SQLiteCommand sql_CMD_1 = new SQLiteCommand(); //declare SCML(sqlite command line) 
            sql_CMD_1 = db_Conn.CreateCommand();//create command
            sql_CMD_1.CommandText = "SELECT * FROM SubjectData"; //select table
            try
            {
                SQLiteDataReader sqlite_datareader_1 = sql_CMD_1.ExecuteReader();//read data from sql
                while (sqlite_datareader_1.Read()) //read every data
                {
                    string name_load_1 = sqlite_datareader_1["Subject"].ToString();//read from spicific row
                    List.Items.Add(name_load_1);
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
            DB_Command("DELETE FROM DSS WHERE rowid NOT IN(SELECT MIN(rowid) FROM DSS GROUP BY SubjectName, SemesterYear);");
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

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /********************************************************/
        /*                S Q L  Code END                       */
        /********************************************************/

    }
}
