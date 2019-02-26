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
using System.Web;
using 一切語言藏;
using PanGu;

namespace 一切語言藏
{
    class MixTran
    {
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

        public string str全文 = null;
        public int int難度;
        public int int進度百分比 = 0;
        public string str狀態 = "尋找難字並翻譯";//下一個狀態是[產生加值文章]
        public string str母語 = "German";
        
        public string str單字前飾字串 = null;
        public string str單字後飾字串 = null;
        public string str註釋前飾字串 = null;
        public string str註釋後飾字串 = null;
        public string str註釋中飾字串 = null;
        public int int註釋中飾字串在註釋中的位置;

        public string str分頁字串;
        public int int相隔幾個單字插入分頁字串;

        int int已查單字 = 0;
        int int當前位址;
        string str單字 = null;
        int str單字長度;
        string[] strArr註釋值群;
        string str註釋 = null;
        string str音標 = null;

        public MixTran(string 全文, int 難度, string 母語, 
            string 單字前飾字串, string 單字後飾字串, string 註釋前飾字串, string 註釋後飾字串, string 註釋中飾字串,
            int 註釋中飾字串在註釋中的位置)
        {
            str全文 = 全文;
            int難度 = 難度;
            str母語 = 母語;
            str單字前飾字串 = 單字前飾字串;
            str單字後飾字串 = 單字後飾字串;
            str註釋前飾字串 = 註釋前飾字串;
            str註釋後飾字串 = 註釋後飾字串;
            str註釋中飾字串 = 註釋中飾字串;
            int註釋中飾字串在註釋中的位置 = 註釋中飾字串在註釋中的位置;

            #region 找難字、找翻譯、語文加值
            odc字典連線 = new System.Data.OleDb.OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\EN_" + str母語 + ".mdb");

            odc詞頻典連線 = new System.Data.OleDb.OleDbConnection(
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\WordFrequency.mdb");

            Dict各單字之雙語對照.Clear();
            //1.建立文件清單，2.將所載入之文件加到清單中，3.再將清單丟給詞頻物件分析其詞頻
            Docs = new List<WordFrequencyCounter.Document>();//建立文件清單
            Docs.Add(new WordFrequencyCounter.Document(str全文, false, strArr忽略字));//將所載入之文件加到清單中
            wordFrequency = new WordFrequencyCounter.WordFrequency(Docs);//將清單丟給詞頻物件分析其詞頻

            var segment = new Segment();
            var Arr詞語 = segment.DoSegment(str全文);

            odc詞頻典連線.Open();
            odc字典連線.Open();
            odCmd查字典 = odc字典連線.CreateCommand();//用來查單字解釋
            odCmd查詞頻典 = odc詞頻典連線.CreateCommand();//用來查詞頻

            #region 尋找並翻譯難字，結果儲存於 Dict各單字之雙語對照
            //將文章中的每個單字，查出其中文解釋，以及其語料詞頻排行
            //str調整中單字原形：一個字串配對一個數字，即單字配對其文件詞頻
            //str文中單字變化形.Key：單字；str文中單字變化形.Value：詞頻
            string str調整中單字原形 = null;//驗證過程中，用來儲存改來改去的字
            string str文中單字變化形 = null;//驗證過程中，用來儲存原本的字(可能為變化形)
            string[] str英文註釋分隔符 = {", ", "; ", ",", ";"};//注意較長的要放前面

            foreach (var 詞語 in Arr詞語)
            {
                Application.DoEvents();
                try
                {
                    odCmd查字典.CommandText = "SELECT [解釋] FROM [DICT] where [單字] = '" + 詞語 + "'";
                    oddr查字典 = odCmd查字典.ExecuteReader();

                    if (oddr查字典.Read())
                    {
                        string str解釋 = oddr查字典["解釋"].ToString();
                        foreach (var str個別分隔符 in str英文註釋分隔符)
                        {
                            str解釋 = str解釋.Replace(str個別分隔符, "｜");
                        }

                        string[] strArr解釋們 = str解釋.Split('｜');
                        string str篩選後解釋 = "";
                        foreach (var str個別解釋 in strArr解釋們)
                        {
                            odCmd查詞頻典.CommandText = "SELECT [識別碼] FROM [15000Frequency] where [word] = '" + str個別解釋 + "'";
                            oddr查詞頻典 = odCmd查詞頻典.ExecuteReader();
                            //hSBDegree.Value：難度，該數字與每個單字語料詞頻的排名比較，是故越大則越難（越罕見）
                            //識別碼是詞頻典中之PK，即每個單字語料詞頻的排名
                            if ((oddr查詞頻典.Read() && Int32.Parse(oddr查詞頻典["識別碼"].ToString()) >= int難度) || !oddr查詞頻典.HasRows)
                                str篩選後解釋 += str個別解釋 + ",";
                        }

                        Dict各單字之雙語對照.Add(詞語.ToString(), str篩選後解釋/* + "||||" + oddr查字典["音標"]*/);
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

                int已查單字++;
            }
            odc詞頻典連線.Close();
            #endregion

            //先將未加值的原始文章中的特殊符號編碼為HTML中的對映標籤
            //也在斷行符號之前加上<br>，以讓維持原有格式
            str全文 = HttpUtility.HtmlEncode("   " + str全文 + "   ").
                Replace("\n", "<br>\n");

            #region 產生語言加值文章

            //Dict中儲有該文章中的所有難字，每個單字都要在其左右加上"{[("，例："document" -> "{[(document)]}"
            foreach (KeyValuePair<string, string> item in Dict各單字之雙語對照)
            {
                Application.DoEvents();
                str單字長度 = item.Key.Length;
                str單字 = item.Key;

                //將該難字在文章中從頭到尾找一次，並一一在文中找到的難字兩旁加上{[()]}
                //確切的方法：IndexOf的startIndex參數意思係為[要從哪裡開始找]，是故每找完一個單字，就從該單字所出現的位置的結尾開始找
                //例：I am the king of the world，找完king字後，就繼續從of the world第一個字元(o)的位置開始找
                int當前位址 = 0;
                while (int當前位址 != -1 && int當前位址 < str全文.Length)
                {
                    int當前位址 = str全文.IndexOf(str單字, int當前位址, StringComparison.Ordinal);//找尋單字的位置，若找不到，則為-1
                    if (int當前位址 != -1)
                    {
                        //單字的前、後一個字元皆非英文字母
                        if (!char.IsLetter(str全文, int當前位址 - 1) && !char.IsLetter(str全文, int當前位址 + str單字長度))
                        {
                            //若單字後沒(尚未)接著)]}，則標註之
                            if (str全文.IndexOf(")]}", int當前位址 + str單字長度 - 1, 3, StringComparison.Ordinal) == -1)
                                wordMark();
                        }
                        int當前位址 += (str單字長度 + 7);//{[()]}與單字分隔符(如空白)，共7個
                    }
                }
            }

            //為單字加上註解
            foreach (KeyValuePair<string, string> item in Dict各單字之雙語對照)
            {
                Application.DoEvents();
                str單字長度 = item.Key.Length;
                str單字 = item.Key;
                string[] separators = { "||||" };//分隔解釋和音標的字串
                strArr註釋值群 = item.Value.Split(separators, StringSplitOptions.None);
                str註釋 = strArr註釋值群[0];
                str音標 = strArr註釋值群[1];

                int當前位址 = 0;
                //while (int當前位址 <= str全文.Length && int當前位址 != -1)
                //將標上{[()]}的難字在文章中從頭到尾找一次，
                //並一一將之以加上相關註解的字串取代(wordDecorate)
                while(int當前位址 != -1 && int當前位址 < str全文.Length)
                {
                    int當前位址 = str全文.IndexOf("{[(" + str單字 + ")]}", int當前位址, StringComparison.Ordinal);
                    wordDecorate();
                }
            }

            #endregion

            #endregion 找難字、找翻譯、語文加值

        }

        
        
        //為難字加值，如標上解釋和相關標誌
        private void wordDecorate()
        {
            if (int當前位址 != -1)
            {
                string str修飾後的單字與註釋 =
                    str單字前飾字串 + str單字 + str單字後飾字串 + str音標 + str註釋前飾字串 +
                    str註釋.Insert((int註釋中飾字串在註釋中的位置 > str註釋.Length - 1) ? str註釋.Length : int註釋中飾字串在註釋中的位置, str註釋中飾字串) +
                    str註釋後飾字串;
                str修飾後的單字與註釋 = str修飾後的單字與註釋.Replace("{[(index)]}", int當前位址.ToString());

                str全文 = str全文.Remove(int當前位址, str單字長度 + 6).Insert(int當前位址, str修飾後的單字與註釋);

                int當前位址 += str修飾後的單字與註釋.Length + 1;
            }
        }

        //為單字兩旁加上{[(和)]}
        private void wordMark()
        {
            if (int當前位址 != -1)
            {
                str全文 = str全文.Remove(int當前位址, str單字長度).Insert(int當前位址, "{[(" + str單字 + ")]}");
            }
        }

    }
}
