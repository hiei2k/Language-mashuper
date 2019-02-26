using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using DotNetSpeech;
using System.Net;
using System.Net.NetworkInformation;
using 一切語言藏;

namespace 一切語言藏
{
    public partial class LoadDoc : Form
    {
        string inputExplain = null;
        //用來儲存輸入框的說明文字，為了要達成「滑鼠點到輸入框，若是說明文字，則將說明清空的功能」

        SpVoice objSpeech;

        OleDbConnection odc詞頻典連線;
        OleDbConnection odc字典連線;
        OleDbDataReader oddr查字典;
        OleDbDataReader oddr查詞頻典;
        OleDbCommand odCmd查字典;
        OleDbCommand odCmd查詞頻典;

        //儲存載入文章，可載入好幾篇，故用List存之。
        List<WordFrequencyCounter.Document> Docs;

        //記錄文章中每個 單字 及其 出現次數
        WordFrequencyCounter.WordFrequency wordFrequency;

        //記錄每個單字之中、英對照，這是要用來餵「單字學習」各模組的物件
        Dictionary<string, string> Dict各單字之雙語對照 = new Dictionary<string, string>();

        //以下這些字會被忽略，在詞頻典中is, are, am等被統一記為be，所以要在此忽略，否則會被當成難字
        string[] strArr忽略字 = { "is", "are", "am", "an", "have", "has", "was", "were", "been", "cannot", "don", "didn", "doesn", "haven", "hasn", "re", "ve", "shan", "shouldn", "aren", "weren", "ll", "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        //版本與廣告網址的設定字串的來源URLs，每個字串是一個儲存設定資料的網頁，
        //是作為備用的，放越多網址進去，就有越多個備用空間儲存資料。如果上一個網頁掛了，就會嘗試下一個。    

        public static int int難度 = 3000;//難度
        public static string str母語 = "German";//母語

        public static float currentVersion = 2.03F;//目前所執行的程式的版本

        public static Font fontGeneralWord = null;
        public static Font fontGeneralExplain = null;
        public static Color colorGeneralWord = Color.Black;
        public static Color colorGeneralExplain = Color.Black;
        public static Color colorGeneralBackGround = Color.FromArgb(136, 224, 147);

        public static bool blPlayCardIsVerticle = true;
        public static int intPlayCardInterval = 6;
        public static int intPlayCardRepeatTime = 2;

        public static bool IsContextToolUsed = false;
        public static bool IsPlayCardUsed = false;

        

        Font ft單字字型 = null;
        Font ft註釋字型 = null;

        public LoadDoc()
        {
            InitializeComponent();
        }

        private void btnLoadDoc_Click(object sender, EventArgs e)
        {
            odc字典連線 = new System.Data.OleDb.OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\EN_" + cb目標語言.Text + ".dll");

            odc詞頻典連線 = new System.Data.OleDb.OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\WordFrequency.dll");

            DGVResult.Rows.Clear();
            progressBar.Value = 0;
            panel1.Visible = true;
            
            this.Enabled = false;

            Dict各單字之雙語對照.Clear();
            //1.建立文件清單，2.將所載入之文件加到清單中，3.再將清單丟給詞頻物件分析其詞頻
            
            Docs = new List<WordFrequencyCounter.Document>();//建立文件清單
            Docs.Add(new WordFrequencyCounter.Document(tbDoc.Text, false, strArr忽略字));//將所載入之文件加到清單中
            wordFrequency = new WordFrequencyCounter.WordFrequency(Docs);//將清單丟給詞頻物件分析其詞頻

            //此後，wordFrequency記錄著文章中的每個單字，以及其在文章中出現之頻率

            progressBar.Maximum = wordFrequency.Frequencies.Count;//進度條最大值設為單字數
            lbTotalWordNum.Text = progressBar.Maximum.ToString();//「共多少單字要查」的label

            this.Refresh();//重繪表單以顯示最新資訊

            odc詞頻典連線.Open();
            odc字典連線.Open();
            odCmd查字典 = odc字典連線.CreateCommand();//用來查單字解釋
            odCmd查詞頻典 = odc詞頻典連線.CreateCommand();//用來查詞頻

            //將文章中的每個單字，查出其中文解釋，以及其語料詞頻排行
            //str調整中單字原形：一個字串配對一個數字，即單字配對其文件詞頻
            //str文中單字變化形.Key：單字；str文中單字變化形.Value：詞頻

            string str調整中單字原形 = null;//驗證過程中，用來儲存改來改去的字
            string str文中單字變化形 = null;//驗證過程中，用來儲存原本的字(可能為變化形)

            foreach (KeyValuePair<string, int> singleWord in wordFrequency.Frequencies)
            {
                Application.DoEvents();
                try
                {
                    odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + singleWord.Key + "'";
                    oddr查字典 = odCmd查字典.ExecuteReader();

                    #region 判斷單字的變化型態
                    str調整中單字原形 = str文中單字變化形 = singleWord.Key.ToLower();
                    if (!oddr查字典.Read())
                    {
                        if (str調整中單字原形.EndsWith("s"))
                        {
                            if (str調整中單字原形.EndsWith("ies"))
                            { 
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "y";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else if (str調整中單字原形.EndsWith("es"))
                            { 
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 2, 2);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            if (str調整中單字原形 == str文中單字變化形)//字尾有直接加s，為免與es混淆，不能用else
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 1, 1);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                        }
                        else if (str調整中單字原形.EndsWith("ed"))
                        {
                            if (str調整中單字原形.EndsWith("ied"))
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "y";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else//驗證+ed
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 2, 2);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }

                            if (str調整中單字原形 == str文中單字變化形)//驗證：重覆字尾+ed
                            {
                                
                                if (str調整中單字原形[str調整中單字原形.Length - 3] == str調整中單字原形[str調整中單字原形.Length - 4])//驗證：重覆字尾+ed
                                {
                                    str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3);//刪除重覆的字尾+ed
                                    odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                    oddr查字典.Close();
                                    oddr查字典 = odCmd查字典.ExecuteReader();
                                    str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                                }
                            }

                            if (str調整中單字原形 == str文中單字變化形)//驗證：字尾有e，直接+d
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 1, 1);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                        }
                        else if (str調整中單字原形.EndsWith("r"))
                        {
                            if (str調整中單字原形.EndsWith("ier"))
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "y";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else if (str調整中單字原形.EndsWith("er"))
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 2, 2);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;

                                if (str調整中單字原形 == str文中單字變化形)//驗證字尾有e，直接+r
                                {
                                    str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 1, 1);
                                    odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                    oddr查字典.Close();
                                    oddr查字典 = odCmd查字典.ExecuteReader();
                                    str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                                }
                            }
                        }
                        else if (str調整中單字原形.EndsWith("t"))
                        {
                            if (str調整中單字原形.EndsWith("iest"))
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 4, 4) + "y";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else//驗證+est
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                        }
                        else if (str調整中單字原形.EndsWith("ly"))
                        {
                            if (str調整中單字原形.EndsWith("ally"))
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 4, 4);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else if (str調整中單字原形.EndsWith("ily"))//驗證去y+ily
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "y";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            else//驗證+ly
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 2, 2);
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            if (str調整中單字原形 == str文中單字變化形)//驗證-e+ly
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 2, 2) + "e";
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                        }
                        else if (str調整中單字原形.EndsWith("ing"))
                        {
                            str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3);
                            odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                            oddr查字典.Close();
                            oddr查字典 = odCmd查字典.ExecuteReader();
                            str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            if (str調整中單字原形 == str文中單字變化形)
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "e";//驗證 -e+ing
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            if (str調整中單字原形 == str文中單字變化形)
                            {
                                str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 3, 3) + "y";//驗證 -y+ing
                                odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                oddr查字典.Close();
                                oddr查字典 = odCmd查字典.ExecuteReader();
                                str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                            }
                            if (str調整中單字原形 == str文中單字變化形)
                            {

                                if (str調整中單字原形[str調整中單字原形.Length - 4] == str調整中單字原形[str調整中單字原形.Length - 5])//驗證 重複字尾+ing
                                {
                                    str調整中單字原形 = str調整中單字原形.Remove(str調整中單字原形.Length - 4, 4);//刪除重複的字尾和ing
                                    odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                                    oddr查字典.Close();
                                    oddr查字典 = odCmd查字典.ExecuteReader();
                                    str調整中單字原形 = oddr查字典.Read() ? str調整中單字原形 : str文中單字變化形;
                                }
                            }
                        }
                    }
                    else
                    { str調整中單字原形 = str文中單字變化形; }
                    #endregion 判斷單字變化型態

                    odCmd查字典.CommandText = "SELECT [解釋],[音標] FROM [DICT] where [單字] = '" + str調整中單字原形 + "'";
                    oddr查字典.Close();
                    oddr查字典 = odCmd查字典.ExecuteReader();

                    //MessageBox.Show(str調整中單字原形);
                    if (oddr查字典.Read())
                    {
                        
                        odCmd查詞頻典.CommandText = "SELECT [識別碼] FROM [15000Frequency] where [word] = '" + str調整中單字原形 + "'";
                        oddr查詞頻典 = odCmd查詞頻典.ExecuteReader();
                        //hSBDegree.Value：難度，該數字與每個單字語料詞頻的排名比較，是故越大則越難（越罕見）
                        //識別碼是詞頻典中之PK，即每個單字語料詞頻的排名
                        if ((oddr查詞頻典.Read() && Int32.Parse(oddr查詞頻典["識別碼"].ToString()) >= hsb難度.Value) || !oddr查詞頻典.HasRows)
                        {
                            
                            //把單字、中文、文章詞頻、語料詞頻排行一一放入詞頻分析表
                            //若在詞頻典中找不到，則其難度定為999999，使其在詞頻分析表中優先列出
                            //DGVResult.Rows.Add(singleWord.Key, oddr查字典["解釋"].ToString(), singleWord.Value, oddr查詞頻典.HasRows ? Int32.Parse(oddr查詞頻典["識別碼"].ToString()) : 999999);
                            DGVResult.Rows.Add(singleWord.Key, 
                                oddr查字典["解釋"].ToString() + "||||" + oddr查字典["音標"], 
                                oddr查詞頻典.HasRows ? Int32.Parse(oddr查詞頻典["識別碼"].ToString()) : 999999,
                                singleWord.Value);
                            //目前的系統需求不需計算本文詞頻，所以singleWord.Value皆以0替代
                            Dict各單字之雙語對照.Add(singleWord.Key, oddr查字典["解釋"].ToString() + "||||" + oddr查字典["音標"]);
                        }
                    }
                    oddr查字典.Close();
                    oddr查詞頻典.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message + ex.Source + ex.TargetSite + ex.);
                    //oddr查字典.Close();
                    //oddr查詞頻典.Close();
                }

                progressBar.Value++;
                lbDoneWordNum.Text = progressBar.Value.ToString();
                this.Refresh();//每查一個詞頻就重繪表單以顯示最新進度
            }

            odc詞頻典連線.Close();

            //詞頻分析表中預設以語料詞頻排行降冪排序，即難字排上面
            DGVResult.Sort(DGVResult.Columns["Degree"], ListSortDirection.Descending);

            panel1.Visible = false;
            this.Enabled = true;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            FormGeneral FG = new FormGeneral();
            FG.dict = Dict各單字之雙語對照;
            FG.objSpeech = objSpeech;
            FG.Show();
        }

        private void loadSetting()
        {
            if (File.Exists(Application.StartupPath + @"\setting"))
            {
                string[] strSetting = File.ReadAllText(Application.StartupPath + @"\setting").Split(',');
                /*strSetting 說明:
                 * [0]: [我會的單字量, how many words do I know?]
                 * [1]: Mother Language
                 * [2]: 上一次顯式的廣告序號
                 */
                int難度 = Int32.Parse(strSetting[0]);
                str母語 = strSetting[1];

                //將取得的設定資料指定至相關參數
                hsb難度.Value = int難度;
                lbDegree.Text = int難度.ToString();
                cb目標語言.Text = str母語;
                tb文章前飾字串.Text = strSetting[2];
                tb文章後飾字串.Text = strSetting[3];
                tb單字前飾字串.Text = strSetting[4];
                tb單字後飾字串.Text = strSetting[5];
                tb註釋前飾字串.Text = strSetting[6];
                tb註釋中飾字串.Text = strSetting[7];
                tb註釋中飾字串在註釋中的位置.Text = strSetting[8];
                tb註釋後飾字串.Text = strSetting[9];
                tb分頁字串.Text = strSetting[10];
                tb相隔幾個單字插入分頁字串.Text = strSetting[11];
                cb註釋完整性.Checked = Convert.ToBoolean(strSetting[12]);
                cb註釋無詞性.Checked = Convert.ToBoolean(strSetting[13]);
            }
        }

        private void saveSetting()
        {
            int難度 = hsb難度.Value;
            str母語 = cb目標語言.Text;

            File.WriteAllText(Application.StartupPath + @"\setting", 
                int難度.ToString() + "," + str母語 + "," +
                tb文章前飾字串.Text + "," + tb文章後飾字串.Text + "," + 
                tb單字前飾字串.Text + "," + tb單字後飾字串.Text + "," + tb註釋前飾字串.Text + ","
                + tb註釋中飾字串.Text + "," + tb註釋中飾字串在註釋中的位置.Text + "," + tb註釋後飾字串.Text + "," +
                tb分頁字串.Text + "," + tb相隔幾個單字插入分頁字串.Text + "," +
                cb註釋完整性.Checked.ToString() + "," + cb註釋無詞性.Checked.ToString());
        }

        private void LoadDoc_Load(object sender, EventArgs e)
        {
            //取得上次儲存的設定
            loadSetting();

            inputExplain = tbDoc.Text;//先將說明文字儲存，於tbDoc_Click之時比對用

            objSpeech = new SpVoice();
            //Application.StartupPath乃程式初執行之路徑，也就是程式檔案之所在位置；此處用以取得DB檔。

            var macs = from nic in NetworkInterface.GetAllNetworkInterfaces()
                       where nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                       select nic.GetPhysicalAddress().ToString();

            int int符合數量 = 0;
            string str密碼;
            bool bl開發機 = false;
            foreach (var item in macs)
            {
                if ("001CBFBC2C1D" == item ||//開發機
                    "C80AA95E5D1C" == item ||//周芷翎的
                    "F0038C36E592" == item//李映潔的
                    ) int符合數量++;
                if ("001CBFBC2C1D" == item) bl開發機 = true;
                
            }
            if (int符合數量 == 0) Application.Exit();
            if (bl開發機 == false)
            {
                str密碼 = Prompt.ShowDialog("請輸入密碼", "請輸入密碼");
                if (str密碼 != "5. 53xu/6" &&//周芷翎的
                    str密碼 != "xu3u/4ru,6") //李映潔的
                    Application.Exit();
            }
        }

        private void btnContext_Click(object sender, EventArgs e)
        {
            FormContextTool FCT = new FormContextTool();//輔助閱讀視窗
            //FCT.rtbDoc.Text = tbDoc.Text;
            //tbDoc.SelectAll();
            //tbDoc.Copy();
            FCT.str原始全文 = tbDoc.Text;
            FCT.dict = Dict各單字之雙語對照;
            FCT.ft單字字型 = ft單字字型;
            FCT.ft註釋字型 = ft註釋字型;
            FCT.str文章前飾字串 = tb文章前飾字串.Text;
            FCT.str文章後飾字串 = tb文章後飾字串.Text;
            FCT.str單字前飾字串 = tb單字前飾字串.Text;
            FCT.str單字後飾字串 = tb單字後飾字串.Text;
            FCT.str註釋前飾字串 = tb註釋前飾字串.Text;
            FCT.str註釋後飾字串 = tb註釋後飾字串.Text;
            FCT.str註釋中飾字串 = tb註釋中飾字串.Text;
            FCT.bl註釋完整性 = cb註釋完整性.Checked;
            FCT.bl註釋無詞性 = cb註釋無詞性.Checked;

            FCT.int註釋中飾字串在註釋中的位置 = Int32.Parse((tb註釋中飾字串在註釋中的位置.Text == "") ? "0" : tb註釋中飾字串在註釋中的位置.Text);

            FCT.str分頁字串 = tb分頁字串.Text;
            FCT.int相隔幾個單字插入分頁字串 = Int32.Parse(tb相隔幾個單字插入分頁字串.Text);

            FCT.strTranslateLanguage = cb目標語言.Text;
            FCT.objSpeech = objSpeech;
            FCT.Show();
        }

        private void btnMassInput_Click(object sender, EventArgs e)
        {

        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            objSpeech.Speak(tbDoc.SelectedText, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void LoadDoc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tbDoc.ContextMenuStrip = this.RightMenu;
            }

        }

        private void 複製CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbDoc.SelectedText != "")
                tbDoc.Copy();
        }

        private void 剪下CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbDoc.SelectedText != "")
                tbDoc.Cut();
        }

        private void 貼上PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbDoc.Paste();
        }

        private void tbDoc_MouseDown(object sender, MouseEventArgs e)
        {
            if (tbDoc.SelectedText == "")
            {
                剪下CToolStripMenuItem.Enabled = false;
                複製CToolStripMenuItem.Enabled = false;
            }
            else 
            {
                剪下CToolStripMenuItem.Enabled = true;
                複製CToolStripMenuItem.Enabled = true;
            }
        }

        private void 全選AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbDoc.SelectAll();
        }

        private void 朗讀所選VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objSpeech.Speak(tbDoc.SelectedText, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void btnft單字字型_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            ft單字字型 = (Font)fontDialog1.Font.Clone();
        }

        private void btnft註釋字型_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            ft註釋字型 = (Font)fontDialog1.Font.Clone();
        }

        private void 關於本軟體ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAbout FA = new FormAbout();
            FA.Show();
        }

        private void 拜訪作者網站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sutra.idv.tw/Author.htm");
        }

        private void tbDoc_Click(object sender, EventArgs e)
        {
            if (tbDoc.Text == inputExplain)
                tbDoc.Clear();
        }

        private void tbDoc_Leave(object sender, EventArgs e)
        {
            if (tbDoc.Text == "")
                tbDoc.Text = inputExplain;
        }

        private void btnGeneralSetting_Click(object sender, EventArgs e)
        {
            FormGeneralSetting FGS = new FormGeneralSetting();
            FGS.Show();
        }

        private void hSBDegree_Scroll(object sender, ScrollEventArgs e)
        {
            lbDegree.Text = hsb難度.Value.ToString();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout FA = new FormAbout();
            FA.Show();
        }

        private void LoadDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveSetting();
        }

        private void btn長文模式_Click(object sender, EventArgs e)
        {
            FormLongText FLT = new FormLongText();
            FLT.Show();
        }
    }
}
