namespace 一切語言藏
{
    partial class FormGeneral
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
            this.components = new System.ComponentModel.Container();
            this.lbWord = new System.Windows.Forms.Label();
            this.lbChinese = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lbWord
            // 
            this.lbWord.AutoSize = true;
            this.lbWord.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbWord.Location = new System.Drawing.Point(0, 2);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new System.Drawing.Size(77, 32);
            this.lbWord.TabIndex = 0;
            this.lbWord.Text = "word";
            // 
            // lbChinese
            // 
            this.lbChinese.AutoSize = true;
            this.lbChinese.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbChinese.Location = new System.Drawing.Point(0, 38);
            this.lbChinese.Name = "lbChinese";
            this.lbChinese.Size = new System.Drawing.Size(140, 32);
            this.lbChinese.TabIndex = 1;
            this.lbChinese.Text = "translation";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-30, -30);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(1, 1);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1, 1);
            this.webBrowser1.TabIndex = 2;
            // 
            // FormGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 72);
            this.Controls.Add(this.lbChinese);
            this.Controls.Add(this.lbWord);
            this.Controls.Add(this.webBrowser1);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormGeneral";
            this.Text = "[Word Card] You can asjust the size of this window";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormGeneral_Load);
            this.Move += new System.EventHandler(this.FormGeneral_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbWord;
        public System.Windows.Forms.Label lbChinese;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}