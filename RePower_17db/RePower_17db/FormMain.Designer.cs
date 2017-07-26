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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dbText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbwav = new System.Windows.Forms.TextBox();
            this.lblCl = new System.Windows.Forms.Label();
            this.tBClip = new System.Windows.Forms.TextBox();
            this.nUDChnOut = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.pBProgress = new System.Windows.Forms.ProgressBar();
            this.nUDChnIn = new System.Windows.Forms.NumericUpDown();
            this.lbChannel = new System.Windows.Forms.Label();
            this.btDo = new System.Windows.Forms.Button();
            this.tBOut = new System.Windows.Forms.TextBox();
            this.btOut = new System.Windows.Forms.Button();
            this.btTgt = new System.Windows.Forms.Button();
            this.bgWDoWork = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnIn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 0);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "平均处理";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(509, 0);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dbText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbwav);
            this.groupBox2.Controls.Add(this.lblCl);
            this.groupBox2.Controls.Add(this.tBClip);
            this.groupBox2.Controls.Add(this.nUDChnOut);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbProgress);
            this.groupBox2.Controls.Add(this.pBProgress);
            this.groupBox2.Controls.Add(this.nUDChnIn);
            this.groupBox2.Controls.Add(this.lbChannel);
            this.groupBox2.Controls.Add(this.btDo);
            this.groupBox2.Controls.Add(this.tBOut);
            this.groupBox2.Controls.Add(this.btOut);
            this.groupBox2.Controls.Add(this.btTgt);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dbText
            // 
            this.dbText.Location = new System.Drawing.Point(258, 150);
            this.dbText.Name = "dbText";
            this.dbText.Size = new System.Drawing.Size(67, 21);
            this.dbText.TabIndex = 29;
            this.dbText.Text = "-13";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "db值";
            // 
            // tbwav
            // 
            this.tbwav.Location = new System.Drawing.Point(168, 19);
            this.tbwav.Name = "tbwav";
            this.tbwav.Size = new System.Drawing.Size(334, 21);
            this.tbwav.TabIndex = 27;
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
            // nUDChnOut
            // 
            this.nUDChnOut.Location = new System.Drawing.Point(258, 120);
            this.nUDChnOut.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDChnOut.Name = "nUDChnOut";
            this.nUDChnOut.Size = new System.Drawing.Size(67, 21);
            this.nUDChnOut.TabIndex = 16;
            this.nUDChnOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "输出声道";
            // 
            // lbProgress
            // 
            this.lbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProgress.Location = new System.Drawing.Point(12, 388);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(491, 18);
            this.lbProgress.TabIndex = 12;
            this.lbProgress.Text = "Ready.";
            // 
            // pBProgress
            // 
            this.pBProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBProgress.Location = new System.Drawing.Point(12, 365);
            this.pBProgress.Name = "pBProgress";
            this.pBProgress.Size = new System.Drawing.Size(491, 18);
            this.pBProgress.TabIndex = 11;
            // 
            // nUDChnIn
            // 
            this.nUDChnIn.Location = new System.Drawing.Point(84, 120);
            this.nUDChnIn.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDChnIn.Name = "nUDChnIn";
            this.nUDChnIn.Size = new System.Drawing.Size(87, 21);
            this.nUDChnIn.TabIndex = 10;
            this.nUDChnIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbChannel
            // 
            this.lbChannel.AutoSize = true;
            this.lbChannel.Location = new System.Drawing.Point(24, 125);
            this.lbChannel.Name = "lbChannel";
            this.lbChannel.Size = new System.Drawing.Size(53, 12);
            this.lbChannel.TabIndex = 9;
            this.lbChannel.Text = "输入声道";
            // 
            // btDo
            // 
            this.btDo.Location = new System.Drawing.Point(374, 150);
            this.btDo.Name = "btDo";
            this.btDo.Size = new System.Drawing.Size(75, 73);
            this.btDo.TabIndex = 4;
            this.btDo.Text = "开始处理";
            this.btDo.UseVisualStyleBackColor = true;
            this.btDo.Click += new System.EventHandler(this.btDo_Click);
            // 
            // tBOut
            // 
            this.tBOut.Location = new System.Drawing.Point(168, 46);
            this.tBOut.Name = "tBOut";
            this.tBOut.Size = new System.Drawing.Size(332, 21);
            this.tBOut.TabIndex = 3;
            // 
            // btOut
            // 
            this.btOut.Location = new System.Drawing.Point(14, 46);
            this.btOut.Name = "btOut";
            this.btOut.Size = new System.Drawing.Size(148, 23);
            this.btOut.TabIndex = 2;
            this.btOut.Text = "输出目录";
            this.btOut.UseVisualStyleBackColor = true;
            this.btOut.Click += new System.EventHandler(this.btOut_Click);
            // 
            // btTgt
            // 
            this.btTgt.Location = new System.Drawing.Point(14, 17);
            this.btTgt.Name = "btTgt";
            this.btTgt.Size = new System.Drawing.Size(148, 23);
            this.btTgt.TabIndex = 1;
            this.btTgt.Text = "输入目录";
            this.btTgt.UseVisualStyleBackColor = true;
            this.btTgt.Click += new System.EventHandler(this.btTgt_Click);
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
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDChnIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btDo;
        private System.Windows.Forms.TextBox tBOut;
        private System.Windows.Forms.Button btOut;
        private System.Windows.Forms.Button btTgt;
        private System.Windows.Forms.Label lbChannel;
        private System.Windows.Forms.NumericUpDown nUDChnIn;
        private System.ComponentModel.BackgroundWorker bgWDoWork;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ProgressBar pBProgress;
        private System.Windows.Forms.NumericUpDown nUDChnOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCl;
        private System.Windows.Forms.TextBox tBClip;
        private System.Windows.Forms.TextBox tbwav;
        private System.Windows.Forms.TextBox dbText;
        private System.Windows.Forms.Label label2;
    }
}

