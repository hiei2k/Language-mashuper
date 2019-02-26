using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 一切語言藏
{
    public partial class FormGeneralSetting : Form
    {
        public FormGeneralSetting()
        {
            InitializeComponent();
        }

        private void btnEngFontSetting_Click(object sender, EventArgs e)
        {
            fontDialogEng.ShowDialog();
            LoadDoc.fontGeneralWord = lbWord.Font = (Font)fontDialogEng.Font.Clone();
            LoadDoc.colorGeneralWord = lbWord.ForeColor = fontDialogEng.Color;
            lbExplain.Top = lbWord.Top + lbWord.Height;
        }

        private void btnChineseFontSetting_Click(object sender, EventArgs e)
        {
            fontDialogChinese.ShowDialog();
            LoadDoc.fontGeneralExplain = lbExplain.Font = (Font)fontDialogChinese.Font.Clone();
            LoadDoc.colorGeneralExplain = lbExplain.ForeColor = fontDialogChinese.Color;
        }

        private void FormGeneralSetting_Load(object sender, EventArgs e)
        {
            if (LoadDoc.fontGeneralWord != null) lbWord.Font = LoadDoc.fontGeneralWord;
            lbWord.ForeColor = LoadDoc.colorGeneralWord;
            if (LoadDoc.fontGeneralExplain != null) lbExplain.Font = LoadDoc.fontGeneralExplain;
            lbExplain.ForeColor = LoadDoc.colorGeneralExplain;

            fontDialogEng.Font = lbWord.Font;
            fontDialogEng.Color = lbWord.ForeColor;
            fontDialogChinese.Font = lbExplain.Font;
            fontDialogChinese.Color = lbExplain.ForeColor;
            rbtnVerticle.Checked = LoadDoc.blPlayCardIsVerticle;
            rbtnHorizontal.Checked = !LoadDoc.blPlayCardIsVerticle;
            numericUpDownInterval.Value = LoadDoc.intPlayCardInterval;
            numericUpDownRepeatTime.Value = LoadDoc.intPlayCardRepeatTime;
            lbExplain.BackColor = lbWord.BackColor = this.BackColor = colorDialog1.Color = LoadDoc.colorGeneralBackGround;
            
        }

        private void rbtnVerticle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnVerticle.Checked == true)
            {
                lbExplain.Left = lbWord.Left;
                lbExplain.Top = lbWord.Top + lbWord.Height;
            }
        }

        private void rbtnHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHorizontal.Checked == true)
            {
                lbExplain.Left = lbWord.Left + lbWord.Width + 5;
                lbExplain.Top = lbWord.Top;
            }
        }

        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDownRepeatTime_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBackGroundColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            lbExplain.BackColor = lbWord.BackColor = this.BackColor = colorDialog1.Color;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnVerticle.Checked == true)
            { LoadDoc.blPlayCardIsVerticle = true; }
            else
            { LoadDoc.blPlayCardIsVerticle = false; }

            LoadDoc.intPlayCardInterval = (int)numericUpDownInterval.Value;
            LoadDoc.intPlayCardRepeatTime = (int)numericUpDownRepeatTime.Value;
            LoadDoc.colorGeneralBackGround = colorDialog1.Color;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
