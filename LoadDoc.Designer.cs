namespace 一切語言藏
{
    partial class LoadDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDoc));
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoadDoc = new System.Windows.Forms.Button();
            this.DGVResult = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbDegree = new System.Windows.Forms.Label();
            this.btnContext = new System.Windows.Forms.Button();
            this.tbDoc = new System.Windows.Forms.RichTextBox();
            this.RightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.剪下CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.複製CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.貼上PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全選AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.朗讀所選VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSpeech = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTotalWordNum = new System.Windows.Forms.Label();
            this.lbDoneWordNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn長文模式 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnReadSimulate = new System.Windows.Forms.Button();
            this.btnAttention = new System.Windows.Forms.Button();
            this.btnMassInput = new System.Windows.Forms.Button();
            this.cb目標語言 = new System.Windows.Forms.ComboBox();
            this.hsb難度 = new System.Windows.Forms.HScrollBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb註釋無詞性 = new System.Windows.Forms.CheckBox();
            this.cb註釋完整性 = new System.Windows.Forms.CheckBox();
            this.tb文章後飾字串 = new System.Windows.Forms.TextBox();
            this.tb文章前飾字串 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tb相隔幾個單字插入分頁字串 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tb分頁字串 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb註釋中飾字串在註釋中的位置 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb註釋中飾字串 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb註釋後飾字串 = new System.Windows.Forms.TextBox();
            this.tb註釋前飾字串 = new System.Windows.Forms.TextBox();
            this.tb單字後飾字串 = new System.Windows.Forms.TextBox();
            this.tb單字前飾字串 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chinese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVResult)).BeginInit();
            this.RightMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(680, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Search Result:";
            // 
            // btnLoadDoc
            // 
            this.btnLoadDoc.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLoadDoc.Location = new System.Drawing.Point(371, 424);
            this.btnLoadDoc.Name = "btnLoadDoc";
            this.btnLoadDoc.Size = new System.Drawing.Size(241, 24);
            this.btnLoadDoc.TabIndex = 12;
            this.btnLoadDoc.Text = "Find and translate the hard words";
            this.btnLoadDoc.UseVisualStyleBackColor = true;
            this.btnLoadDoc.Click += new System.EventHandler(this.btnLoadDoc_Click);
            // 
            // DGVResult
            // 
            this.DGVResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.word,
            this.Chinese,
            this.Degree,
            this.frequency});
            this.DGVResult.Location = new System.Drawing.Point(680, 33);
            this.DGVResult.Name = "DGVResult";
            this.DGVResult.RowTemplate.Height = 24;
            this.DGVResult.Size = new System.Drawing.Size(448, 354);
            this.DGVResult.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbDegree
            // 
            this.lbDegree.AutoSize = true;
            this.lbDegree.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDegree.ForeColor = System.Drawing.Color.Blue;
            this.lbDegree.Location = new System.Drawing.Point(213, 367);
            this.lbDegree.Name = "lbDegree";
            this.lbDegree.Size = new System.Drawing.Size(45, 19);
            this.lbDegree.TabIndex = 22;
            this.lbDegree.Text = "3000";
            // 
            // btnContext
            // 
            this.btnContext.Font = new System.Drawing.Font("新細明體", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnContext.Location = new System.Drawing.Point(1090, 23);
            this.btnContext.Name = "btnContext";
            this.btnContext.Size = new System.Drawing.Size(29, 167);
            this.btnContext.TabIndex = 25;
            this.btnContext.Text = "進行語文加值";
            this.toolTip1.SetToolTip(this.btnContext, "Mark your mother language beside the hard words.");
            this.btnContext.UseVisualStyleBackColor = true;
            this.btnContext.Click += new System.EventHandler(this.btnContext_Click);
            // 
            // tbDoc
            // 
            this.tbDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDoc.ContextMenuStrip = this.RightMenu;
            this.tbDoc.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDoc.Location = new System.Drawing.Point(6, 21);
            this.tbDoc.Name = "tbDoc";
            this.tbDoc.Size = new System.Drawing.Size(659, 286);
            this.tbDoc.TabIndex = 28;
            this.tbDoc.Text = resources.GetString("tbDoc.Text");
            this.tbDoc.Click += new System.EventHandler(this.tbDoc_Click);
            this.tbDoc.Leave += new System.EventHandler(this.tbDoc_Leave);
            this.tbDoc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbDoc_MouseDown);
            // 
            // RightMenu
            // 
            this.RightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.剪下CToolStripMenuItem,
            this.複製CToolStripMenuItem,
            this.貼上PToolStripMenuItem,
            this.全選AToolStripMenuItem,
            this.朗讀所選VToolStripMenuItem});
            this.RightMenu.Name = "contextMenuStrip1";
            this.RightMenu.Size = new System.Drawing.Size(158, 114);
            // 
            // 剪下CToolStripMenuItem
            // 
            this.剪下CToolStripMenuItem.Name = "剪下CToolStripMenuItem";
            this.剪下CToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.剪下CToolStripMenuItem.Text = "Cut(&T)";
            this.剪下CToolStripMenuItem.Click += new System.EventHandler(this.剪下CToolStripMenuItem_Click);
            // 
            // 複製CToolStripMenuItem
            // 
            this.複製CToolStripMenuItem.Name = "複製CToolStripMenuItem";
            this.複製CToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.複製CToolStripMenuItem.Text = "Copy(&C)";
            this.複製CToolStripMenuItem.Click += new System.EventHandler(this.複製CToolStripMenuItem_Click);
            // 
            // 貼上PToolStripMenuItem
            // 
            this.貼上PToolStripMenuItem.Name = "貼上PToolStripMenuItem";
            this.貼上PToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.貼上PToolStripMenuItem.Text = "Paste(&P)";
            this.貼上PToolStripMenuItem.Click += new System.EventHandler(this.貼上PToolStripMenuItem_Click);
            // 
            // 全選AToolStripMenuItem
            // 
            this.全選AToolStripMenuItem.Name = "全選AToolStripMenuItem";
            this.全選AToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.全選AToolStripMenuItem.Text = "Select All(&A)";
            this.全選AToolStripMenuItem.Click += new System.EventHandler(this.全選AToolStripMenuItem_Click);
            // 
            // 朗讀所選VToolStripMenuItem
            // 
            this.朗讀所選VToolStripMenuItem.Name = "朗讀所選VToolStripMenuItem";
            this.朗讀所選VToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.朗讀所選VToolStripMenuItem.Text = "Speed(&V)";
            this.朗讀所選VToolStripMenuItem.Click += new System.EventHandler(this.朗讀所選VToolStripMenuItem_Click);
            // 
            // btnSpeech
            // 
            this.btnSpeech.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpeech.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSpeech.Location = new System.Drawing.Point(6, 310);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.Size = new System.Drawing.Size(195, 26);
            this.btnSpeech.TabIndex = 29;
            this.btnSpeech.Text = "Speak the selected words(&V)";
            this.btnSpeech.UseVisualStyleBackColor = true;
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 116);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(440, 23);
            this.progressBar.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTotalWordNum);
            this.panel1.Controls.Add(this.lbDoneWordNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Location = new System.Drawing.Point(680, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 144);
            this.panel1.TabIndex = 32;
            this.panel1.Visible = false;
            // 
            // lbTotalWordNum
            // 
            this.lbTotalWordNum.AutoSize = true;
            this.lbTotalWordNum.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbTotalWordNum.Location = new System.Drawing.Point(112, 44);
            this.lbTotalWordNum.Name = "lbTotalWordNum";
            this.lbTotalWordNum.Size = new System.Drawing.Size(47, 19);
            this.lbTotalWordNum.TabIndex = 34;
            this.lbTotalWordNum.Text = "Total";
            // 
            // lbDoneWordNum
            // 
            this.lbDoneWordNum.AutoSize = true;
            this.lbDoneWordNum.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbDoneWordNum.Location = new System.Drawing.Point(117, 83);
            this.lbDoneWordNum.Name = "lbDoneWordNum";
            this.lbDoneWordNum.Size = new System.Drawing.Size(42, 19);
            this.lbDoneWordNum.TabIndex = 33;
            this.lbDoneWordNum.Text = "Find";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 95);
            this.label1.TabIndex = 32;
            this.label1.Text = "Searching progress:\r\n\r\nTotal words:\r\n\r\nFinded words: \r\n";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btn長文模式);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.tbDoc);
            this.gb1.Controls.Add(this.btnSpeech);
            this.gb1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gb1.Location = new System.Drawing.Point(3, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(671, 346);
            this.gb1.TabIndex = 34;
            this.gb1.TabStop = false;
            this.gb1.Text = "　　The article I want to read.";
            // 
            // btn長文模式
            // 
            this.btn長文模式.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn長文模式.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn長文模式.Location = new System.Drawing.Point(470, 310);
            this.btn長文模式.Name = "btn長文模式";
            this.btn長文模式.Size = new System.Drawing.Size(195, 26);
            this.btn長文模式.TabIndex = 56;
            this.btn長文模式.Text = "長文模式";
            this.btn長文模式.UseVisualStyleBackColor = true;
            this.btn長文模式.Click += new System.EventHandler(this.btn長文模式_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(10, -4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 24);
            this.label3.TabIndex = 55;
            this.label3.Text = "1.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(264, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "words";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowHelp = true;
            // 
            // btnReadSimulate
            // 
            this.btnReadSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadSimulate.Enabled = false;
            this.btnReadSimulate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReadSimulate.Location = new System.Drawing.Point(1587, 169);
            this.btnReadSimulate.Name = "btnReadSimulate";
            this.btnReadSimulate.Size = new System.Drawing.Size(101, 25);
            this.btnReadSimulate.TabIndex = 44;
            this.btnReadSimulate.Text = "眼動模擬";
            this.btnReadSimulate.UseVisualStyleBackColor = true;
            this.btnReadSimulate.Visible = false;
            // 
            // btnAttention
            // 
            this.btnAttention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttention.Enabled = false;
            this.btnAttention.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAttention.Location = new System.Drawing.Point(1587, 200);
            this.btnAttention.Name = "btnAttention";
            this.btnAttention.Size = new System.Drawing.Size(101, 25);
            this.btnAttention.TabIndex = 46;
            this.btnAttention.Text = "注意力增強";
            this.btnAttention.UseVisualStyleBackColor = true;
            this.btnAttention.Visible = false;
            // 
            // btnMassInput
            // 
            this.btnMassInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMassInput.Enabled = false;
            this.btnMassInput.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMassInput.Location = new System.Drawing.Point(1587, 231);
            this.btnMassInput.Name = "btnMassInput";
            this.btnMassInput.Size = new System.Drawing.Size(101, 25);
            this.btnMassInput.TabIndex = 45;
            this.btnMassInput.Text = "全視野記憶";
            this.btnMassInput.UseVisualStyleBackColor = true;
            this.btnMassInput.Visible = false;
            // 
            // cb目標語言
            // 
            this.cb目標語言.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb目標語言.FormattingEnabled = true;
            this.cb目標語言.Items.AddRange(new object[] {
            "Chinese_traditional",
            "Chinese_simple",
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
            this.cb目標語言.Location = new System.Drawing.Point(138, 424);
            this.cb目標語言.Name = "cb目標語言";
            this.cb目標語言.Size = new System.Drawing.Size(180, 24);
            this.cb目標語言.TabIndex = 0;
            this.cb目標語言.Text = "German";
            // 
            // hsb難度
            // 
            this.hsb難度.Location = new System.Drawing.Point(9, 386);
            this.hsb難度.Maximum = 16000;
            this.hsb難度.Name = "hsb難度";
            this.hsb難度.Size = new System.Drawing.Size(659, 21);
            this.hsb難度.TabIndex = 50;
            this.hsb難度.Value = 3000;
            this.hsb難度.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hSBDegree_Scroll);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(36, 371);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 15);
            this.label15.TabIndex = 51;
            this.label15.Text = "How many words do I know?";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(31, 430);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 15);
            this.label16.TabIndex = 52;
            this.label16.Text = "mother language";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(5, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 24);
            this.label7.TabIndex = 56;
            this.label7.Text = "2.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(5, 423);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 24);
            this.label10.TabIndex = 57;
            this.label10.Text = "3.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(336, 424);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 24);
            this.label11.TabIndex = 58;
            this.label11.Text = "4.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(11, -3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 24);
            this.label12.TabIndex = 59;
            this.label12.Text = "5.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb註釋無詞性);
            this.groupBox1.Controls.Add(this.cb註釋完整性);
            this.groupBox1.Controls.Add(this.tb文章後飾字串);
            this.groupBox1.Controls.Add(this.tb文章前飾字串);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.tb相隔幾個單字插入分頁字串);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tb分頁字串);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.tb註釋中飾字串在註釋中的位置);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tb註釋中飾字串);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tb註釋後飾字串);
            this.groupBox1.Controls.Add(this.tb註釋前飾字串);
            this.groupBox1.Controls.Add(this.tb單字後飾字串);
            this.groupBox1.Controls.Add(this.tb單字前飾字串);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnContext);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(3, 463);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 207);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "       Learning Modes";
            // 
            // cb註釋無詞性
            // 
            this.cb註釋無詞性.AutoSize = true;
            this.cb註釋無詞性.Location = new System.Drawing.Point(977, 156);
            this.cb註釋無詞性.Name = "cb註釋無詞性";
            this.cb註釋無詞性.Size = new System.Drawing.Size(107, 20);
            this.cb註釋無詞性.TabIndex = 83;
            this.cb註釋無詞性.Text = "註釋無詞性";
            this.cb註釋無詞性.UseVisualStyleBackColor = true;
            // 
            // cb註釋完整性
            // 
            this.cb註釋完整性.AutoSize = true;
            this.cb註釋完整性.Location = new System.Drawing.Point(977, 130);
            this.cb註釋完整性.Name = "cb註釋完整性";
            this.cb註釋完整性.Size = new System.Drawing.Size(107, 20);
            this.cb註釋完整性.TabIndex = 82;
            this.cb註釋完整性.Text = "註釋完整性";
            this.cb註釋完整性.UseVisualStyleBackColor = true;
            // 
            // tb文章後飾字串
            // 
            this.tb文章後飾字串.Location = new System.Drawing.Point(647, 49);
            this.tb文章後飾字串.Name = "tb文章後飾字串";
            this.tb文章後飾字串.Size = new System.Drawing.Size(445, 27);
            this.tb文章後飾字串.TabIndex = 81;
            // 
            // tb文章前飾字串
            // 
            this.tb文章前飾字串.Location = new System.Drawing.Point(647, 21);
            this.tb文章前飾字串.Name = "tb文章前飾字串";
            this.tb文章前飾字串.Size = new System.Drawing.Size(445, 27);
            this.tb文章前飾字串.TabIndex = 80;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(533, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 16);
            this.label20.TabIndex = 79;
            this.label20.Text = "文章後飾字串：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(533, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 78;
            this.label21.Text = "文章前飾字串：";
            // 
            // tb相隔幾個單字插入分頁字串
            // 
            this.tb相隔幾個單字插入分頁字串.Location = new System.Drawing.Point(745, 130);
            this.tb相隔幾個單字插入分頁字串.Name = "tb相隔幾個單字插入分頁字串";
            this.tb相隔幾個單字插入分頁字串.Size = new System.Drawing.Size(77, 27);
            this.tb相隔幾個單字插入分頁字串.TabIndex = 77;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(533, 135);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(216, 16);
            this.label19.TabIndex = 76;
            this.label19.Text = "相隔幾個單字插入分頁字串？";
            // 
            // tb分頁字串
            // 
            this.tb分頁字串.Location = new System.Drawing.Point(615, 94);
            this.tb分頁字串.Multiline = true;
            this.tb分頁字串.Name = "tb分頁字串";
            this.tb分頁字串.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb分頁字串.Size = new System.Drawing.Size(469, 27);
            this.tb分頁字串.TabIndex = 75;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(533, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 16);
            this.label18.TabIndex = 74;
            this.label18.Text = "分頁字串：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(728, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(224, 27);
            this.textBox1.TabIndex = 73;
            this.textBox1.Text = "{[(index)]}";
            // 
            // tb註釋中飾字串在註釋中的位置
            // 
            this.tb註釋中飾字串在註釋中的位置.Location = new System.Drawing.Point(228, 135);
            this.tb註釋中飾字串在註釋中的位置.Name = "tb註釋中飾字串在註釋中的位置";
            this.tb註釋中飾字串在註釋中的位置.Size = new System.Drawing.Size(287, 27);
            this.tb註釋中飾字串在註釋中的位置.TabIndex = 72;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(533, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(200, 16);
            this.label17.TabIndex = 71;
            this.label17.Text = "索引號在各字串中的代號：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 16);
            this.label14.TabIndex = 70;
            this.label14.Text = "註釋中飾字串在註釋中的位置：";
            // 
            // tb註釋中飾字串
            // 
            this.tb註釋中飾字串.Location = new System.Drawing.Point(118, 107);
            this.tb註釋中飾字串.Name = "tb註釋中飾字串";
            this.tb註釋中飾字串.Size = new System.Drawing.Size(397, 27);
            this.tb註釋中飾字串.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "註釋中飾字串：";
            // 
            // tb註釋後飾字串
            // 
            this.tb註釋後飾字串.Location = new System.Drawing.Point(118, 163);
            this.tb註釋後飾字串.Name = "tb註釋後飾字串";
            this.tb註釋後飾字串.Size = new System.Drawing.Size(397, 27);
            this.tb註釋後飾字串.TabIndex = 67;
            // 
            // tb註釋前飾字串
            // 
            this.tb註釋前飾字串.Location = new System.Drawing.Point(118, 79);
            this.tb註釋前飾字串.Name = "tb註釋前飾字串";
            this.tb註釋前飾字串.Size = new System.Drawing.Size(397, 27);
            this.tb註釋前飾字串.TabIndex = 66;
            // 
            // tb單字後飾字串
            // 
            this.tb單字後飾字串.Location = new System.Drawing.Point(118, 51);
            this.tb單字後飾字串.Name = "tb單字後飾字串";
            this.tb單字後飾字串.Size = new System.Drawing.Size(397, 27);
            this.tb單字後飾字串.TabIndex = 65;
            // 
            // tb單字前飾字串
            // 
            this.tb單字前飾字串.Location = new System.Drawing.Point(118, 23);
            this.tb單字前飾字串.Name = "tb單字前飾字串";
            this.tb單字前飾字串.Size = new System.Drawing.Size(397, 27);
            this.tb單字前飾字串.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 63;
            this.label6.Text = "註釋後飾字串：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "註釋前飾字串：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 61;
            this.label5.Text = "單字後飾字串：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "單字前飾字串：";
            // 
            // word
            // 
            this.word.HeaderText = "Hard words";
            this.word.Name = "word";
            // 
            // Chinese
            // 
            this.Chinese.FillWeight = 300F;
            this.Chinese.HeaderText = "Explain";
            this.Chinese.Name = "Chinese";
            // 
            // Degree
            // 
            this.Degree.FillWeight = 60F;
            this.Degree.HeaderText = "word rank";
            this.Degree.Name = "Degree";
            // 
            // frequency
            // 
            this.frequency.HeaderText = "詞頻";
            this.frequency.Name = "frequency";
            // 
            // LoadDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1140, 682);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hsb難度);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReadSimulate);
            this.Controls.Add(this.btnAttention);
            this.Controls.Add(this.lbDegree);
            this.Controls.Add(this.cb目標語言);
            this.Controls.Add(this.btnLoadDoc);
            this.Controls.Add(this.btnMassInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.DGVResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoadDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "English MashUpper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoadDoc_FormClosed);
            this.Load += new System.EventHandler(this.LoadDoc_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LoadDoc_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.DGVResult)).EndInit();
            this.RightMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoadDoc;
        private System.Windows.Forms.DataGridView DGVResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbDegree;
        private System.Windows.Forms.Button btnContext;
        private System.Windows.Forms.RichTextBox tbDoc;
        private System.Windows.Forms.Button btnSpeech;
        private System.Windows.Forms.ContextMenuStrip RightMenu;
        private System.Windows.Forms.ToolStripMenuItem 剪下CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 複製CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 貼上PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全選AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 朗讀所選VToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalWordNum;
        private System.Windows.Forms.Label lbDoneWordNum;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnReadSimulate;
        private System.Windows.Forms.Button btnAttention;
        private System.Windows.Forms.Button btnMassInput;
        private System.Windows.Forms.ComboBox cb目標語言;
        private System.Windows.Forms.HScrollBar hsb難度;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb註釋後飾字串;
        private System.Windows.Forms.TextBox tb註釋前飾字串;
        private System.Windows.Forms.TextBox tb單字後飾字串;
        private System.Windows.Forms.TextBox tb單字前飾字串;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb註釋中飾字串;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb註釋中飾字串在註釋中的位置;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb相隔幾個單字插入分頁字串;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb分頁字串;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn長文模式;
        private System.Windows.Forms.TextBox tb文章後飾字串;
        private System.Windows.Forms.TextBox tb文章前飾字串;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cb註釋完整性;
        private System.Windows.Forms.CheckBox cb註釋無詞性;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chinese;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequency;

    }
}