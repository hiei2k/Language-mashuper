namespace 一切語言藏
{
    partial class FormGeneralSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbWord = new System.Windows.Forms.Label();
            this.lbExplain = new System.Windows.Forms.Label();
            this.btnEngFontSetting = new System.Windows.Forms.Button();
            this.btnChineseFontSetting = new System.Windows.Forms.Button();
            this.fontDialogEng = new System.Windows.Forms.FontDialog();
            this.fontDialogChinese = new System.Windows.Forms.FontDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnHorizontal = new System.Windows.Forms.RadioButton();
            this.rbtnVerticle = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownRepeatTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lbWord
            // 
            this.lbWord.AutoSize = true;
            this.lbWord.BackColor = System.Drawing.SystemColors.Control;
            this.lbWord.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWord.Location = new System.Drawing.Point(145, 3);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new System.Drawing.Size(77, 32);
            this.lbWord.TabIndex = 0;
            this.lbWord.Text = "word";
            // 
            // lbExplain
            // 
            this.lbExplain.AutoSize = true;
            this.lbExplain.BackColor = System.Drawing.SystemColors.Control;
            this.lbExplain.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbExplain.Location = new System.Drawing.Point(145, 40);
            this.lbExplain.Name = "lbExplain";
            this.lbExplain.Size = new System.Drawing.Size(140, 32);
            this.lbExplain.TabIndex = 1;
            this.lbExplain.Text = "translation";
            // 
            // btnEngFontSetting
            // 
            this.btnEngFontSetting.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEngFontSetting.Location = new System.Drawing.Point(12, 11);
            this.btnEngFontSetting.Name = "btnEngFontSetting";
            this.btnEngFontSetting.Size = new System.Drawing.Size(127, 23);
            this.btnEngFontSetting.TabIndex = 2;
            this.btnEngFontSetting.Text = "English font/size";
            this.btnEngFontSetting.UseVisualStyleBackColor = true;
            this.btnEngFontSetting.Click += new System.EventHandler(this.btnEngFontSetting_Click);
            // 
            // btnChineseFontSetting
            // 
            this.btnChineseFontSetting.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChineseFontSetting.Location = new System.Drawing.Point(12, 43);
            this.btnChineseFontSetting.Name = "btnChineseFontSetting";
            this.btnChineseFontSetting.Size = new System.Drawing.Size(127, 23);
            this.btnChineseFontSetting.TabIndex = 3;
            this.btnChineseFontSetting.Text = "Translate font/size";
            this.btnChineseFontSetting.UseVisualStyleBackColor = true;
            this.btnChineseFontSetting.Click += new System.EventHandler(this.btnChineseFontSetting_Click);
            // 
            // fontDialogEng
            // 
            this.fontDialogEng.ShowColor = true;
            this.fontDialogEng.ShowHelp = true;
            // 
            // fontDialogChinese
            // 
            this.fontDialogChinese.ShowColor = true;
            this.fontDialogChinese.ShowHelp = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtnHorizontal);
            this.groupBox1.Controls.Add(this.rbtnVerticle);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(182, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Right and Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Up and Down";
            // 
            // rbtnHorizontal
            // 
            this.rbtnHorizontal.AutoSize = true;
            this.rbtnHorizontal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnHorizontal.Location = new System.Drawing.Point(186, 57);
            this.rbtnHorizontal.Name = "rbtnHorizontal";
            this.rbtnHorizontal.Size = new System.Drawing.Size(139, 20);
            this.rbtnHorizontal.TabIndex = 7;
            this.rbtnHorizontal.TabStop = true;
            this.rbtnHorizontal.Text = "word    translation";
            this.rbtnHorizontal.UseVisualStyleBackColor = true;
            this.rbtnHorizontal.CheckedChanged += new System.EventHandler(this.rbtnHorizontal_CheckedChanged);
            // 
            // rbtnVerticle
            // 
            this.rbtnVerticle.AutoSize = true;
            this.rbtnVerticle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnVerticle.Location = new System.Drawing.Point(20, 49);
            this.rbtnVerticle.Name = "rbtnVerticle";
            this.rbtnVerticle.Size = new System.Drawing.Size(91, 36);
            this.rbtnVerticle.TabIndex = 6;
            this.rbtnVerticle.TabStop = true;
            this.rbtnVerticle.Text = "word\r\ntranslation";
            this.rbtnVerticle.UseVisualStyleBackColor = true;
            this.rbtnVerticle.CheckedChanged += new System.EventHandler(this.rbtnVerticle_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownRepeatTime);
            this.groupBox2.Controls.Add(this.numericUpDownInterval);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 76);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interval time and repeat times";
            // 
            // numericUpDownRepeatTime
            // 
            this.numericUpDownRepeatTime.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDownRepeatTime.Location = new System.Drawing.Point(124, 28);
            this.numericUpDownRepeatTime.Name = "numericUpDownRepeatTime";
            this.numericUpDownRepeatTime.Size = new System.Drawing.Size(50, 33);
            this.numericUpDownRepeatTime.TabIndex = 1;
            this.numericUpDownRepeatTime.ValueChanged += new System.EventHandler(this.numericUpDownRepeatTime_ValueChanged);
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDownInterval.Location = new System.Drawing.Point(249, 28);
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(50, 33);
            this.numericUpDownInterval.TabIndex = 0;
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownInterval_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(11, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Every word repeat　　　　times every　　　　seconds";
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBackGroundColor.Location = new System.Drawing.Point(12, 269);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.Size = new System.Drawing.Size(127, 26);
            this.btnBackGroundColor.TabIndex = 8;
            this.btnBackGroundColor.Text = "Background color";
            this.btnBackGroundColor.UseVisualStyleBackColor = true;
            this.btnBackGroundColor.Click += new System.EventHandler(this.btnBackGroundColor_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(314, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Location = new System.Drawing.Point(262, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(46, 33);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormGeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 307);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBackGroundColor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChineseFontSetting);
            this.Controls.Add(this.btnEngFontSetting);
            this.Controls.Add(this.lbExplain);
            this.Controls.Add(this.lbWord);
            this.Name = "FormGeneralSetting";
            this.Text = "Word Card Style Config";
            this.Load += new System.EventHandler(this.FormGeneralSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbWord;
        private System.Windows.Forms.Label lbExplain;
        private System.Windows.Forms.Button btnEngFontSetting;
        private System.Windows.Forms.Button btnChineseFontSetting;
        private System.Windows.Forms.FontDialog fontDialogEng;
        private System.Windows.Forms.FontDialog fontDialogChinese;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnHorizontal;
        private System.Windows.Forms.RadioButton rbtnVerticle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatTime;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}