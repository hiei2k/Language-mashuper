using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;
using System.IO;
using System.Net;
using System.Web;
using System.Data.OleDb;

namespace 一切語言藏
{
    public partial class FormContextTool : Form
    {
        public SpVoice objSpeech;//TTS發音物件
        public Dictionary<string, string> dict = new Dictionary<string, string>();//用來接收LoadDoc所傳來的字典，即是要預習的單字
        public string str原始全文;
        public Font ft單字字型;
        public Font ft註釋字型;
        public string str文章前飾字串;
        public string str文章後飾字串;
        public string str單字前飾字串;
        public string str單字後飾字串;
        public string str註釋前飾字串;
        public string str註釋後飾字串;
        public string str註釋中飾字串;
        public bool bl註釋完整性;
        public bool bl註釋無詞性;
        public int int註釋中飾字串在註釋中的位置;

        public string str分頁字串;
        public int int相隔幾個單字插入分頁字串;
        public string strTranslateLanguage;

        int int當前位址;
        string str單字;
        int str單字長度;
        string[] strArr註釋值群;
        string str註釋;
        string str音標;

        //以下是「翻譯所選」功能的變數
        //連接DB
        OleDbConnection objConn;
        //查字典
        OleDbDataReader dr;
        //查字典
        OleDbCommand cmd;
        string adjustWord = null;//驗證過程中，用來儲存改來改去的字
        string origWord = null;//驗證過程中，用來儲存原本的字
        string rtbDocText = null;

        public FormContextTool()
        {
            InitializeComponent();
        }

        private void FormContextTool_Load(object sender, EventArgs e)
        {
            rtbDocText = rtbDoc.Text;
            cbMotherLanguage.Text = strTranslateLanguage;//將翻譯之目標語言設為主視窗所選的
            //Clipboard.;
            //資料庫連接

            //先將未加值的原始文章中的特殊符號編碼為HTML中的對映字元
            //也在斷行符號之前加上<br>，以讓維持原有格式
            rtbDocText = HttpUtility.HtmlEncode("   " + str原始全文 + "   ").Replace("\n", "<br>\n");
            
            //一定要三個空白，因為")]}"是三個，如果最後一個字需譯出，後面要有三個字元才不會溢位

            插入分頁字串();

            this.Enabled = false;
            //rtbDoc.Width = this.Size.Width * 9 / 10;
            //objSpeech = new SpVoice();
            rtbDoc.ContextMenuStrip = RightMenu;
            //rtbDocText = Doc;
            /*
            if (ft單字字型 == null)
                ft單字字型 = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            if (ft註釋字型 == null)
                ft註釋字型 = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            */

            //Dict中儲有該文章中的所有難字，每個單字都要在其左右加上"{[("，例："document" -> "{[(document)]}"
            foreach (KeyValuePair<string, string> item in dict)
            {
                Application.DoEvents();
                str單字長度 = item.Key.Length;
                str單字 = item.Key;

                //將該難字在文章中從頭到尾找一次，並一一在文中找到的該字兩旁加上{[()]}
                //確切的方法：IndexOf的startIndex參數意思係為[要從哪裡開始找]，是故每找完一個單字，就從該單字所出現的位置的結尾開始找
                //例：I am the king of the world，找完king字後，就繼續從of the world第一個字元(o)的位置開始找
                int當前位址 = 0;
                while (int當前位址 != -1 && int當前位址 < rtbDocText.Length)
                {
                    int當前位址 = rtbDocText.IndexOf(str單字, int當前位址, StringComparison.Ordinal);//找尋單字的位置，若找不到，則為-1
                    if (int當前位址 != -1)
                    {
                        if (!char.IsLetter(rtbDocText, int當前位址 - 1) && !char.IsLetter(rtbDocText, int當前位址 + str單字長度))
                        {
                            if (rtbDocText.IndexOf(")]}", int當前位址 + str單字長度 - 1,3 , StringComparison.Ordinal) == -1)
                                wordMark();//單字後若沒接著)]}，則標註之
                        }
                        int當前位址 += (str單字長度 + 7);//{[()]}與單字分隔符(如空白)，共7個
                    }
                }
                rtbDoc.Text = rtbDocText;
                this.Refresh();
            }

            //為單字加上註解
            foreach (KeyValuePair<string, string> item in dict)
            {
                Application.DoEvents();
                str單字長度 = item.Key.Length;
                str單字 = item.Key;
                //strArr註釋值群 = item.Value.Replace("\\n", "; ");
                string[] separators = {"||||"};
                strArr註釋值群 = item.Value.Split(separators, StringSplitOptions.None);
                //itemValueLength = item.Value.Length;
                str註釋 = strArr註釋值群[0];
                str音標 = strArr註釋值群[1];

                int當前位址 = 0;
                       
                //while (int當前位址 <= rtbDocText.Length && int當前位址 != -1)
                while(int當前位址 < rtbDocText.Length && int當前位址 != -1)
                {
                    int當前位址 = rtbDocText.IndexOf("{[(" + str單字 + ")]}", int當前位址, StringComparison.Ordinal);
                    wordDecorate();
                }
                rtbDoc.Text = rtbDocText;
                this.Refresh();
            }
            rtbDocText = str文章前飾字串 + rtbDocText + str文章後飾字串;
            rtbDoc.Text = rtbDocText;
            this.Refresh();

            this.Enabled = true;

            File.WriteAllText("C:\\MashUpper\\temp.htm", rtbDocText, Encoding.UTF8);
            System.Diagnostics.Process.Start("iexplore.exe", "C:\\MashUpper\\temp.htm");
        }

        private void 插入分頁字串()
        {
            int int累計單字數 = 0;
            int int第幾字元 = 0;
            char[] arr單字區隔符 = { ' ', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '*', ',', '.', '<', '>', '/', '?', ';', ':', '\'', '\"', '[', ']', '{', '}', '\\', '|', '`', '~' };

            while (int第幾字元 < rtbDocText.Length - 1)
            {
                //跑到下一個分頁點的條件達到為止
                while (int累計單字數 <= int相隔幾個單字插入分頁字串 && int第幾字元 < rtbDocText.Length)
                {
                    //判斷是否為單字區隔符
                    bool bl是否為單字區隔符 = false;
                    foreach (char char單字區隔符 in arr單字區隔符)
                    {
                        if (rtbDocText[int第幾字元] == char單字區隔符)
                        {
                            bl是否為單字區隔符 = true;
                            break;
                        }
                    }
                    if (bl是否為單字區隔符) int累計單字數++;
                    int第幾字元++;
                }

                //分頁條件達成後，跑到該段結束為止，做為真正的分頁點
                while (int第幾字元 < rtbDocText.Length && rtbDocText[int第幾字元] != '.')
                { int第幾字元++; }

                if (int第幾字元 + 1 < rtbDocText.Length)
                {
                    rtbDocText = rtbDocText.Insert(int第幾字元 + 1, str分頁字串);
                    int累計單字數 = 0;
                    int第幾字元 += str分頁字串.Length + 1;
                    //MessageBox.Show(rtbDocText[int第幾字元].ToString());
                }
            }
        }

        private void wordDecorate()//為單字加粗體，並且標註有顏色之中文解釋
        {
            if (int當前位址 != -1)
            {
                //rtbDoc.Select(int當前位址, str單字長度 + 6);//6的來源：{[()]}，共6個字元

                string[] strArr註釋中斷詞 = { ",", ";", "vt.", "vi.", "a.", "n.", "v.", "vbl.", "adj.", "adv.", "ad.", "prep." };
                string[] strArr詞性 = { "vt.", "vi.", "a.", "n.", "v.", "vbl.", "adj.", "adv.", "ad.", "prep." };

                //註釋無詞性：註釋中不要出現詞性標註
                if (bl註釋無詞性)
                {
                    foreach (var str詞性 in strArr詞性)
                    {
                        str註釋 = str註釋.Replace(str詞性, "");
                    }
                }

                //註釋完整性：即使註釋太長，至少最後一個顯示的也不能被咖到
                int int調整後註釋中飾字串在註釋中的位置 = 0;
                if (bl註釋完整性)
                {
                    if (int註釋中飾字串在註釋中的位置 < str註釋.Length)
                    {
                        string str註釋tmp = str註釋;
                        foreach (var str註釋中斷詞 in strArr註釋中斷詞)
                        {
                            if (str註釋tmp.Substring(int註釋中飾字串在註釋中的位置).Contains(str註釋中斷詞))
                                str註釋tmp = str註釋tmp.Substring(0, str註釋tmp.
                                    IndexOf(str註釋中斷詞, int註釋中飾字串在註釋中的位置));
                        }
                        int調整後註釋中飾字串在註釋中的位置 = str註釋tmp.Length;
                    }
                }
                else int調整後註釋中飾字串在註釋中的位置 = int註釋中飾字串在註釋中的位置;

                string str修飾後的單字與註釋 =
                    str單字前飾字串 + str單字 + str單字後飾字串 //+ str音標 
                    + str註釋前飾字串 +
                    str註釋.Insert((int註釋中飾字串在註釋中的位置 > str註釋.Length - 1) ?
                    str註釋.Length : int調整後註釋中飾字串在註釋中的位置, str註釋中飾字串) +
                    str註釋後飾字串;
                str修飾後的單字與註釋 = str修飾後的單字與註釋.Replace("{[(index)]}", int當前位址.ToString());
                //Clipboard.SetText(str修飾後的單字與註釋);
                //MessageBox.Show(Clipboard.GetText());
                rtbDocText = rtbDocText.Remove(int當前位址, str單字長度 + 6);
                rtbDocText = rtbDocText.Insert(int當前位址, str修飾後的單字與註釋);
                //rtbDoc.Paste();

                int當前位址 += str修飾後的單字與註釋.Length + 1;
                //rtbDoc.
            }
        }

        private void wordMark()
        {
            if (int當前位址 != -1)
            {
                string strTmp = rtbDocText.Substring(int當前位址, str單字長度);
                rtbDocText = rtbDocText.Remove(int當前位址, str單字長度);
                rtbDocText = rtbDocText.Insert(int當前位址, "{[(" + strTmp + ")]}");
                //rtbDoc.Select(int當前位址, str單字長度);
                //rtbDoc.SelectedText = "{[(" + rtbDoc.SelectedText + ")]}";
            }
        }


        private void btnSpeech_Click(object sender, EventArgs e)
        {
            objSpeech.Speak(rtbDoc.SelectedText, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void FormContextTool_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void rtbDoc_MouseDown(object sender, MouseEventArgs e)
        {
            if (rtbDoc.SelectedText == "")
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

        private void 剪下CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbDoc.SelectedText != "")
                rtbDoc.Cut();
        }

        private void 貼上PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.Paste();
        }

        private void 複製CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbDoc.SelectedText != "")
                rtbDoc.Copy();
        }

        private void 全選AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDoc.SelectAll();
        }

        private void 朗讀所選VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objSpeech.Speak(rtbDoc.SelectedText, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        private void 翻譯所選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objConn = new System.Data.OleDb.OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\EN_" + cbMotherLanguage.Text + ".mdb");
            objConn.Open();
            cmd = objConn.CreateCommand();

            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + rtbDoc.SelectedText + "'";
            dr = cmd.ExecuteReader();

            //以下開始是判斷單字的變化型態
            adjustWord = origWord = rtbDoc.SelectedText.Trim();
            if (!dr.Read())
            {
                if (adjustWord.EndsWith("s"))
                {
                    if (adjustWord.EndsWith("ies"))
                    { 
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "y";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else if (adjustWord.EndsWith("es"))
                    { 
                        adjustWord = adjustWord.Remove(adjustWord.Length - 2, 2);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    if (adjustWord == origWord)//字尾直接加s，為免與es混淆，不能用else
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 1, 1);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                }
                else if (adjustWord.EndsWith("ed"))
                {
                    if (adjustWord.EndsWith("ied"))
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "y";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else//驗證+ed
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 2, 2);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }

                    if (adjustWord == origWord)//驗證：重覆字尾+ed
                    {
                        if (adjustWord[adjustWord.Length - 3] == adjustWord[adjustWord.Length - 4])//驗證：重覆字尾+ed
                        {
                            adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3);
                            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                            dr.Close();
                            dr = cmd.ExecuteReader();
                            adjustWord = dr.Read() ? adjustWord : origWord;
                        }
                    }
                    
                    if (adjustWord == origWord)//驗證：字尾有e，直接+d
                    {
                        if (adjustWord[adjustWord.Length - 2] == 'e')
                        {
                            adjustWord = adjustWord.Remove(adjustWord.Length - 1, 1);
                            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                            dr.Close();
                            dr = cmd.ExecuteReader();
                            adjustWord = dr.Read() ? adjustWord : origWord;
                        }
                    }
                }
                else if (adjustWord.EndsWith("r"))
                {
                    if (adjustWord.EndsWith("ier"))
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "y";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else if (adjustWord.EndsWith("er"))
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 2, 2);//假設是「直接加er」
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;

                        if (adjustWord == origWord)//假設是「字尾有e而+r」
                        {
                            adjustWord = adjustWord.Remove(adjustWord.Length - 1, 1);
                            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                            dr.Close();
                            dr = cmd.ExecuteReader();
                            adjustWord = dr.Read() ? adjustWord : origWord;
                        }
                    }
                    
                }
                else if (adjustWord.EndsWith("t"))
                {
                    if (adjustWord.EndsWith("iest"))
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 4, 4) + "y";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else//驗證+est
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                }
                else if (adjustWord.EndsWith("ly"))
                {
                    if (adjustWord.EndsWith("ally"))
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 4, 4);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else if (adjustWord.EndsWith("ily"))//驗證去y+ily
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "y";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    else//驗證+ly
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 2, 2);
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    if (adjustWord == origWord)//驗證-e+ly
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 2, 2) + "e";
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                }
                else if (adjustWord.EndsWith("ing"))
                {
                    adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3);
                    cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                    dr.Close();
                    dr = cmd.ExecuteReader();
                    adjustWord = dr.Read() ? adjustWord : origWord;
                    if (adjustWord == origWord)
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "e";//驗證 -e+ing
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    if (adjustWord == origWord)
                    {
                        adjustWord = adjustWord.Remove(adjustWord.Length - 3, 3) + "y";//驗證 -y+ing
                        cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                        dr.Close();
                        dr = cmd.ExecuteReader();
                        adjustWord = dr.Read() ? adjustWord : origWord;
                    }
                    if (adjustWord == origWord)
                    {
                        if (adjustWord[adjustWord.Length - 4] == adjustWord[adjustWord.Length - 5])//驗證 重複字尾+ing
                        {
                            adjustWord = adjustWord.Remove(adjustWord.Length - 4, 4);//刪除重複的字尾和ing
                            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
                            dr.Close();
                            dr = cmd.ExecuteReader();
                            adjustWord = dr.Read() ? adjustWord : origWord;
                        }
                    }
                }
            }
            else
            { adjustWord = origWord; }
            //單字變化判斷結束

            cmd.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + adjustWord + "'";
            dr.Close();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string pastedStr = origWord + dr["解釋"].ToString(); 
                int selectedLength = origWord.Length;
                Clipboard.SetText(pastedStr);
                rtbDoc.Paste();
                rtbDoc.Select(rtbDoc.Text.IndexOf(pastedStr) + selectedLength, dr["解釋"].ToString().Length);
                rtbDoc.SelectionFont = ft註釋字型;
                rtbDoc.SelectionColor = Color.IndianRed;
            }

            dr.Close();
            objConn.Close();
        }

        private void btnTransSelected_Click(object sender, EventArgs e)
        {
            翻譯所選ToolStripMenuItem_Click(sender, e);
        }
    }
}
