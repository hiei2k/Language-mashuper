using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetSpeech;

namespace 一切語言藏
{
    public partial class FormGeneral : Form
    {
        public SpVoice objSpeech;//TTS發音物件
        public Dictionary<string, string> dict = new Dictionary<string, string>();
        //用來接收LoadDoc所傳來的字典，即是要預習的單字
        string[,] Dict;//簡單的字串陣列儲存要預習的單字，陣列才能用index來存取，方能為timer所用
        int DictIndex = 0;//就是Dict陣列的index啦，每次timer發動就遞增
        int RepeatedTimes = 0;

        public FormGeneral()
        {
            InitializeComponent();
        }

        private void FormGeneral_Load(object sender, EventArgs e)
        {   //把傳進來的字典放入Dict陣列中
            //objSpeech = new SpVoice();
            Dict = new string[dict.Count,2];//宣告正確大小的陣列

            //一個個放進去
            int dictCount = 0;
            foreach (KeyValuePair<string, string> item in dict)
            {
                Dict[dictCount, 0] = item.Key;
                Dict[dictCount, 1] = item.Value;
                dictCount++;
            }

            if (LoadDoc.fontGeneralWord != null) lbWord.Font = LoadDoc.fontGeneralWord;
            if (LoadDoc.fontGeneralExplain != null) lbChinese.Font = LoadDoc.fontGeneralExplain;
            if (LoadDoc.blPlayCardIsVerticle == true)
            {
                lbChinese.Top = lbWord.Top + lbWord.Height;
                lbChinese.Left = lbWord.Left;
            }
            else 
            {
                lbChinese.Top = lbWord.Top;
                lbChinese.Left = lbWord.Left + lbWord.Width + 5;
            }

            lbWord.ForeColor = LoadDoc.colorGeneralWord;
            lbChinese.ForeColor = LoadDoc.colorGeneralExplain;
            lbWord.BackColor = lbChinese.BackColor = this.BackColor = LoadDoc.colorGeneralBackGround;

            timer1.Interval = LoadDoc.intPlayCardInterval * 1000;

            if (!LoadDoc.IsPlayCardUsed)
            {
                LoadDoc.IsPlayCardUsed = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //照Dict陣列，把單字一個個唸出來
            try
            {
                lbWord.Text = Dict[DictIndex, 0];
                lbChinese.Text = Dict[DictIndex, 1].Replace("\\n", "\n");

                if (LoadDoc.blPlayCardIsVerticle == false) lbChinese.Left = lbWord.Left + lbWord.Width + 5;

                objSpeech.Speak(Dict[DictIndex, 0], SpeechVoiceSpeakFlags.SVSFlagsAsync);
                if (++RepeatedTimes >= LoadDoc.intPlayCardRepeatTime)
                {
                    RepeatedTimes = 0;
                    if (++DictIndex >= dict.Count) DictIndex = 0;//全唸完就重唸
                }
            }
            catch (Exception ex) { }
        }

        private void FormGeneral_Move(object sender, EventArgs e)
        {
            if (this.Top < 0) this.Top = -4;
        }
    }
}
