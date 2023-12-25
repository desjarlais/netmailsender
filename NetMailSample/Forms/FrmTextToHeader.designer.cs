namespace NetMailSample.Forms
{
    partial class FrmTextToHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTextToHeader));
            this.BtnProcessAsHeader = new System.Windows.Forms.Button();
            this.rchBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BtnProcessAsHeader
            // 
            this.BtnProcessAsHeader.Location = new System.Drawing.Point(560, 592);
            this.BtnProcessAsHeader.Name = "BtnProcessAsHeader";
            this.BtnProcessAsHeader.Size = new System.Drawing.Size(109, 32);
            this.BtnProcessAsHeader.TabIndex = 0;
            this.BtnProcessAsHeader.Text = "Process As Header";
            this.BtnProcessAsHeader.UseVisualStyleBackColor = true;
            this.BtnProcessAsHeader.Click += new System.EventHandler(this.BtnProcessAsHeader_Click);
            // 
            // rchBox
            // 
            this.rchBox.Location = new System.Drawing.Point(12, 12);
            this.rchBox.Name = "rchBox";
            this.rchBox.Size = new System.Drawing.Size(657, 574);
            this.rchBox.TabIndex = 2;
            this.rchBox.Text = "";
            // 
            // FrmTextToHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 636);
            this.Controls.Add(this.rchBox);
            this.Controls.Add(this.BtnProcessAsHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTextToHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTextToHeader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnProcessAsHeader;
        private System.Windows.Forms.RichTextBox rchBox;
    }
}