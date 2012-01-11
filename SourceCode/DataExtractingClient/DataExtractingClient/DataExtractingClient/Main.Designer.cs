namespace AdminClient
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txbServiceUrl = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupDetail = new System.Windows.Forms.GroupBox();
            this.txbChanDescr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbExtrDescr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSourceLink = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbSourcePage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbChanCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.gridChannel = new System.Windows.Forms.DataGridView();
            this.ckbAvailable = new System.Windows.Forms.CheckBox();
            this.txbLinkReport = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbScheReport = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupDetail.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN CLIENT";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 44);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txbServiceUrl);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 495);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(880, 49);
            this.panel3.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Service URL";
            // 
            // txbServiceUrl
            // 
            this.txbServiceUrl.Location = new System.Drawing.Point(98, 12);
            this.txbServiceUrl.Name = "txbServiceUrl";
            this.txbServiceUrl.Size = new System.Drawing.Size(689, 27);
            this.txbServiceUrl.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(793, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 27);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupDetail);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridChannel);
            this.splitContainer1.Size = new System.Drawing.Size(880, 451);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupDetail
            // 
            this.groupDetail.Controls.Add(this.txbScheReport);
            this.groupDetail.Controls.Add(this.label9);
            this.groupDetail.Controls.Add(this.txbLinkReport);
            this.groupDetail.Controls.Add(this.label8);
            this.groupDetail.Controls.Add(this.ckbAvailable);
            this.groupDetail.Controls.Add(this.txbChanDescr);
            this.groupDetail.Controls.Add(this.label6);
            this.groupDetail.Controls.Add(this.txbExtrDescr);
            this.groupDetail.Controls.Add(this.label5);
            this.groupDetail.Controls.Add(this.txbSourceLink);
            this.groupDetail.Controls.Add(this.label4);
            this.groupDetail.Controls.Add(this.txbSourcePage);
            this.groupDetail.Controls.Add(this.label3);
            this.groupDetail.Controls.Add(this.txbChanCode);
            this.groupDetail.Controls.Add(this.label2);
            this.groupDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDetail.Location = new System.Drawing.Point(0, 40);
            this.groupDetail.Name = "groupDetail";
            this.groupDetail.Size = new System.Drawing.Size(294, 373);
            this.groupDetail.TabIndex = 11;
            this.groupDetail.TabStop = false;
            this.groupDetail.Text = "Chi tiết";
            // 
            // txbChanDescr
            // 
            this.txbChanDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbChanDescr.Location = new System.Drawing.Point(12, 238);
            this.txbChanDescr.Name = "txbChanDescr";
            this.txbChanDescr.Size = new System.Drawing.Size(279, 27);
            this.txbChanDescr.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Mô tả kênh";
            // 
            // txbExtrDescr
            // 
            this.txbExtrDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbExtrDescr.Location = new System.Drawing.Point(12, 189);
            this.txbExtrDescr.Name = "txbExtrDescr";
            this.txbExtrDescr.Size = new System.Drawing.Size(279, 27);
            this.txbExtrDescr.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mô tả rút trích";
            // 
            // txbSourceLink
            // 
            this.txbSourceLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSourceLink.Location = new System.Drawing.Point(12, 140);
            this.txbSourceLink.Name = "txbSourceLink";
            this.txbSourceLink.Size = new System.Drawing.Size(279, 27);
            this.txbSourceLink.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Link phát";
            // 
            // txbSourcePage
            // 
            this.txbSourcePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSourcePage.Location = new System.Drawing.Point(12, 91);
            this.txbSourcePage.Name = "txbSourcePage";
            this.txbSourcePage.Size = new System.Drawing.Size(279, 27);
            this.txbSourcePage.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Trang nguồn";
            // 
            // txbChanCode
            // 
            this.txbChanCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbChanCode.Location = new System.Drawing.Point(12, 42);
            this.txbChanCode.Name = "txbChanCode";
            this.txbChanCode.Size = new System.Drawing.Size(279, 27);
            this.txbChanCode.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tên mã kênh";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 413);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 38);
            this.panel4.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 27);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnInsert);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 40);
            this.panel2.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(97, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 27);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 27);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(12, 6);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(79, 27);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // gridChannel
            // 
            this.gridChannel.AllowUserToAddRows = false;
            this.gridChannel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChannel.Location = new System.Drawing.Point(0, 0);
            this.gridChannel.MultiSelect = false;
            this.gridChannel.Name = "gridChannel";
            this.gridChannel.ReadOnly = true;
            this.gridChannel.Size = new System.Drawing.Size(581, 451);
            this.gridChannel.TabIndex = 0;
            this.gridChannel.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChannel_RowEnter);
            // 
            // ckbAvailable
            // 
            this.ckbAvailable.AutoSize = true;
            this.ckbAvailable.Location = new System.Drawing.Point(12, 320);
            this.ckbAvailable.Name = "ckbAvailable";
            this.ckbAvailable.Size = new System.Drawing.Size(121, 20);
            this.ckbAvailable.TabIndex = 30;
            this.ckbAvailable.Text = "Còn hoạt động";
            this.ckbAvailable.UseVisualStyleBackColor = true;
            // 
            // txbLinkReport
            // 
            this.txbLinkReport.Location = new System.Drawing.Point(12, 287);
            this.txbLinkReport.Name = "txbLinkReport";
            this.txbLinkReport.Size = new System.Drawing.Size(120, 27);
            this.txbLinkReport.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Report Link";
            // 
            // txbScheReport
            // 
            this.txbScheReport.Location = new System.Drawing.Point(138, 287);
            this.txbScheReport.Name = "txbScheReport";
            this.txbScheReport.Size = new System.Drawing.Size(120, 27);
            this.txbScheReport.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Report Lịch";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupDetail.ResumeLayout(false);
            this.groupDetail.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChannel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridChannel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.GroupBox groupDetail;
        private System.Windows.Forms.TextBox txbChanDescr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbExtrDescr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSourceLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSourcePage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbChanCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbServiceUrl;
        private System.Windows.Forms.CheckBox ckbAvailable;
        private System.Windows.Forms.TextBox txbScheReport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbLinkReport;
        private System.Windows.Forms.Label label8;
    }
}

