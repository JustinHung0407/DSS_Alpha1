using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DSS_Alpha1
{
    public partial class Subject_Input : Form
    {
        public Subject_Input()
        {
            InitializeComponent();

            //disable Delete_Item botton while list is empty or may cause unexpection occur
            /*
            if (Sub_List.SelectedIndex == -1)
                Delete_Item.Enabled = false;*/

            
        }

        


        //add item
        private void New_Item_Click(object sender, EventArgs e)
        {
            
            string get_Item = Microsoft.VisualBasic.Interaction.InputBox("新增科目", "科目新增");

            if (Sub_List.Items.Contains(get_Item) == true)
                MessageBox.Show("重複科目!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else if (get_Item == "")
            {
                MessageBox.Show("空白!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string get_Str = get_Item;
                string INSERT_String = "INSERT INTO SubjectData (Subject) VALUES ('" + get_Str + "');";
                DB_Command(INSERT_String);
                Sync_Box();
            }
        }

        //save & exit
        private void Exit_Diag_Click(object sender, EventArgs e)
        {
            Sync_Box();
            Close();
        }

        //delete
        private void Delete_Item_Click(object sender, EventArgs e)
        {
            try
            {
                //Sub_List.Items.RemoveAt(Sub_List.SelectedIndex);
                string curr = Sub_List.SelectedItem.ToString();
                //MessageBox.Show(curr);
                string DEL_String = "DELETE FROM SubjectData WHERE Subject='" + curr + "';";
                DB_Command(DEL_String);
                Sync_Box();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Unless to choose an item or No item selected", "ArgumentOutOfRangeException", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Unless to choose an item or No item selected", "NullReferenceException",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        /********************************************************/
        /*                S Q L  Code Start                     */
        /********************************************************/

        //hold Connection
        SQLiteConnection db_Conn;

        //create DB
        public void CreateDB()
        {
            /*additional funcs:
             *                  password
             *                  ReadOnly Connection
             *                  etc.*/

            /*create DB(if exists then just connect)
             *test if Data.db exists or not.*/

            string dirPath = "Data.db";

            /* //if connection is open close first
            *if (db_Conn.State == ConnectionState.Open) db_Conn.Close();
            * //if exists then just connect       */

            if (!File.Exists(dirPath))
            {
                //if not, create file.
                SQLiteConnection.CreateFile(dirPath);
            }
            //declare connection obj
            db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3;");
            //connect to db !!!!!!!!!DONT FORGET TO CLOSE!!!!!!!!!!!!!
            db_Conn.Open();

        }

        //SQL Command
        public void DB_Command(string SQL_CMD_LINE)
        {

            //TRANSACTION WORK IN PROGRESS //CANT WORK NOW , TOO MANY EXPECTIONS
            //
            /************************************************************************
            * //SQLiteCommand("Command_Line", "Spicific_DB_Connection")
            * //ExecuteNonQuery = 這個方法不能執行查詢 只能做查詢以外的事情(新增 修改 刪除)
            *
            *DB OPENED...
            *
            * //GET SQL COMMAND
            *SQLiteCommand s_CMD = new SQLiteCommand(SQL_CMD_LINE, db_Conn);
            * //SET TRANSACTION
            *SQLiteTransaction DB_TRANS = db_Conn.BeginTransaction();
            *s_CMD.ExecuteNonQuery();
            *try
            *{
            *    //start local transaction
            *    s_CMD.Transaction = DB_TRANS;
            *    s_CMD.ExecuteNonQuery();
            *    DB_TRANS.Commit();
            *}
            *catch (Exception ex)
            *{
            *    DB_TRANS.Rollback();//ERROR,ROLLBACK
            *   MessageBox.Show(Convert.ToString(ex));//PRINT ERROR MESSAGE
            *}
            *************************************************************************/

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

        //sync to listbox
        public void Sync_Box()
        {
            Sub_List.Items.Clear();//clean !IMPORTANT

            SQLiteCommand s_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) obj

            s_CMD = db_Conn.CreateCommand();//create command
            s_CMD.CommandText = "SELECT * FROM SubjectData"; //select table

            SQLiteDataReader sqlite_datareader = s_CMD.ExecuteReader();

            while (sqlite_datareader.Read()) //read every data
            {
                string name_load = sqlite_datareader["Subject"].ToString();
                Sub_List.Items.Add(name_load);
            }
            DEL_NULL_DT();
        }

        //DEL NULL DATA
        public void DEL_NULL_DT()
        {
            DB_Command("DELETE FROM SubjectData WHERE Subject IS NULL;");
            DB_Command("DELETE FROM SubjectData WHERE Subject =\"\" ;");
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

        private void Subject_Input_Load(object sender, EventArgs e)
        {
            CreateDB();
            if (!TableExists("SubjectData", db_Conn))
            {
                string sql = "CREATE TABLE SubjectData (Subject text);";
                DB_Command(sql);
            }
            Sync_Box();
            /*string chk = "SELECT * FROM SubjectData;";
            SQLiteCommand cmd = new SQLiteCommand(chk,db_Conn);
            if ()
            Sync_Box();*/
        }

        /********************************************************/
        /*                S Q L  Code END                       */
        /********************************************************/




    }
}
