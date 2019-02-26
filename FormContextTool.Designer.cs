namespace 一切語言藏
{
    partial class FormContextTool
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
            this.rtbDoc = new System.Windows.Forms.RichTextBox();
            this.btnSpeech = new System.Windows.Forms.Button();
            this.RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.翻譯所選ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.朗讀所選VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪下CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.複製CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼上PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全選AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTransSelected = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cbMotherLanguage = new System.Windows.Forms.ComboBox();
            this.RightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbDoc
            // 
            this.rtbDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDoc.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbDoc.Location = new System.Drawing.Point(13, 40);
            this.rtbDoc.Name = "rtbDoc";
            this.rtbDoc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbDoc.Size = new System.Drawing.Size(991, 682);
            this.rtbDoc.TabIndex = 0;
            this.rtbDoc.Text = "";
            this.rtbDoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbDoc_MouseDown);
            // 
            // btnSpeech
            // 
            this.btnSpeech.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSpeech.Location = new System.Drawing.Point(12, 7);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.Size = new System.Drawing.Size(194, 29);
            this.btnSpeech.TabIndex = 1;
            this.btnSpeech.Text = "Speak the selected words(&V)";
            this.btnSpeech.UseVisualStyleBackColor = true;
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click);
            // 
            // RightMenu
            // 
            this.RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.翻譯所選ToolStripMenuItem,
            this.朗讀所選VToolStripMenuItem,
            this.剪下CToolStripMenuItem,
            this.複製CToolStripMenuItem,
            this.貼上PToolStripMenuItem,
            this.全選AToolStripMenuItem});
            this.RightMenu.Name = "contextMenuStrip1";
            this.RightMenu.Size = new System.Drawing.Size(131, 136);
            // 
            // 翻譯所選ToolStripMenuItem
            // 
            this.翻譯所選ToolStripMenuItem.Name = "翻譯所選ToolStripMenuItem";
            this.翻譯所選ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.翻譯所選ToolStripMenuItem.Text = "Translate(&R)";
            this.翻譯所選ToolStripMenuItem.Click += new System.EventHandler(this.翻譯所選ToolStripMenuItem_Click);
            // 
            // 朗讀所選VToolStripMenuItem
            // 
            this.朗讀所選VToolStripMenuItem.Name = "朗讀所選VToolStripMenuItem";
            this.朗讀所選VToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.朗讀所選VToolStripMenuItem.Text = "Speed(&V)";
            this.朗讀所選VToolStripMenuItem.Click += new System.EventHandler(this.朗讀所選VToolStripMenuItem_Click);
            // 
            // 剪下CToolStripMenuItem
            // 
            this.剪下CToolStripMenuItem.Name = "剪下CToolStripMenuItem";
            this.剪下CToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.剪下CToolStripMenuItem.Text = "Cut(&T)";
            this.剪下CToolStripMenuItem.Click += new System.EventHandler(this.剪下CToolStripMenuItem_Click);
            // 
            // 複製CToolStripMenuItem
            // 
            this.複製CToolStripMenuItem.Name = "複製CToolStripMenuItem";
            this.複製CToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.複製CToolStripMenuItem.Text = "Copy(&C)";
            this.複製CToolStripMenuItem.Click += new System.EventHandler(this.複製CToolStripMenuItem_Click);
            // 
            // 貼上PToolStripMenuItem
            // 
            this.貼上PToolStripMenuItem.Name = "貼上PToolStripMenuItem";
            this.貼上PToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.貼上PToolStripMenuItem.Text = "Paste(&P)";
            this.貼上PToolStripMenuItem.Click += new System.EventHandler(this.貼上PToolStripMenuItem_Click);
            // 
            // 全選AToolStripMenuItem
            // 
            this.全選AToolStripMenuItem.Name = "全選AToolStripMenuItem";
            this.全選AToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.全選AToolStripMenuItem.Text = "Select All(&A)";
            this.全選AToolStripMenuItem.Click += new System.EventHandler(this.全選AToolStripMenuItem_Click);
            // 
            // btnTransSelected
            // 
            this.btnTransSelected.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTransSelected.Location = new System.Drawing.Point(212, 7);
            this.btnTransSelected.Name = "btnTransSelected";
            this.btnTransSelected.Size = new System.Drawing.Size(212, 29);
            this.btnTransSelected.TabIndex = 44;
            this.btnTransSelected.Text = "Translate the selected words(&R)";
            this.btnTransSelected.UseVisualStyleBackColor = true;
            this.btnTransSelected.Click += new System.EventHandler(this.btnTransSelected_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(430, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 16);
            this.label16.TabIndex = 54;
            this.label16.Text = "Translate to: ";
            // 
            // cbMotherLanguage
            // 
            this.cbMotherLanguage.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbMotherLanguage.FormattingEnabled = true;
            this.cbMotherLanguage.Items.AddRange(new object[] {
            "Croatian",
            "Czech",
            "Danish",
            "Dutch",
            "Esperanto",
            "Estonian",
            "Finnish",
            "French",
            "German",
            "Greek",
            "Hebrew",
            "Hungarian",
            "Icelandic",
            "Indonesian",
            "Interlingua",
            "Japanese",
            "Marathi",
            "Polish",
            "Portuguese",
            "Romanian",
            "Russian",
            "Serbian",
            "Slovak",
            "Slovene",
            "Spanish",
            "Swedish",
            "Telugu",
            "Ukrainian",
            "Vietnamese",
            "Volapuk",
            "Welsh"});
            this.cbMotherLanguage.Location = new System.Drawing.Point(519, 10);
            this.cbMotherLanguage.Name = "cbMotherLanguage";
            this.cbMotherLanguage.Size = new System.Drawing.Size(180, 24);
            this.cbMotherLanguage.TabIndex = 53;
            this.cbMotherLanguage.Text = "German";
            // 
            // FormContextTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbMotherLanguage);
            this.Controls.Add(this.btnSpeech);
            this.Controls.Add(this.rtbDoc);
            this.Controls.Add(this.btnTransSelected);
            this.Name = "FormContextTool";
            this.Text = "Assistant Reading";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormContextTool_FormClosing);
            this.Load += new System.EventHandler(this.FormContextTool_Load);
            this.RightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbDoc;
        private System.Windows.Forms.Button btnSpeech;
        private System.Windows.Forms.ContextMenuStrip RightMenu;
        private System.Windows.Forms.ToolStripMenuItem 剪下CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 複製CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼上PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全選AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 朗讀所選VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 翻譯所選ToolStripMenuItem;
        private System.Windows.Forms.Button btnTransSelected;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbMotherLanguage;

    }
}