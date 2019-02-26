using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CookComputing.XmlRpc;

namespace 一切語言藏
{
    public struct blogInfo
    {
        public string title;
        public string description;
    }

    public interface IgetCatList
    {
        [CookComputing.XmlRpc.XmlRpcMethod("metaWeblog.newPost")]
        string NewPage(int blogId, string strUserName, string strPassword, blogInfo content, int publish);
    }

    public partial class FormLongText : Form
    {
        public XmlRpcClientProtocol XRCP;
        public IgetCatList ICL;

        public FormLongText()
        {
            InitializeComponent();
        }

        private void btn單檔來源瀏覽_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tb單檔來源目錄.Text = openFileDialog1.FileName;
        }

        private void btn單檔轉換_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(去頭去尾(File.ReadAllText(tb單檔來源目錄.Text, Encoding.Default), tb標頭末行辨識.Text, tb結尾首行辨識.Text));

            File.WriteAllText(Path.GetDirectoryName(tb單檔來源目錄.Text) + "\\OK_" +
                Path.GetFileNameWithoutExtension(tb單檔來源目錄.Text) + Path.GetExtension(tb單檔來源目錄.Text),
                插入分頁字串(/*去頭去尾(*/File.ReadAllText(tb單檔來源目錄.Text, Encoding.Default)/*, tb標頭末行辨識.Text, tb結尾首行辨識.Text)*/), 
                Encoding.Unicode);

            MessageBox.Show("OK");
        }

        private void btn多檔轉換_Click(object sender, EventArgs e)
        {
            string[] strArrFilePaths = Directory.GetFiles(tb多檔來源目錄.Text);
            string str多檔輸出目錄 = tb多檔來源目錄.Text + "\\已加值文章";
            if (!Directory.Exists(str多檔輸出目錄))
                Directory.CreateDirectory(str多檔輸出目錄);
            foreach (string strFilePath in strArrFilePaths)
            {
                File.WriteAllText(str多檔輸出目錄 + "\\OK_" +
                    Path.GetFileNameWithoutExtension(strFilePath) + Path.GetExtension(strFilePath),
                    插入分頁字串(/*去頭去尾(*/File.ReadAllText(strFilePath, Encoding.Default)/*, tb標頭末行辨識.Text, tb結尾首行辨識.Text)*/),
                    Encoding.Unicode);
            }

            MessageBox.Show("OK");
        }

        private void btn多檔來源瀏覽_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb多檔來源目錄.Text = folderBrowserDialog1.SelectedPath;
        }

        //免費電子書的頭尾宣告字串之刪除
        private string 去頭去尾(string str全文, string str標頭末行辨識, string str結尾首行辨識)
        {
            int int起始位置 = str全文.IndexOf("\r\n", str全文.IndexOf(str標頭末行辨識)) + 1;
            int int結尾位置 = str全文.IndexOf(str結尾首行辨識) - 1;
            return str全文.Substring(int起始位置, int結尾位置 - int起始位置 + 1);
        }

        //輸入全文，即會分段進行加值，並插入分頁符號
        private string 插入分頁字串(string str全文)
        {
            MixTran MT;
            string str全文含分頁字串 = null;
            int int累計單字數 = 0;//累計已跨越過的單字數量，若大於[相隔幾個單字插入分頁字串？]的數字，則可插入分頁字串
            int int段落結束位置 = 0;
            int int段落起始位置 = 0;

            char[] arr單字區隔符 = { ' ', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '*', ',', '.', '<', '>', '/', '?', ';', ':', '\'', '\"', '[', ']', '{', '}', '\\', '|', '`', '~' };

            while (int段落結束位置 < str全文.Length - 1)
            {
                #region 跑到下一個分頁點的條件(跨越的單字數夠多時)達到為止
                while (int累計單字數 <= Int32.Parse(tb相隔幾個單字插入分頁字串.Text) && int段落結束位置 < str全文.Length)
                {
                    //判斷是否為單字區隔符
                    bool bl是否為單字區隔符 = false;
                    foreach (char char單字區隔符 in arr單字區隔符)
                    {
                        if (str全文[int段落結束位置] == char單字區隔符)
                        {
                            bl是否為單字區隔符 = true;
                            break;
                        }
                    }
                    if (bl是否為單字區隔符) int累計單字數++;
                    int段落結束位置++;
                }
                #endregion

                //分頁條件達成後，繼續往下跑到該句結束為止，做為真正的分頁點
                //以免在句子的中間進行分頁
                while (int段落結束位置 < str全文.Length && str全文[int段落結束位置] != '.')
                { int段落結束位置++; }

                //如果還沒到全文末尾，則插入分頁字串
                if (int段落結束位置 + 1 < str全文.Length)
                {
                    //MessageBox.Show(str全文.Substring(int段落起始位置, int段落結束位置 - int段落起始位置 + 1));
                    MT = new MixTran(str全文.Substring(int段落起始位置, int段落結束位置 - int段落起始位置 + 1),
                        hsb難度.Value, cb目標語言.Text, tb單字前飾字串.Text, tb單字後飾字串.Text, tb註釋前飾字串.Text,
                        tb註釋後飾字串.Text, tb註釋中飾字串.Text, Int32.Parse(tb註釋中飾字串在註釋中的位置.Text));

                    str全文含分頁字串 += MT.str全文 + tb分頁字串.Text;
                    int累計單字數 = 0;
                    int段落起始位置 = int段落結束位置 + 1;
                    //MessageBox.Show(rtbDoc.Text[int段落結束位置].ToString());
                }
            }

            #region 處理最後長度不足(單字數不足以分段)的段落
            MT = new MixTran(str全文.Substring(int段落起始位置, str全文.Length - int段落起始位置),
                hsb難度.Value, cb目標語言.Text, tb單字前飾字串.Text, tb單字後飾字串.Text, tb註釋前飾字串.Text,
                tb註釋後飾字串.Text, tb註釋中飾字串.Text, Int32.Parse(tb註釋中飾字串在註釋中的位置.Text));

            str全文含分頁字串 += MT.str全文;
            #endregion 處理最後長度不足(單字數不足以分段)的段落

            return str全文含分頁字串;
        }

        private void loadSetting()
        {
            if (File.Exists(Application.StartupPath + @"\settingLongText"))
            {
                string[] strSetting = File.ReadAllText(Application.StartupPath + @"\settingLongText").Split(',');
                /*strSetting 說明:
                 * [0]: [我會的單字量, how many words do I know?]
                 * [1]: Mother Language
                 * [2]: 上一次顯式的廣告序號
                 */
                
                //將取得的設定資料指定至相關參數
                hsb難度.Value = Int32.Parse(strSetting[0]);
                cb目標語言.Text = strSetting[1];
                tb單字前飾字串.Text = strSetting[2];
                tb單字後飾字串.Text = strSetting[3];
                tb註釋前飾字串.Text = strSetting[4];
                tb註釋中飾字串.Text = strSetting[5];
                tb註釋中飾字串在註釋中的位置.Text = strSetting[6];
                tb註釋後飾字串.Text = strSetting[7];
                tb分頁字串.Text = strSetting[8];
                tb相隔幾個單字插入分頁字串.Text = strSetting[9];
                tb標頭末行辨識.Text = strSetting[10];
                tb結尾首行辨識.Text = strSetting[11];
            }
        }

        private void saveSetting()
        {
            File.WriteAllText(Application.StartupPath + @"\settingLongText",
                hsb難度.Value.ToString() + "," + cb目標語言.Text + "," +
                tb單字前飾字串.Text + "," + tb單字後飾字串.Text + "," + tb註釋前飾字串.Text + ","
                + tb註釋中飾字串.Text + "," + tb註釋中飾字串在註釋中的位置.Text + "," + tb註釋後飾字串.Text + "," +
                tb分頁字串.Text + "," + tb相隔幾個單字插入分頁字串.Text + "," + tb標頭末行辨識.Text + "," + tb結尾首行辨識.Text);
        }

        private void FormLongText_Load(object sender, EventArgs e)
        {
            loadSetting();
            lb難度.Text = hsb難度.Value.ToString();
        }

        private void btn匯至網站_Click(object sender, EventArgs e)
        {
            blogInfo newBlogPost = default(blogInfo);

            ICL = (IgetCatList)XmlRpcProxyGen.Create(typeof(IgetCatList));
            XRCP = (XmlRpcClientProtocol)ICL;

            XRCP.Url = tb網址.Text;

            string result = null;
            result = "";

            string[] strArrFilePaths = Directory.GetFiles(tb已加值文目錄.Text);

            foreach (string strFilePath in strArrFilePaths)
            {
                newBlogPost.title = Path.GetFileNameWithoutExtension(strFilePath);
                newBlogPost.description = File.ReadAllText(strFilePath, Encoding.Default);

                try
                {
                    result = ICL.NewPage(1, tb帳號.Text, tb密碼.Text, newBlogPost, 1);
                    MessageBox.Show("Posted to Blog successfullly! Post ID : " + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FormLongText_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveSetting();
        }

        private void hsb難度_Scroll(object sender, ScrollEventArgs e)
        {
            lb難度.Text = hsb難度.Value.ToString();
        }
    }
}
