namespace WindowsFormsTibco
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxService = new System.Windows.Forms.TextBox();
            this.textBoxnetwork = new System.Windows.Forms.TextBox();
            this.textBoxdaemon = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewMessage = new System.Windows.Forms.DataGridView();
            this.FIELD_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIELD_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSendSubject = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBoxListen = new System.Windows.Forms.RichTextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.textBoxListenerSubject = new System.Windows.Forms.TextBox();
            this.buttonIFXAPI = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxService
            // 
            this.textBoxService.Location = new System.Drawing.Point(9, 19);
            this.textBoxService.Name = "textBoxService";
            this.textBoxService.Size = new System.Drawing.Size(43, 20);
            this.textBoxService.TabIndex = 0;
            this.textBoxService.Text = "7603";
            // 
            // textBoxnetwork
            // 
            this.textBoxnetwork.Location = new System.Drawing.Point(58, 19);
            this.textBoxnetwork.Name = "textBoxnetwork";
            this.textBoxnetwork.Size = new System.Drawing.Size(100, 20);
            this.textBoxnetwork.TabIndex = 2;
            this.textBoxnetwork.Text = ";239.255.159.223";
            // 
            // textBoxdaemon
            // 
            this.textBoxdaemon.Location = new System.Drawing.Point(164, 19);
            this.textBoxdaemon.Name = "textBoxdaemon";
            this.textBoxdaemon.Size = new System.Drawing.Size(237, 20);
            this.textBoxdaemon.TabIndex = 3;
            this.textBoxdaemon.Text = "siaxv005t.siapm.com.cn:7500";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxnetwork);
            this.groupBox1.Controls.Add(this.textBoxdaemon);
            this.groupBox1.Controls.Add(this.textBoxService);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tibco";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 394);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIFXAPI);
            this.groupBox2.Controls.Add(this.dataGridViewMessage);
            this.groupBox2.Controls.Add(this.buttonSend);
            this.groupBox2.Controls.Add(this.textBoxSendSubject);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 388);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sender";
            // 
            // dataGridViewMessage
            // 
            this.dataGridViewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIELD_NAME,
            this.FIELD_VALUE});
            this.dataGridViewMessage.Location = new System.Drawing.Point(6, 75);
            this.dataGridViewMessage.Name = "dataGridViewMessage";
            this.dataGridViewMessage.Size = new System.Drawing.Size(379, 307);
            this.dataGridViewMessage.TabIndex = 2;
            // 
            // FIELD_NAME
            // 
            this.FIELD_NAME.HeaderText = "FIELD_NAME";
            this.FIELD_NAME.Name = "FIELD_NAME";
            // 
            // FIELD_VALUE
            // 
            this.FIELD_VALUE.HeaderText = "FIELD_VALUE";
            this.FIELD_VALUE.Name = "FIELD_VALUE";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(6, 45);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxSendSubject
            // 
            this.textBoxSendSubject.Location = new System.Drawing.Point(6, 19);
            this.textBoxSendSubject.Name = "textBoxSendSubject";
            this.textBoxSendSubject.Size = new System.Drawing.Size(300, 20);
            this.textBoxSendSubject.TabIndex = 0;
            this.textBoxSendSubject.Text = "SIAPM_L.LEARN.QCTEST";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBoxListen);
            this.groupBox3.Controls.Add(this.buttonListen);
            this.groupBox3.Controls.Add(this.textBoxListenerSubject);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(400, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 388);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listener";
            // 
            // richTextBoxListen
            // 
            this.richTextBoxListen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxListen.Location = new System.Drawing.Point(6, 45);
            this.richTextBoxListen.Name = "richTextBoxListen";
            this.richTextBoxListen.ReadOnly = true;
            this.richTextBoxListen.Size = new System.Drawing.Size(379, 337);
            this.richTextBoxListen.TabIndex = 5;
            this.richTextBoxListen.Text = "";
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(310, 17);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 23);
            this.buttonListen.TabIndex = 3;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // textBoxListenerSubject
            // 
            this.textBoxListenerSubject.Location = new System.Drawing.Point(6, 20);
            this.textBoxListenerSubject.Name = "textBoxListenerSubject";
            this.textBoxListenerSubject.Size = new System.Drawing.Size(300, 20);
            this.textBoxListenerSubject.TabIndex = 2;
            this.textBoxListenerSubject.Text = "SIAPM_L.LEARN.QCTEST";
            // 
            // buttonIFXAPI
            // 
            this.buttonIFXAPI.Location = new System.Drawing.Point(87, 45);
            this.buttonIFXAPI.Name = "buttonIFXAPI";
            this.buttonIFXAPI.Size = new System.Drawing.Size(75, 23);
            this.buttonIFXAPI.TabIndex = 4;
            this.buttonIFXAPI.Text = "IFXAPI";
            this.buttonIFXAPI.UseVisualStyleBackColor = true;
            this.buttonIFXAPI.Click += new System.EventHandler(this.buttonIFXAPI_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Tibco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMessage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxService;
        private System.Windows.Forms.TextBox textBoxnetwork;
        private System.Windows.Forms.TextBox textBoxdaemon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSendSubject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIELD_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIELD_VALUE;
        private System.Windows.Forms.RichTextBox richTextBoxListen;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.TextBox textBoxListenerSubject;
        private System.Windows.Forms.Button buttonIFXAPI;
    }
}

