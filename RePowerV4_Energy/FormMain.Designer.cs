namespace RePowerV
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lBMode = new System.Windows.Forms.ListBox();
            this.lBFile = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbwav = new System.Windows.Forms.TextBox();
            this.tbdataint = new System.Windows.Forms.TextBox();
            this.btdataint = new System.Windows.Forms.Button();
            this.tbmodeint = new System.Windows.Forms.TextBox();
            this.btnmode = new System.Windows.Forms.Button();
            this.tbvo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCl = new System.Windows.Forms.Label();
            this.tBClip = new System.Windows.Forms.TextBox();
            this.nUDFrameTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDChnOut = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDIgnore = new System.Windows.Forms.NumericUpDown();
            this.lbIgnore = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.pBProgress = new System.Windows.Forms.ProgressBar();
            this.nUDChnIn = new System.Windows.Forms.NumericUpDown();
            this.lbChannel = new System.Windows.Forms.Label();
            this.lblxs = new System.Windows.Forms.Label();
            this.tBAvg = new System.Windows.Forms.TextBox();
            this.btClear = new System.Windows.Forms.Button();
            this.btDo = new System.Windows.Forms.Button();
            this.tBOut = new System.Windows.Forms.TextBox();
            this.btOut = new System.Windows.Forms.Button();
            this.btTgt = new System.Windows.Forms.Button();
            this.btSrc = new System.Windows.Forms.Button();
            this.bgWDoWork = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFrameTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIgnore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnIn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "平均处理";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lBMode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lBFile);
            this.splitContainer1.Size = new System.Drawing.Size(509, 172);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            // 
            // lBMode
            // 
            this.lBMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBMode.FormattingEnabled = true;
            this.lBMode.ItemHeight = 12;
            this.lBMode.Location = new System.Drawing.Point(0, 0);
            this.lBMode.Name = "lBMode";
            this.lBMode.Size = new System.Drawing.Size(360, 172);
            this.lBMode.TabIndex = 1;
            // 
            // lBFile
            // 
            this.lBFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBFile.FormattingEnabled = true;
            this.lBFile.ItemHeight = 12;
            this.lBFile.Location = new System.Drawing.Point(0, 0);
            this.lBFile.Name = "lBFile";
            this.lBFile.Size = new System.Drawing.Size(145, 172);
            this.lBFile.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbwav);
            this.groupBox2.Controls.Add(this.tbdataint);
            this.groupBox2.Controls.Add(this.btdataint);
            this.groupBox2.Controls.Add(this.tbmodeint);
            this.groupBox2.Controls.Add(this.btnmode);
            this.groupBox2.Controls.Add(this.tbvo);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lblCl);
            this.groupBox2.Controls.Add(this.tBClip);
            this.groupBox2.Controls.Add(this.nUDFrameTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nUDChnOut);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nUDIgnore);
            this.groupBox2.Controls.Add(this.lbIgnore);
            this.groupBox2.Controls.Add(this.lbProgress);
            this.groupBox2.Controls.Add(this.pBProgress);
            this.groupBox2.Controls.Add(this.nUDChnIn);
            this.groupBox2.Controls.Add(this.lbChannel);
            this.groupBox2.Controls.Add(this.lblxs);
            this.groupBox2.Controls.Add(this.tBAvg);
            this.groupBox2.Controls.Add(this.btClear);
            this.groupBox2.Controls.Add(this.btDo);
            this.groupBox2.Controls.Add(this.tBOut);
            this.groupBox2.Controls.Add(this.btOut);
            this.groupBox2.Controls.Add(this.btTgt);
            this.groupBox2.Controls.Add(this.btSrc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tbwav
            // 
            this.tbwav.Location = new System.Drawing.Point(340, 40);
            this.tbwav.Name = "tbwav";
            this.tbwav.Size = new System.Drawing.Size(164, 21);
            this.tbwav.TabIndex = 27;
            // 
            // tbdataint
            // 
            this.tbdataint.Location = new System.Drawing.Point(339, 13);
            this.tbdataint.Name = "tbdataint";
            this.tbdataint.Size = new System.Drawing.Size(164, 21);
            this.tbdataint.TabIndex = 26;
            // 
            // btdataint
            // 
            this.btdataint.Location = new System.Drawing.Point(177, 13);
            this.btdataint.Name = "btdataint";
            this.btdataint.Size = new System.Drawing.Size(155, 23);
            this.btdataint.TabIndex = 25;
            this.btdataint.Text = "数据interval";
            this.btdataint.UseVisualStyleBackColor = true;
            this.btdataint.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbmodeint
            // 
            this.tbmodeint.Location = new System.Drawing.Point(82, 13);
            this.tbmodeint.Name = "tbmodeint";
            this.tbmodeint.Size = new System.Drawing.Size(89, 21);
            this.tbmodeint.TabIndex = 24;
            // 
            // btnmode
            // 
            this.btnmode.Location = new System.Drawing.Point(11, 13);
            this.btnmode.Name = "btnmode";
            this.btnmode.Size = new System.Drawing.Size(65, 23);
            this.btnmode.TabIndex = 23;
            this.btnmode.Text = "interval";
            this.btnmode.UseVisualStyleBackColor = true;
            this.btnmode.Click += new System.EventHandler(this.btnmode_Click);
            // 
            // tbvo
            // 
            this.tbvo.Location = new System.Drawing.Point(82, 96);
            this.tbvo.Name = "tbvo";
            this.tbvo.Size = new System.Drawing.Size(332, 21);
            this.tbvo.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "元音列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCl
            // 
            this.lblCl.AutoSize = true;
            this.lblCl.Location = new System.Drawing.Point(24, 150);
            this.lblCl.Name = "lblCl";
            this.lblCl.Size = new System.Drawing.Size(53, 12);
            this.lblCl.TabIndex = 20;
            this.lblCl.Text = "截副系数";
            // 
            // tBClip
            // 
            this.tBClip.Location = new System.Drawing.Point(84, 147);
            this.tBClip.Name = "tBClip";
            this.tBClip.Size = new System.Drawing.Size(87, 21);
            this.tBClip.TabIndex = 19;
            this.tBClip.Text = "29000";
            // 
            // nUDFrameTime
            // 
            this.nUDFrameTime.DecimalPlaces = 3;
            this.nUDFrameTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUDFrameTime.Location = new System.Drawing.Point(340, 123);
            this.nUDFrameTime.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDFrameTime.Name = "nUDFrameTime";
            this.nUDFrameTime.Size = new System.Drawing.Size(81, 21);
            this.nUDFrameTime.TabIndex = 18;
            this.nUDFrameTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUDFrameTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "帧长(s)";
            // 
            // nUDChnOut
            // 
            this.nUDChnOut.Location = new System.Drawing.Point(235, 150);
            this.nUDChnOut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDChnOut.Name = "nUDChnOut";
            this.nUDChnOut.Size = new System.Drawing.Size(40, 21);
            this.nUDChnOut.TabIndex = 16;
            this.nUDChnOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "输出声道";
            // 
            // nUDIgnore
            // 
            this.nUDIgnore.Location = new System.Drawing.Point(340, 148);
            this.nUDIgnore.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nUDIgnore.Name = "nUDIgnore";
            this.nUDIgnore.Size = new System.Drawing.Size(81, 21);
            this.nUDIgnore.TabIndex = 14;
            this.nUDIgnore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nUDIgnore.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lbIgnore
            // 
            this.lbIgnore.AutoSize = true;
            this.lbIgnore.Location = new System.Drawing.Point(293, 152);
            this.lbIgnore.Name = "lbIgnore";
            this.lbIgnore.Size = new System.Drawing.Size(41, 12);
            this.lbIgnore.TabIndex = 13;
            this.lbIgnore.Text = "忽略帧";
            // 
            // lbProgress
            // 
            this.lbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProgress.Location = new System.Drawing.Point(12, 196);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(491, 18);
            this.lbProgress.TabIndex = 12;
            this.lbProgress.Text = "Ready.";
            // 
            // pBProgress
            // 
            this.pBProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBProgress.Location = new System.Drawing.Point(12, 173);
            this.pBProgress.Name = "pBProgress";
            this.pBProgress.Size = new System.Drawing.Size(491, 18);
            this.pBProgress.TabIndex = 11;
            // 
            // nUDChnIn
            // 
            this.nUDChnIn.Location = new System.Drawing.Point(235, 123);
            this.nUDChnIn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDChnIn.Name = "nUDChnIn";
            this.nUDChnIn.Size = new System.Drawing.Size(40, 21);
            this.nUDChnIn.TabIndex = 10;
            this.nUDChnIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbChannel
            // 
            this.lbChannel.AutoSize = true;
            this.lbChannel.Location = new System.Drawing.Point(176, 126);
            this.lbChannel.Name = "lbChannel";
            this.lbChannel.Size = new System.Drawing.Size(53, 12);
            this.lbChannel.TabIndex = 9;
            this.lbChannel.Text = "输入声道";
            // 
            // lblxs
            // 
            this.lblxs.AutoSize = true;
            this.lblxs.Location = new System.Drawing.Point(49, 126);
            this.lblxs.Name = "lblxs";
            this.lblxs.Size = new System.Drawing.Size(29, 12);
            this.lblxs.TabIndex = 7;
            this.lblxs.Text = "系数";
            // 
            // tBAvg
            // 
            this.tBAvg.Location = new System.Drawing.Point(84, 123);
            this.tBAvg.Name = "tBAvg";
            this.tBAvg.ReadOnly = true;
            this.tBAvg.Size = new System.Drawing.Size(87, 21);
            this.tBAvg.TabIndex = 6;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(427, 65);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 5;
            this.btClear.Text = "清空";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btDo
            // 
            this.btDo.Location = new System.Drawing.Point(427, 94);
            this.btDo.Name = "btDo";
            this.btDo.Size = new System.Drawing.Size(75, 73);
            this.btDo.TabIndex = 4;
            this.btDo.Text = "开始处理";
            this.btDo.UseVisualStyleBackColor = true;
            this.btDo.Click += new System.EventHandler(this.btDo_Click);
            // 
            // tBOut
            // 
            this.tBOut.Location = new System.Drawing.Point(82, 69);
            this.tBOut.Name = "tBOut";
            this.tBOut.Size = new System.Drawing.Size(332, 21);
            this.tBOut.TabIndex = 3;
            // 
            // btOut
            // 
            this.btOut.Location = new System.Drawing.Point(11, 69);
            this.btOut.Name = "btOut";
            this.btOut.Size = new System.Drawing.Size(65, 23);
            this.btOut.TabIndex = 2;
            this.btOut.Text = "目标目录";
            this.btOut.UseVisualStyleBackColor = true;
            this.btOut.Click += new System.EventHandler(this.btOut_Click);
            // 
            // btTgt
            // 
            this.btTgt.Location = new System.Drawing.Point(175, 40);
            this.btTgt.Name = "btTgt";
            this.btTgt.Size = new System.Drawing.Size(158, 23);
            this.btTgt.TabIndex = 1;
            this.btTgt.Text = "待处理数据";
            this.btTgt.UseVisualStyleBackColor = true;
            this.btTgt.Click += new System.EventHandler(this.btTgt_Click);
            // 
            // btSrc
            // 
            this.btSrc.Location = new System.Drawing.Point(11, 40);
            this.btSrc.Name = "btSrc";
            this.btSrc.Size = new System.Drawing.Size(158, 23);
            this.btSrc.TabIndex = 0;
            this.btSrc.Text = "模板数据";
            this.btSrc.UseVisualStyleBackColor = true;
            this.btSrc.Click += new System.EventHandler(this.btSrc_Click);
            // 
            // bgWDoWork
            // 
            this.bgWDoWork.WorkerReportsProgress = true;
            this.bgWDoWork.WorkerSupportsCancellation = true;
            this.bgWDoWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWDoWork_DoWork);
            this.bgWDoWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWDoWork_ProgressChanged);
            this.bgWDoWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWDoWork_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMain";
            this.Text = "合成能量处理工具-音量";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDFrameTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIgnore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lBMode;
        private System.Windows.Forms.ListBox lBFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btDo;
        private System.Windows.Forms.TextBox tBOut;
        private System.Windows.Forms.Button btOut;
        private System.Windows.Forms.Button btTgt;
        private System.Windows.Forms.Button btSrc;
        private System.Windows.Forms.Label lblxs;
        private System.Windows.Forms.TextBox tBAvg;
        private System.Windows.Forms.Label lbChannel;
        private System.Windows.Forms.NumericUpDown nUDChnIn;
        private System.ComponentModel.BackgroundWorker bgWDoWork;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ProgressBar pBProgress;
        private System.Windows.Forms.NumericUpDown nUDIgnore;
        private System.Windows.Forms.Label lbIgnore;
        private System.Windows.Forms.NumericUpDown nUDChnOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDFrameTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCl;
        private System.Windows.Forms.TextBox tBClip;
        private System.Windows.Forms.TextBox tbvo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbdataint;
        private System.Windows.Forms.Button btdataint;
        private System.Windows.Forms.TextBox tbmodeint;
        private System.Windows.Forms.Button btnmode;
        private System.Windows.Forms.TextBox tbwav;
    }
}

