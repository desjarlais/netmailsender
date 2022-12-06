namespace NetMailSample.Forms
{
    partial class FrmMessageOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageOptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSubjectEncoding = new System.Windows.Forms.ComboBox();
            this.cmbHeaderEncoding = new System.Windows.Forms.ComboBox();
            this.cmbBodyEncoding = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUpDnSendTimeOut = new System.Windows.Forms.NumericUpDown();
            this.chkReadRcpt = new System.Windows.Forms.CheckBox();
            this.chkBodyHtml = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbMsgPriority = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkOnSuccess = new System.Windows.Forms.CheckBox();
            this.chkOnFailure = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSendTimeOut)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSubjectEncoding);
            this.groupBox1.Controls.Add(this.cmbHeaderEncoding);
            this.groupBox1.Controls.Add(this.cmbBodyEncoding);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(452, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encoding";
            // 
            // cmbSubjectEncoding
            // 
            this.cmbSubjectEncoding.FormattingEnabled = true;
            this.cmbSubjectEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cmbSubjectEncoding.Location = new System.Drawing.Point(168, 78);
            this.cmbSubjectEncoding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSubjectEncoding.Name = "cmbSubjectEncoding";
            this.cmbSubjectEncoding.Size = new System.Drawing.Size(267, 24);
            this.cmbSubjectEncoding.TabIndex = 7;
            this.cmbSubjectEncoding.Text = "ASCII";
            // 
            // cmbHeaderEncoding
            // 
            this.cmbHeaderEncoding.FormattingEnabled = true;
            this.cmbHeaderEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cmbHeaderEncoding.Location = new System.Drawing.Point(168, 46);
            this.cmbHeaderEncoding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbHeaderEncoding.Name = "cmbHeaderEncoding";
            this.cmbHeaderEncoding.Size = new System.Drawing.Size(267, 24);
            this.cmbHeaderEncoding.TabIndex = 6;
            this.cmbHeaderEncoding.Text = "ASCII";
            // 
            // cmbBodyEncoding
            // 
            this.cmbBodyEncoding.FormattingEnabled = true;
            this.cmbBodyEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cmbBodyEncoding.Location = new System.Drawing.Point(168, 16);
            this.cmbBodyEncoding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBodyEncoding.Name = "cmbBodyEncoding";
            this.cmbBodyEncoding.Size = new System.Drawing.Size(267, 24);
            this.cmbBodyEncoding.TabIndex = 4;
            this.cmbBodyEncoding.Text = "ASCII";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subject Encoding:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Headers Encoding:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Body Encoding:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(261, 279);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 279);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numUpDnSendTimeOut);
            this.groupBox2.Controls.Add(this.chkReadRcpt);
            this.groupBox2.Controls.Add(this.chkBodyHtml);
            this.groupBox2.Location = new System.Drawing.Point(16, 137);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(452, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Send Timeout";
            // 
            // numUpDnSendTimeOut
            // 
            this.numUpDnSendTimeOut.Location = new System.Drawing.Point(360, 22);
            this.numUpDnSendTimeOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numUpDnSendTimeOut.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUpDnSendTimeOut.Name = "numUpDnSendTimeOut";
            this.numUpDnSendTimeOut.Size = new System.Drawing.Size(76, 22);
            this.numUpDnSendTimeOut.TabIndex = 3;
            this.numUpDnSendTimeOut.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkReadRcpt
            // 
            this.chkReadRcpt.AutoSize = true;
            this.chkReadRcpt.Location = new System.Drawing.Point(127, 23);
            this.chkReadRcpt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkReadRcpt.Name = "chkReadRcpt";
            this.chkReadRcpt.Size = new System.Drawing.Size(110, 20);
            this.chkReadRcpt.TabIndex = 1;
            this.chkReadRcpt.Text = "Read Receipt";
            this.chkReadRcpt.UseVisualStyleBackColor = true;
            // 
            // chkBodyHtml
            // 
            this.chkBodyHtml.AutoSize = true;
            this.chkBodyHtml.Location = new System.Drawing.Point(8, 23);
            this.chkBodyHtml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBodyHtml.Name = "chkBodyHtml";
            this.chkBodyHtml.Size = new System.Drawing.Size(98, 20);
            this.chkBodyHtml.TabIndex = 0;
            this.chkBodyHtml.Text = "Body HTML";
            this.chkBodyHtml.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbMsgPriority);
            this.groupBox3.Location = new System.Drawing.Point(253, 213);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(215, 59);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Priority";
            // 
            // cmbMsgPriority
            // 
            this.cmbMsgPriority.FormattingEnabled = true;
            this.cmbMsgPriority.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.cmbMsgPriority.Location = new System.Drawing.Point(8, 21);
            this.cmbMsgPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMsgPriority.Name = "cmbMsgPriority";
            this.cmbMsgPriority.Size = new System.Drawing.Size(189, 24);
            this.cmbMsgPriority.TabIndex = 0;
            this.cmbMsgPriority.Text = "Normal";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkOnSuccess);
            this.groupBox4.Controls.Add(this.chkOnFailure);
            this.groupBox4.Location = new System.Drawing.Point(16, 213);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(229, 59);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delivery Notifications";
            // 
            // chkOnSuccess
            // 
            this.chkOnSuccess.AutoSize = true;
            this.chkOnSuccess.Location = new System.Drawing.Point(111, 23);
            this.chkOnSuccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOnSuccess.Name = "chkOnSuccess";
            this.chkOnSuccess.Size = new System.Drawing.Size(95, 20);
            this.chkOnSuccess.TabIndex = 4;
            this.chkOnSuccess.Text = "OnSuccess";
            this.chkOnSuccess.UseVisualStyleBackColor = true;
            // 
            // chkOnFailure
            // 
            this.chkOnFailure.AutoSize = true;
            this.chkOnFailure.Location = new System.Drawing.Point(8, 23);
            this.chkOnFailure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOnFailure.Name = "chkOnFailure";
            this.chkOnFailure.Size = new System.Drawing.Size(84, 20);
            this.chkOnFailure.TabIndex = 3;
            this.chkOnFailure.Text = "OnFailure";
            this.chkOnFailure.UseVisualStyleBackColor = true;
            // 
            // FrmMessageOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 322);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Options";
            this.Load += new System.EventHandler(this.FrmMessageOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSendTimeOut)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSubjectEncoding;
        private System.Windows.Forms.ComboBox cmbHeaderEncoding;
        private System.Windows.Forms.ComboBox cmbBodyEncoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkReadRcpt;
        private System.Windows.Forms.CheckBox chkBodyHtml;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbMsgPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDnSendTimeOut;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkOnSuccess;
        private System.Windows.Forms.CheckBox chkOnFailure;
    }
}