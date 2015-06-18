namespace NetMailSample.Forms
{
    partial class frmMessageOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageOptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSubjectEncoding = new System.Windows.Forms.ComboBox();
            this.cboHeaderEncoding = new System.Windows.Forms.ComboBox();
            this.cboBodyEncoding = new System.Windows.Forms.ComboBox();
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
            this.cboMsgPriority = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Controls.Add(this.cboSubjectEncoding);
            this.groupBox1.Controls.Add(this.cboHeaderEncoding);
            this.groupBox1.Controls.Add(this.cboBodyEncoding);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encoding";
            // 
            // cboSubjectEncoding
            // 
            this.cboSubjectEncoding.FormattingEnabled = true;
            this.cboSubjectEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cboSubjectEncoding.Location = new System.Drawing.Point(126, 63);
            this.cboSubjectEncoding.Name = "cboSubjectEncoding";
            this.cboSubjectEncoding.Size = new System.Drawing.Size(201, 21);
            this.cboSubjectEncoding.TabIndex = 7;
            this.cboSubjectEncoding.Text = "ASCII";
            // 
            // cboHeaderEncoding
            // 
            this.cboHeaderEncoding.FormattingEnabled = true;
            this.cboHeaderEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cboHeaderEncoding.Location = new System.Drawing.Point(126, 37);
            this.cboHeaderEncoding.Name = "cboHeaderEncoding";
            this.cboHeaderEncoding.Size = new System.Drawing.Size(201, 21);
            this.cboHeaderEncoding.TabIndex = 6;
            this.cboHeaderEncoding.Text = "ASCII";
            // 
            // cboBodyEncoding
            // 
            this.cboBodyEncoding.FormattingEnabled = true;
            this.cboBodyEncoding.Items.AddRange(new object[] {
            "ACSII",
            "Unicode",
            "UTF32",
            "UTF7",
            "UTF8",
            "Default"});
            this.cboBodyEncoding.Location = new System.Drawing.Point(126, 13);
            this.cboBodyEncoding.Name = "cboBodyEncoding";
            this.cboBodyEncoding.Size = new System.Drawing.Size(201, 21);
            this.cboBodyEncoding.TabIndex = 4;
            this.cboBodyEncoding.Text = "ASCII";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subject Encoding:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Headers Encoding:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Body Encoding:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numUpDnSendTimeOut);
            this.groupBox2.Controls.Add(this.chkReadRcpt);
            this.groupBox2.Controls.Add(this.chkBodyHtml);
            this.groupBox2.Location = new System.Drawing.Point(12, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 51);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Send Timeout";
            // 
            // numUpDnSendTimeOut
            // 
            this.numUpDnSendTimeOut.Location = new System.Drawing.Point(270, 18);
            this.numUpDnSendTimeOut.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUpDnSendTimeOut.Name = "numUpDnSendTimeOut";
            this.numUpDnSendTimeOut.Size = new System.Drawing.Size(57, 20);
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
            this.chkReadRcpt.Location = new System.Drawing.Point(95, 19);
            this.chkReadRcpt.Name = "chkReadRcpt";
            this.chkReadRcpt.Size = new System.Drawing.Size(92, 17);
            this.chkReadRcpt.TabIndex = 1;
            this.chkReadRcpt.Text = "Read Receipt";
            this.chkReadRcpt.UseVisualStyleBackColor = true;
            // 
            // chkBodyHtml
            // 
            this.chkBodyHtml.AutoSize = true;
            this.chkBodyHtml.Location = new System.Drawing.Point(6, 19);
            this.chkBodyHtml.Name = "chkBodyHtml";
            this.chkBodyHtml.Size = new System.Drawing.Size(83, 17);
            this.chkBodyHtml.TabIndex = 0;
            this.chkBodyHtml.Text = "Body HTML";
            this.chkBodyHtml.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboMsgPriority);
            this.groupBox3.Location = new System.Drawing.Point(190, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Priority";
            // 
            // cboMsgPriority
            // 
            this.cboMsgPriority.FormattingEnabled = true;
            this.cboMsgPriority.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.cboMsgPriority.Location = new System.Drawing.Point(6, 17);
            this.cboMsgPriority.Name = "cboMsgPriority";
            this.cboMsgPriority.Size = new System.Drawing.Size(143, 21);
            this.cboMsgPriority.TabIndex = 0;
            this.cboMsgPriority.Text = "Normal";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkOnSuccess);
            this.groupBox4.Controls.Add(this.chkOnFailure);
            this.groupBox4.Location = new System.Drawing.Point(12, 173);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 48);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delivery Notifications";
            // 
            // chkOnSuccess
            // 
            this.chkOnSuccess.AutoSize = true;
            this.chkOnSuccess.Location = new System.Drawing.Point(83, 19);
            this.chkOnSuccess.Name = "chkOnSuccess";
            this.chkOnSuccess.Size = new System.Drawing.Size(81, 17);
            this.chkOnSuccess.TabIndex = 4;
            this.chkOnSuccess.Text = "OnSuccess";
            this.chkOnSuccess.UseVisualStyleBackColor = true;
            // 
            // chkOnFailure
            // 
            this.chkOnFailure.AutoSize = true;
            this.chkOnFailure.Location = new System.Drawing.Point(6, 19);
            this.chkOnFailure.Name = "chkOnFailure";
            this.chkOnFailure.Size = new System.Drawing.Size(71, 17);
            this.chkOnFailure.TabIndex = 3;
            this.chkOnFailure.Text = "OnFailure";
            this.chkOnFailure.UseVisualStyleBackColor = true;
            // 
            // frmMessageOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Options";
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
        private System.Windows.Forms.ComboBox cboSubjectEncoding;
        private System.Windows.Forms.ComboBox cboHeaderEncoding;
        private System.Windows.Forms.ComboBox cboBodyEncoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkReadRcpt;
        private System.Windows.Forms.CheckBox chkBodyHtml;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMsgPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDnSendTimeOut;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkOnSuccess;
        private System.Windows.Forms.CheckBox chkOnFailure;
    }
}