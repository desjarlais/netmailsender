namespace NetMailSample.Forms
{
    partial class frmAlternateView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlternateView));
            this.btnAddAlternateViews = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddLR = new System.Windows.Forms.Button();
            this.txtCid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLinkedResPath = new System.Windows.Forms.TextBox();
            this.btnLinkedResBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModifyContentType = new System.Windows.Forms.Button();
            this.btnDeleteAttachment = new System.Windows.Forms.Button();
            this.dGridInlineAttachments = new System.Windows.Forms.DataGridView();
            this.colFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConvertEncoding = new System.Windows.Forms.Button();
            this.cboTransferEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCalSample = new System.Windows.Forms.Button();
            this.cboAltViewContentType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtAltViewBody = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridInlineAttachments)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddAlternateViews
            // 
            this.btnAddAlternateViews.Location = new System.Drawing.Point(751, 430);
            this.btnAddAlternateViews.Name = "btnAddAlternateViews";
            this.btnAddAlternateViews.Size = new System.Drawing.Size(68, 23);
            this.btnAddAlternateViews.TabIndex = 4;
            this.btnAddAlternateViews.Text = "OK";
            this.btnAddAlternateViews.UseVisualStyleBackColor = true;
            this.btnAddAlternateViews.Click += new System.EventHandler(this.btnAddAlternateViews_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(751, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddLR
            // 
            this.btnAddLR.Image = global::NetMailSample.Properties.Resources.AddMark_10580;
            this.btnAddLR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLR.Location = new System.Drawing.Point(293, 47);
            this.btnAddLR.Name = "btnAddLR";
            this.btnAddLR.Size = new System.Drawing.Size(112, 20);
            this.btnAddLR.TabIndex = 9;
            this.btnAddLR.Text = "Add Attachment";
            this.btnAddLR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddLR.UseVisualStyleBackColor = true;
            this.btnAddLR.Click += new System.EventHandler(this.btnAddLR_Click);
            // 
            // txtCid
            // 
            this.txtCid.Location = new System.Drawing.Point(71, 47);
            this.txtCid.Name = "txtCid";
            this.txtCid.Size = new System.Drawing.Size(216, 20);
            this.txtCid.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Content Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Path:";
            // 
            // txtLinkedResPath
            // 
            this.txtLinkedResPath.Location = new System.Drawing.Point(71, 17);
            this.txtLinkedResPath.Name = "txtLinkedResPath";
            this.txtLinkedResPath.Size = new System.Drawing.Size(216, 20);
            this.txtLinkedResPath.TabIndex = 1;
            // 
            // btnLinkedResBrowse
            // 
            this.btnLinkedResBrowse.Image = global::NetMailSample.Properties.Resources.OpenAttachment_13115;
            this.btnLinkedResBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLinkedResBrowse.Location = new System.Drawing.Point(293, 16);
            this.btnLinkedResBrowse.Name = "btnLinkedResBrowse";
            this.btnLinkedResBrowse.Size = new System.Drawing.Size(112, 23);
            this.btnLinkedResBrowse.TabIndex = 0;
            this.btnLinkedResBrowse.Text = "Open Attachment";
            this.btnLinkedResBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLinkedResBrowse.UseVisualStyleBackColor = true;
            this.btnLinkedResBrowse.Click += new System.EventHandler(this.btnLinkedResBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Open Linked Resource";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddLR);
            this.groupBox2.Controls.Add(this.btnModifyContentType);
            this.groupBox2.Controls.Add(this.txtCid);
            this.groupBox2.Controls.Add(this.btnDeleteAttachment);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dGridInlineAttachments);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLinkedResPath);
            this.groupBox2.Controls.Add(this.btnLinkedResBrowse);
            this.groupBox2.Location = new System.Drawing.Point(403, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 393);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message Attachments";
            // 
            // btnModifyContentType
            // 
            this.btnModifyContentType.Image = global::NetMailSample.Properties.Resources.EditTitleString_357;
            this.btnModifyContentType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyContentType.Location = new System.Drawing.Point(9, 364);
            this.btnModifyContentType.Name = "btnModifyContentType";
            this.btnModifyContentType.Size = new System.Drawing.Size(57, 23);
            this.btnModifyContentType.TabIndex = 11;
            this.btnModifyContentType.Text = "Edit";
            this.btnModifyContentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyContentType.UseVisualStyleBackColor = true;
            this.btnModifyContentType.Click += new System.EventHandler(this.btnModifyContentType_Click);
            // 
            // btnDeleteAttachment
            // 
            this.btnDeleteAttachment.Image = global::NetMailSample.Properties.Resources.Clearallrequests_8816;
            this.btnDeleteAttachment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteAttachment.Location = new System.Drawing.Point(72, 364);
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(61, 23);
            this.btnDeleteAttachment.TabIndex = 10;
            this.btnDeleteAttachment.Text = "Delete";
            this.btnDeleteAttachment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // dGridInlineAttachments
            // 
            this.dGridInlineAttachments.AllowUserToAddRows = false;
            this.dGridInlineAttachments.AllowUserToDeleteRows = false;
            this.dGridInlineAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridInlineAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilePath,
            this.colCid,
            this.colContentType});
            this.dGridInlineAttachments.Location = new System.Drawing.Point(9, 76);
            this.dGridInlineAttachments.MultiSelect = false;
            this.dGridInlineAttachments.Name = "dGridInlineAttachments";
            this.dGridInlineAttachments.ReadOnly = true;
            this.dGridInlineAttachments.Size = new System.Drawing.Size(396, 282);
            this.dGridInlineAttachments.TabIndex = 0;
            // 
            // colFilePath
            // 
            this.colFilePath.HeaderText = "Path";
            this.colFilePath.Name = "colFilePath";
            this.colFilePath.ReadOnly = true;
            // 
            // colCid
            // 
            this.colCid.HeaderText = "Content Id";
            this.colCid.Name = "colCid";
            this.colCid.ReadOnly = true;
            // 
            // colContentType
            // 
            this.colContentType.HeaderText = "Content Type";
            this.colContentType.Name = "colContentType";
            this.colContentType.ReadOnly = true;
            // 
            // btnConvertEncoding
            // 
            this.btnConvertEncoding.Location = new System.Drawing.Point(6, 451);
            this.btnConvertEncoding.Name = "btnConvertEncoding";
            this.btnConvertEncoding.Size = new System.Drawing.Size(130, 23);
            this.btnConvertEncoding.TabIndex = 1;
            this.btnConvertEncoding.Text = "Convert Encoded Text";
            this.btnConvertEncoding.UseVisualStyleBackColor = true;
            this.btnConvertEncoding.Click += new System.EventHandler(this.btnConvertEncoding_Click);
            // 
            // cboTransferEncoding
            // 
            this.cboTransferEncoding.FormattingEnabled = true;
            this.cboTransferEncoding.Items.AddRange(new object[] {
            "SevenBit",
            "Base64",
            "QuotedPrintable",
            "Unknown"});
            this.cboTransferEncoding.Location = new System.Drawing.Point(157, 47);
            this.cboTransferEncoding.Name = "cboTransferEncoding";
            this.cboTransferEncoding.Size = new System.Drawing.Size(179, 21);
            this.cboTransferEncoding.TabIndex = 0;
            this.cboTransferEncoding.Text = "QuotedPrintable";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboTransferEncoding);
            this.groupBox3.Controls.Add(this.cboAltViewContentType);
            this.groupBox3.Location = new System.Drawing.Point(403, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 81);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alt View Settings";
            // 
            // btnCalSample
            // 
            this.btnCalSample.Location = new System.Drawing.Point(142, 451);
            this.btnCalSample.Name = "btnCalSample";
            this.btnCalSample.Size = new System.Drawing.Size(114, 23);
            this.btnCalSample.TabIndex = 12;
            this.btnCalSample.Text = "Insert vCal Sample";
            this.btnCalSample.UseVisualStyleBackColor = true;
            this.btnCalSample.Click += new System.EventHandler(this.btnCalSample_Click);
            // 
            // cboAltViewContentType
            // 
            this.cboAltViewContentType.FormattingEnabled = true;
            this.cboAltViewContentType.Items.AddRange(new object[] {
            "HTML",
            "PlainText",
            "vCalendar"});
            this.cboAltViewContentType.Location = new System.Drawing.Point(157, 19);
            this.cboAltViewContentType.Name = "cboAltViewContentType";
            this.cboAltViewContentType.Size = new System.Drawing.Size(179, 21);
            this.cboAltViewContentType.TabIndex = 0;
            this.cboAltViewContentType.Text = "HTML";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCalSample);
            this.groupBox5.Controls.Add(this.btnConvertEncoding);
            this.groupBox5.Controls.Add(this.txtAltViewBody);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(385, 480);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Alt View Body";
            // 
            // txtAltViewBody
            // 
            this.txtAltViewBody.Location = new System.Drawing.Point(3, 16);
            this.txtAltViewBody.Multiline = true;
            this.txtAltViewBody.Name = "txtAltViewBody";
            this.txtAltViewBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAltViewBody.Size = new System.Drawing.Size(376, 429);
            this.txtAltViewBody.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Content-Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Content Transform Encoding:";
            // 
            // frmAlternateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 500);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddAlternateViews);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlternateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alternate Views";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridInlineAttachments)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAlternateViews;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLinkedResPath;
        private System.Windows.Forms.Button btnLinkedResBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtCid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddLR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnModifyContentType;
        private System.Windows.Forms.Button btnDeleteAttachment;
        private System.Windows.Forms.DataGridView dGridInlineAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContentType;
        private System.Windows.Forms.ComboBox cboTransferEncoding;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboAltViewContentType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtAltViewBody;
        private System.Windows.Forms.Button btnCalSample;
        private System.Windows.Forms.Button btnConvertEncoding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}