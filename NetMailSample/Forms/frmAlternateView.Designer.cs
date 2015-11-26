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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dGridInlineAttachments = new System.Windows.Forms.DataGridView();
            this.colFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editContentIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colContentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnConvertEncoding = new System.Windows.Forms.Button();
            this.cboTransferEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAltViewContentType = new System.Windows.Forms.ComboBox();
            this.btnCalSample = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnEncodeText = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHTML = new System.Windows.Forms.TabPage();
            this.txtHTMLAltViewBody = new System.Windows.Forms.TextBox();
            this.tabCalendar = new System.Windows.Forms.TabPage();
            this.txtCalendarAltViewBody = new System.Windows.Forms.TextBox();
            this.tabPlain = new System.Windows.Forms.TabPage();
            this.txtPlainAltViewBody = new System.Windows.Forms.TextBox();
            this.btnInsertHTML = new System.Windows.Forms.Button();
            this.btnDeleteAltViewAttachment = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridInlineAttachments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHTML.SuspendLayout();
            this.tabCalendar.SuspendLayout();
            this.tabPlain.SuspendLayout();
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
            this.btnAddLR.Location = new System.Drawing.Point(298, 47);
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
            this.txtCid.Size = new System.Drawing.Size(221, 20);
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
            this.txtLinkedResPath.Size = new System.Drawing.Size(221, 20);
            this.txtLinkedResPath.TabIndex = 1;
            // 
            // btnLinkedResBrowse
            // 
            this.btnLinkedResBrowse.Image = global::NetMailSample.Properties.Resources.OpenAttachment_13115;
            this.btnLinkedResBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLinkedResBrowse.Location = new System.Drawing.Point(298, 15);
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
            this.groupBox2.Controls.Add(this.btnDeleteAltViewAttachment);
            this.groupBox2.Controls.Add(this.btnAddLR);
            this.groupBox2.Controls.Add(this.txtCid);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dGridInlineAttachments);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLinkedResPath);
            this.groupBox2.Controls.Add(this.btnLinkedResBrowse);
            this.groupBox2.Location = new System.Drawing.Point(403, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 400);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message Attachments";
            // 
            // dGridInlineAttachments
            // 
            this.dGridInlineAttachments.AllowUserToAddRows = false;
            this.dGridInlineAttachments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridInlineAttachments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGridInlineAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridInlineAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilePath,
            this.colCid,
            this.colContentType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGridInlineAttachments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGridInlineAttachments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGridInlineAttachments.Location = new System.Drawing.Point(9, 76);
            this.dGridInlineAttachments.MultiSelect = false;
            this.dGridInlineAttachments.Name = "dGridInlineAttachments";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGridInlineAttachments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGridInlineAttachments.Size = new System.Drawing.Size(352, 318);
            this.dGridInlineAttachments.TabIndex = 0;
            this.dGridInlineAttachments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridInlineAttachments_CellClick);
            this.dGridInlineAttachments.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGridInlineAttachments_CellMouseDown);
            // 
            // colFilePath
            // 
            this.colFilePath.HeaderText = "Path";
            this.colFilePath.Name = "colFilePath";
            // 
            // colCid
            // 
            this.colCid.ContextMenuStrip = this.contextMenuStrip1;
            this.colCid.HeaderText = "Content Id";
            this.colCid.Name = "colCid";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editContentIDToolStripMenuItem,
            this.deleteAttachmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 48);
            // 
            // editContentIDToolStripMenuItem
            // 
            this.editContentIDToolStripMenuItem.Name = "editContentIDToolStripMenuItem";
            this.editContentIDToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.editContentIDToolStripMenuItem.Text = "Edit Content ID";
            this.editContentIDToolStripMenuItem.Click += new System.EventHandler(this.editContentIDToolStripMenuItem_Click);
            // 
            // deleteAttachmentToolStripMenuItem
            // 
            this.deleteAttachmentToolStripMenuItem.Name = "deleteAttachmentToolStripMenuItem";
            this.deleteAttachmentToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteAttachmentToolStripMenuItem.Text = "Delete Attachment";
            this.deleteAttachmentToolStripMenuItem.Click += new System.EventHandler(this.deleteAttachmentToolStripMenuItem_Click);
            // 
            // colContentType
            // 
            this.colContentType.HeaderText = "Content Type";
            this.colContentType.Items.AddRange(new object[] {
            "Octet",
            "Pdf",
            "Rtf",
            "Soap",
            "Zip",
            "Gif",
            "Jpeg",
            "Tiff",
            "Html",
            "Plain",
            "RichText",
            "Xml"});
            this.colContentType.Name = "colContentType";
            this.colContentType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colContentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnConvertEncoding
            // 
            this.btnConvertEncoding.Location = new System.Drawing.Point(104, 451);
            this.btnConvertEncoding.Name = "btnConvertEncoding";
            this.btnConvertEncoding.Size = new System.Drawing.Size(91, 23);
            this.btnConvertEncoding.TabIndex = 1;
            this.btnConvertEncoding.Text = "Decode Text";
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
            this.groupBox3.Location = new System.Drawing.Point(403, 418);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 74);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alt View Settings";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Content-Type:";
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
            // btnCalSample
            // 
            this.btnCalSample.Location = new System.Drawing.Point(201, 451);
            this.btnCalSample.Name = "btnCalSample";
            this.btnCalSample.Size = new System.Drawing.Size(85, 23);
            this.btnCalSample.TabIndex = 12;
            this.btnCalSample.Text = "vCal Sample";
            this.btnCalSample.UseVisualStyleBackColor = true;
            this.btnCalSample.Click += new System.EventHandler(this.btnCalSample_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnEncodeText);
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Controls.Add(this.btnInsertHTML);
            this.groupBox5.Controls.Add(this.btnCalSample);
            this.groupBox5.Controls.Add(this.btnConvertEncoding);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(385, 480);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Alt View Body";
            // 
            // btnEncodeText
            // 
            this.btnEncodeText.Location = new System.Drawing.Point(10, 451);
            this.btnEncodeText.Name = "btnEncodeText";
            this.btnEncodeText.Size = new System.Drawing.Size(88, 23);
            this.btnEncodeText.TabIndex = 13;
            this.btnEncodeText.Text = "Encode Text";
            this.btnEncodeText.UseVisualStyleBackColor = true;
            this.btnEncodeText.Click += new System.EventHandler(this.btnEncodeText_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHTML);
            this.tabControl1.Controls.Add(this.tabCalendar);
            this.tabControl1.Controls.Add(this.tabPlain);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 422);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabHTML
            // 
            this.tabHTML.Controls.Add(this.txtHTMLAltViewBody);
            this.tabHTML.Location = new System.Drawing.Point(4, 22);
            this.tabHTML.Name = "tabHTML";
            this.tabHTML.Padding = new System.Windows.Forms.Padding(3);
            this.tabHTML.Size = new System.Drawing.Size(365, 396);
            this.tabHTML.TabIndex = 1;
            this.tabHTML.Text = "HTML";
            this.tabHTML.UseVisualStyleBackColor = true;
            // 
            // txtHTMLAltViewBody
            // 
            this.txtHTMLAltViewBody.Location = new System.Drawing.Point(6, 3);
            this.txtHTMLAltViewBody.Multiline = true;
            this.txtHTMLAltViewBody.Name = "txtHTMLAltViewBody";
            this.txtHTMLAltViewBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHTMLAltViewBody.Size = new System.Drawing.Size(352, 385);
            this.txtHTMLAltViewBody.TabIndex = 0;
            // 
            // tabCalendar
            // 
            this.tabCalendar.Controls.Add(this.txtCalendarAltViewBody);
            this.tabCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabCalendar.Name = "tabCalendar";
            this.tabCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendar.Size = new System.Drawing.Size(365, 396);
            this.tabCalendar.TabIndex = 0;
            this.tabCalendar.Text = "Calendar";
            this.tabCalendar.UseVisualStyleBackColor = true;
            // 
            // txtCalendarAltViewBody
            // 
            this.txtCalendarAltViewBody.Location = new System.Drawing.Point(7, 5);
            this.txtCalendarAltViewBody.Multiline = true;
            this.txtCalendarAltViewBody.Name = "txtCalendarAltViewBody";
            this.txtCalendarAltViewBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCalendarAltViewBody.Size = new System.Drawing.Size(352, 385);
            this.txtCalendarAltViewBody.TabIndex = 0;
            // 
            // tabPlain
            // 
            this.tabPlain.Controls.Add(this.txtPlainAltViewBody);
            this.tabPlain.Location = new System.Drawing.Point(4, 22);
            this.tabPlain.Name = "tabPlain";
            this.tabPlain.Size = new System.Drawing.Size(365, 396);
            this.tabPlain.TabIndex = 2;
            this.tabPlain.Text = "Plain";
            this.tabPlain.UseVisualStyleBackColor = true;
            // 
            // txtPlainAltViewBody
            // 
            this.txtPlainAltViewBody.Location = new System.Drawing.Point(4, 5);
            this.txtPlainAltViewBody.Multiline = true;
            this.txtPlainAltViewBody.Name = "txtPlainAltViewBody";
            this.txtPlainAltViewBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPlainAltViewBody.Size = new System.Drawing.Size(352, 385);
            this.txtPlainAltViewBody.TabIndex = 0;
            // 
            // btnInsertHTML
            // 
            this.btnInsertHTML.Location = new System.Drawing.Point(292, 451);
            this.btnInsertHTML.Name = "btnInsertHTML";
            this.btnInsertHTML.Size = new System.Drawing.Size(87, 23);
            this.btnInsertHTML.TabIndex = 12;
            this.btnInsertHTML.Text = "HTML Sample";
            this.btnInsertHTML.UseVisualStyleBackColor = true;
            this.btnInsertHTML.Click += new System.EventHandler(this.btnInsertHTML_Click);
            // 
            // btnDeleteAltViewAttachment
            // 
            this.btnDeleteAltViewAttachment.Image = global::NetMailSample.Properties.Resources.Clearallrequests_8816;
            this.btnDeleteAltViewAttachment.Location = new System.Drawing.Point(369, 76);
            this.btnDeleteAltViewAttachment.Name = "btnDeleteAltViewAttachment";
            this.btnDeleteAltViewAttachment.Size = new System.Drawing.Size(41, 23);
            this.btnDeleteAltViewAttachment.TabIndex = 10;
            this.btnDeleteAltViewAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteAltViewAttachment.Click += new System.EventHandler(this.btnDeleteAltViewAttachment_Click);
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabHTML.ResumeLayout(false);
            this.tabHTML.PerformLayout();
            this.tabCalendar.ResumeLayout(false);
            this.tabCalendar.PerformLayout();
            this.tabPlain.ResumeLayout(false);
            this.tabPlain.PerformLayout();
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
        private System.Windows.Forms.DataGridView dGridInlineAttachments;
        private System.Windows.Forms.ComboBox cboTransferEncoding;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboAltViewContentType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtHTMLAltViewBody;
        private System.Windows.Forms.Button btnCalSample;
        private System.Windows.Forms.Button btnConvertEncoding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertHTML;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCalendar;
        private System.Windows.Forms.TabPage tabPlain;
        private System.Windows.Forms.TabPage tabHTML;
        private System.Windows.Forms.TextBox txtCalendarAltViewBody;
        private System.Windows.Forms.TextBox txtPlainAltViewBody;
        private System.Windows.Forms.Button btnEncodeText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editContentIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAttachmentToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCid;
        private System.Windows.Forms.DataGridViewComboBoxColumn colContentType;
        private System.Windows.Forms.Button btnDeleteAltViewAttachment;
    }
}