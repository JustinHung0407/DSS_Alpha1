//********************************************************//
//            DEVEELOPED BY  TKU IIT AI 2                 //
//              LEAD BY DR. CHIU LIU                      //
//                                                        //
//        BUILD PLATFORM :                                //
//            AMD A8-7600                                 //
//            8G DDR3L                                    //
//            WINDOES 10 INSIDER PREVIEW BUILD.14342      //
//            VISUAL STUDIO 2015(COMMUNITY)               //
//            SUBLIME 3                                   //
//                                                        //
//            USING PROGRAMING LANGUAGE : C#              //
//            DOT NET FRAMWORK 4.5.2                      // 
//                                                        //
//                                                        //
//            CHEN.M.T HUNG.Y.F PRESENT                   //
//            CONTACT gene31105@gmail.com                 //
//            CONTACT h40906h@yahoo.com.tw                //
//                     2016.5.31                          //
//********************************************************//


//----------been simplified----------------------//
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
//----------been simplified----------------------//

namespace DSS_Alpha1
{
    public partial class MainFrame : Form
    {
        //啟動splash screen
        //thread sleep for 3000ms
        public MainFrame()
        {
            Thread splash = new Thread(new ThreadStart(Splash_Start));
            splash.Start();
            Thread.Sleep(3000);

            InitializeComponent();

            splash.Abort();
        }
        //*************************************************************//
        //                           按鈕                              //
        //*************************************************************//
        //資料鍵入畫面
        //如果沒資料 顯示警告訊息
        //若有資料 則進入datainput.cs的視窗
        //************************************************************//
        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Data.db"))
            {
                MessageBox.Show("Setup Initial Setting First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataInput frm = new DataInput();
                frm.ShowDialog();
            }

        }
        //關於畫面按鈕
        //成員簡介
        private void 關於ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();//cooler ;)
        }
        //離開按鈕
        //Confirm before Exit
        private void Exit_But_Click(object sender, EventArgs e)
        {
            DialogResult exit_Result;
            exit_Result = MessageBox.Show("確定離開?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (exit_Result == DialogResult.OK)
                Application.ExitThread();
        }
        //*************************************************************//
        //*                          按鈕END                           //
        //*************************************************************//


        //************************************************************//
        //                    MainFRM程式進入點                       //
        //************************************************************//
        private void MainFrame_Load(object sender, EventArgs e)
        {
            //嘗試連接資料庫
            //若無法連接則接收例外處理顯示MessageBox訊息
            try
            {
                //連接到資料庫
                //同步到資料
                ConnectDB();
                Sync_Box();
                //預先選定學期
                SubBox.SelectedIndex = 0;
                CurrCom.SelectedText = show_Semester();
                LastCom.SelectedIndex = CurrCom.Items.Count - 2;

                Parent_Current.Text = show_Semester();
                Parent_Last.Text = show_Semester(true);
                Parent_Current_Label2.Text = show_Semester();
                Parent_Last2.Text = show_Semester(true);
                /*************/
                //從資料庫讀出學期資料
                Read_Curr_Data(Convert.ToString(SubBox.Text), show_Semester());
                Read_Last_Data(Convert.ToString(SubBox.Text), show_Semester(true));
                //教師建議欄預設文字
                label78.Text = "點擊重整";
                //call compare func. on loading
                Compare();
            }
            catch (Exception)
            {
                MessageBox.Show("Not Setting up yet?\n Or Database Error");
            }
            //首次登入頁面將首頁設成空白
            initialRun();
        }

        //************************************************************//
        //                             動作                           //
        //************************************************************//

        /*show subject has selected
         *
         *Read_[...]_Data to load [...] data from database
         *
         *flush func. to flush previous data out 
         *
         *compare func. to read and compare datas
         *
         *syncbox func. to read all data
         */
        private void SubBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            flush();
            Read_Curr_Data(SubBox.Text, CurrCom.Text);
            Read_Last_Data(SubBox.Text, LastCom.Text);
            Compare();
        }
        //read data while select Current semester combobox
        private void CurrCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            flush();
            Parent_Current.Text = CurrCom.Text;
            Read_Last_Data(SubBox.Text, LastCom.Text);
            Read_Curr_Data(SubBox.Text, CurrCom.Text);
            Compare();
        }
        //read data while select Last semester combobox
        private void LastCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            flush();
            Parent_Last.Text = LastCom.Text;
            Read_Last_Data(SubBox.Text, LastCom.Text);
            Read_Curr_Data(SubBox.Text, CurrCom.Text);
            Compare();
        }

        private void SubBox_Click(object sender, EventArgs e)
        {
            Sync_Box();
        }

        private void LastCom_Click(object sender, EventArgs e)
        {
            Sync_Box();
        }

        private void CurrCom_Click(object sender, EventArgs e)
        {
            Sync_Box();
        }
        //************************************************************//
        //                    動作 END                                //
        //************************************************************//


        //************************************************************//
        //****                  建議                             *****//
        //************************************************************//

        //重新整理教學建議
        //用陣列去存取並判斷建議項目
        private void Reload_Click(object sender, EventArgs e)
        {
            Label[] last = new Label[] { label56, label61, label66, label67 };
            Label[] curr = new Label[] { label68, label69, label70, label71 };

            int[] conv = new int[4];
            int[] convOrg = new int[4];
            Array.Sort(conv);

            label78.Text = "點擊重整";
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    conv[i] = Convert.ToInt32(curr[i].Text) - Convert.ToInt32(last[i].Text);
                    convOrg[i] = conv[i];
                }
                Array.Sort(conv);
                //顯示第一第二及第三項建議
                if (conv[3] > 0)
                {
                    label78.Text = Sugg(Array.IndexOf(convOrg, conv[3]));
                    if (conv[2] > 0)
                    {
                        label78.Text += ",且" + Sugg(Array.IndexOf(convOrg, conv[2]));
                    }
                    if (conv[1] > 0)
                    {
                        label78.Text += "。\n另外, " + Sugg(Array.IndexOf(convOrg, conv[1]));
                    }
                }
                else
                {
                    label78.Text = Sugg(4);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Value");
            }
        }
        //顯示建議項目
        public string Sugg(int num)
        {
            switch (num)
            {
                case 0:
                    return "教材需重新評估難易度以符合學生程度";
                case 1:
                    return "教師於課堂中可加入其他元素增加學生興趣";
                case 2:
                    return "可嘗試變換教學方針";
                case 3:
                    return "多面帶微笑可增進師生情誼";
                case 4:
                    return "不錯";
                default:
                    return "嗨 我崩潰了:) System Error";
            }
        }
        //************************************************************//
        //****                      建議                         *****//
        //************************************************************//


        //************************************************************//
        //WIP
        private void SemChose_btn_1_Click(object sender, EventArgs e)
        {/*
            Compare_Rates Com_Frm = new Compare_Rates();
            //這邊就是傳遞自己的參考指標給Form2的Owner屬性
            Com_Frm.Owner = this;
            Com_Frm.ShowDialog();*/
        }
        //************************************************************//
        //選擇科目
        private void Subject_Click(object sender, EventArgs e)
        {
            Subject_Input subFrm = new Subject_Input();
            subFrm.ShowDialog();
        }
        //選擇學期
        private void Sem_Click(object sender, EventArgs e)
        {
            Semester_Input subFrm = new Semester_Input();
            subFrm.ShowDialog();
        }
        //************************************************************//



        /*******************************
         *            FUNC.   START    *
         *******************************/
        //show this semester
        //將學年度分為兩個學期
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

        //顯示學期
        public string show_Semester(bool get_bool)//last sem
        {
            if (get_bool)
            {
                if ((Convert.ToInt32(show_Semester()) % 100) == 2)
                {
                    return Convert.ToString(Convert.ToInt32(show_Semester()) - 1);
                }
                else
                {
                    return Convert.ToString(Convert.ToInt32(show_Semester()) / 10) + "02";
                }
            }
            else
            {
                return show_Semester();
            }
        }

        //教學評分比較
        //學生反映比較
        public void Compare()
        {
            Label[] Last_labs = new Label[] { label34, label35, label36, label37, label38 };
            Label[] Curr_labs = new Label[] { label42, label43, label44, label45, label46 };
            Label[] Comp_labs = new Label[] { label50, label51, label52, label53, label54 };
            //
            Label[] Tab2_Last_labs = new Label[] { label56, label61, label66, label67 };
            Label[] Tab2_Curr_labs = new Label[] { label68, label69, label70, label71 };
            Label[] Tab2_Comp_labs = new Label[] { label72, label73, label74, label75 };
            float[] Curr = new float[5];
            float[] Last = new float[5];
            int[] Tab2_Curr = new int[4];
            int[] Tab2_Last = new int[4];
            float tmp;
            //
            for (int count = 0; count < 5; count++)
            {

                try
                {
                    Last[count] = Convert.ToSingle(Last_labs[count].Text);
                    Curr[count] = Convert.ToSingle(Curr_labs[count].Text);
                }
                catch (Exception)
                {
                    Last[count] = 0;
                    Curr[count] = 0;
                    Last_labs[count].Text = "NULL";
                    Curr_labs[count].Text = "NULL";
                    label39.Text = "NULL";
                    label40.Text = "NULL";
                    label41.Text = "NULL";
                    label47.Text = "NULL";
                    label48.Text = "NULL";
                    label49.Text = "NULL";
                }
            }
            //教學評分比較
            for (int i = 0; i < 5; i++)
            {
                tmp = (Curr[i] = (Curr[i] / 6) * 100) - (Last[i] = (Last[i] / 6) * 100);

                if (tmp < 0)
                {
                    Comp_labs[i].Text = "下降" + Convert.ToString(Math.Round(tmp, 2) * -1) + "%";
                    Comp_labs[i].ForeColor = Color.Red;
                }
                else if (tmp == 0)
                {
                    Comp_labs[i].Text = "維持" + Convert.ToString(Math.Round(tmp, 2) * -1) + "%";
                    Comp_labs[i].ForeColor = Color.Violet;
                }
                else
                {
                    Comp_labs[i].Text = "上升" + Convert.ToString(Math.Round(tmp, 2)) + "%";
                    Comp_labs[i].ForeColor = Color.Green;
                }
            }

            for (int count = 0; count < 4; count++)
            {
                try
                {
                    Tab2_Last[count] = Convert.ToInt32(Tab2_Last_labs[count].Text);
                    Tab2_Curr[count] = Convert.ToInt32(Tab2_Curr_labs[count].Text);
                }
                catch (Exception)
                {
                    Tab2_Last[count] = 0;
                    Tab2_Curr[count] = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        Tab2_Last_labs[count].Text = "NULL";
                        Tab2_Curr_labs[count].Text = "NULL";
                    }
                }
            }
            //學生反映比較
            for (int j = 0; j < 4; j++)
            {

                tmp = (Tab2_Curr[j] - Tab2_Last[j]);
                if (tmp < 0)
                {
                    Tab2_Comp_labs[j].Text = "減少" + Convert.ToString(tmp * -1);
                    Tab2_Comp_labs[j].ForeColor = Color.Green;
                }
                else if (tmp == 0)
                {
                    Tab2_Comp_labs[j].Text = "維持" + Convert.ToString(tmp * -1);
                    Tab2_Comp_labs[j].ForeColor = Color.Violet;
                }
                else
                {
                    Tab2_Comp_labs[j].Text = "增加" + Convert.ToString(tmp);
                    Tab2_Comp_labs[j].ForeColor = Color.Red;
                }
            }

        }
        //初始所有標籤為NULL
        //(按鈕用)
        public void flush()
        {
            Label[] f = new Label[] { label34, label35, label36, label37, label38,
                                              label42, label43, label44, label45, label46,
                                              label50, label51, label52, label53, label54,
                                              label56, label61, label66, label67, label68,
                                              label69, label70, label71, label72, label73,
                                              label74, label75 };//27

            for (int i = 0; i < 27; i++)
            {
                f[i].Text = null;
            }
        }
        //初始所有標籤為NULL
        //(主程式載入時使用)
        public void initialRun()
        {
            Label[] tabs = new Label[] { label34, label35, label36, label37, label38,
                                              label42, label43, label44, label45, label46,
                                              label50, label51, label52, label53, label54,
                                              label56, label61, label66, label67, label59,
                                              label68, label69, label70, label71, label57,
                                              label72, label73, label74, label75, Parent_Current_Label2,
                                              Parent_Last2,label78,Parent_Last,Parent_Current};
            for (int i = 0; i < tabs.Length; i++)
            {
                tabs[i].Text = "";
            }
        }
        //splash start
        public void Splash_Start()
        {
            Application.Run(new Splash());
        }
        //create splash
        public void Create_Start()
        {
            Application.Run(new Warning());
        }
        /*******************************
         *            FUNC.   END      *
         *******************************/



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
            //如果database裡面沒有Data.db
            //顯示splash並建立資料庫
            if (!File.Exists(dirPath))
            {
                SQLiteConnection.CreateFile(dirPath);
                FirstRun();
            }
            try
            {
                db_Conn.Open();
            }
            catch (Exception)
            {

                Thread creat_Splash = new Thread(new ThreadStart(Create_Start));
                creat_Splash.Start();
                Thread.Sleep(3000);
                creat_Splash.Abort();
                FirstRun();
            }
            //db_Conn.Open();
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
                Close();
            }
        }

        //重新載入主頁面的學期combobox或科目combobox
        public void Sync_Box()
        {

            //1.載入主頁面的科目combobox
            SubBox.Items.Clear();//clean !IMPORTANT

            SQLiteCommand s_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) obj

            s_CMD = db_Conn.CreateCommand();//create command
            s_CMD.CommandText = "SELECT * FROM SubjectData"; //select table

            SQLiteDataReader sqlite_datareader = s_CMD.ExecuteReader();

            while (sqlite_datareader.Read()) //read every data
            {
                string name_load = sqlite_datareader["Subject"].ToString();
                SubBox.Items.Add(name_load);
            }

            //2.載入主頁面的學期combobox
            LastCom.Items.Clear();//clean !IMPORTANT
            CurrCom.Items.Clear();//clean !IMPORTANT

            SQLiteCommand s_CMD_2 = new SQLiteCommand(); //declare SCML(sqlite command line) obj

            s_CMD_2 = db_Conn.CreateCommand();//create command
            s_CMD_2.CommandText = "SELECT * FROM Semester"; //select table

            SQLiteDataReader sqlite_datareader_2 = s_CMD_2.ExecuteReader();

            while (sqlite_datareader_2.Read()) //read every data
            {
                string name_load = sqlite_datareader_2["Year"].ToString();
                LastCom.Items.Add(name_load);
                CurrCom.Items.Add(name_load);
            }
        }


        //將上次教學評分與學生反應載入主頁面
        //some bugs here minor bugs.(無法優化成array)
        public void Read_Last_Data(string sub, string semester)
        {

            SQLiteCommand sql_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) 
            sql_CMD = db_Conn.CreateCommand();//create command
            sql_CMD.CommandText = "SELECT * FROM DSS WHERE SubjectName = \"" + sub + "\" AND SemesterYear =\" " + semester + "\" ;"; //select table

            Label[] lab = new Label[] { label34, label35, label36, label37, label38, label39, label40, label41 };
            string[] str = new string[] { "Profession", "Method", "Meterial", "TeachingTotal", "Effect", "MClass", "MDepartment", "MCollege" };

            try
            {

                SQLiteDataReader sqlite_datareader = sql_CMD.ExecuteReader();//read data from sql

                while (sqlite_datareader.Read()) //read every data
                {
                    /*lab[i].Text = sqlite_datareader[ str[i] ].ToString();*/
                    label34.Text = sqlite_datareader["Profession"].ToString();//read from spicific row
                    label35.Text = sqlite_datareader["Method"].ToString();//read from spicific row
                    label36.Text = sqlite_datareader["Meterial"].ToString();//read from spicific row
                    label37.Text = sqlite_datareader["TeachingTotal"].ToString();//read from spicific row
                    label38.Text = sqlite_datareader["Effect"].ToString();//read from spicific row
                    label39.Text = sqlite_datareader["MClass"].ToString();//read from spicific row
                    label40.Text = sqlite_datareader["MDepartment"].ToString();//read from spicific row
                    label41.Text = sqlite_datareader["MCollege"].ToString();//read from spicific row
                    label56.Text = sqlite_datareader["Con1"].ToString();//con為學生反應
                    label61.Text = sqlite_datareader["Con2"].ToString();
                    label66.Text = sqlite_datareader["Con3"].ToString();
                    label67.Text = sqlite_datareader["Con4"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //將這次教學評分與學生反應載入主頁面
        //some bugs here minor bugs.(無法優化成array)
        public void Read_Curr_Data(string sub, string semester)
        {
            SQLiteCommand sql_CMD = new SQLiteCommand(); //declare SCML(sqlite command line) 
            sql_CMD = db_Conn.CreateCommand();//create command
            sql_CMD.CommandText = "SELECT * FROM DSS WHERE SubjectName = \"" + sub + "\" AND SemesterYear =\" " + semester + "\" ;"; //select table
            try
            {

                SQLiteDataReader sqlite_datareader = sql_CMD.ExecuteReader();//read data from sql
                while (sqlite_datareader.Read()) //read every data
                {
                    label42.Text = sqlite_datareader["Profession"].ToString();//read from spicific row
                    label43.Text = sqlite_datareader["Method"].ToString();//read from spicific row
                    label44.Text = sqlite_datareader["Meterial"].ToString();//read from spicific row
                    label45.Text = sqlite_datareader["TeachingTotal"].ToString();//read from spicific row
                    label46.Text = sqlite_datareader["Effect"].ToString();//read from spicific row
                    label47.Text = sqlite_datareader["MClass"].ToString();//read from spicific row
                    label48.Text = sqlite_datareader["MDepartment"].ToString();//read from spicific row
                    label49.Text = sqlite_datareader["MCollege"].ToString();//read from spicific row
                    label68.Text = sqlite_datareader["Con1"].ToString();//con為學生反應
                    label69.Text = sqlite_datareader["Con2"].ToString();
                    label70.Text = sqlite_datareader["Con3"].ToString();
                    label71.Text = sqlite_datareader["Con4"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //初始化所有database
        //包括DSS SubjectData Semester
        public void FirstRun()
        {
            string dirPath = "Data.db";

            //declare connection obj
            db_Conn = new SQLiteConnection("Data Source=" + dirPath + ";Version=3;");
            //connect to db !!!!!!!!!DONT FORGET TO CLOSE!!!!!!!!!!!!!
            db_Conn.Open();

            if (!TableExists("SubjectData", db_Conn))
            {
                DB_Command("CREATE TABLE SubjectData (Subject text);");
                DB_Command("INSERT INTO SubjectData (Subject) VALUES (null);");//set to current semester or may cause error
            }
            if (!TableExists("Semester", db_Conn))
            {
                DB_Command("CREATE TABLE Semester (Year int);");//create TABLE
                DB_Command("INSERT INTO Semester (Year) VALUES (" + show_Semester() + "); ");//set to current semester or may cause error
                DB_Command("INSERT INTO Semester (Year) VALUES (" + show_Semester(true) + "); ");//set to current semester or may cause error
            }
            if (!TableExists("DSS", db_Conn))
            {
                string sqlCreate = "CREATE TABLE DSS (SubjectName text ,SemesterYear float, Profession float,Method float,Meterial float,TeachingTotal float, Effect float, MClass float ,MDepartment float,MCollege float,Con1 int ,Con2 int,Con3 int,Con4 int);";
                DB_Command(sqlCreate);

            }
        }

        /********************************************************/
        /*                S Q L  Code END                       */
        /********************************************************/

    }
}
