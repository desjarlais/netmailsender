namespace NetMailSample.Forms
{
    partial class FrmOAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOAuth));
            this.lnkLabelRegisterApp = new System.Windows.Forms.LinkLabel();
            this.lblClientAppID = new System.Windows.Forms.Label();
            this.lblTenantID = new System.Windows.Forms.Label();
            this.lblRedirectURL = new System.Windows.Forms.Label();
            this.txtBoxAppID = new System.Windows.Forms.TextBox();
            this.txtBoxTenantID = new System.Windows.Forms.TextBox();
            this.txtBoxRedirectURI = new System.Windows.Forms.TextBox();
            this.btnGetToken = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rchTextBoxOauthAnounce = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lnkLabelRegisterApp
            // 
            this.lnkLabelRegisterApp.AutoSize = true;
            this.lnkLabelRegisterApp.Location = new System.Drawing.Point(46, 53);
            this.lnkLabelRegisterApp.Name = "lnkLabelRegisterApp";
            this.lnkLabelRegisterApp.Size = new System.Drawing.Size(257, 13);
            this.lnkLabelRegisterApp.TabIndex = 0;
            this.lnkLabelRegisterApp.TabStop = true;
            this.lnkLabelRegisterApp.Text = "You have to register app to Azure AD for your tenant.";
            this.lnkLabelRegisterApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblClientAppID
            // 
            this.lblClientAppID.AutoSize = true;
            this.lblClientAppID.Location = new System.Drawing.Point(21, 92);
            this.lblClientAppID.Name = "lblClientAppID";
            this.lblClientAppID.Size = new System.Drawing.Size(110, 13);
            this.lblClientAppID.TabIndex = 1;
            this.lblClientAppID.Text = "Application (client) ID:";
            // 
            // lblTenantID
            // 
            this.lblTenantID.AutoSize = true;
            this.lblTenantID.Location = new System.Drawing.Point(21, 119);
            this.lblTenantID.Name = "lblTenantID";
            this.lblTenantID.Size = new System.Drawing.Size(105, 13);
            this.lblTenantID.TabIndex = 2;
            this.lblTenantID.Text = "Directory (tenant) ID:";
            // 
            // lblRedirectURL
            // 
            this.lblRedirectURL.AutoSize = true;
            this.lblRedirectURL.Location = new System.Drawing.Point(21, 143);
            this.lblRedirectURL.Name = "lblRedirectURL";
            this.lblRedirectURL.Size = new System.Drawing.Size(75, 13);
            this.lblRedirectURL.TabIndex = 3;
            this.lblRedirectURL.Text = "Redirect URL:";
            // 
            // txtBoxAppID
            // 
            this.txtBoxAppID.Location = new System.Drawing.Point(132, 86);
            this.txtBoxAppID.Name = "txtBoxAppID";
            this.txtBoxAppID.Size = new System.Drawing.Size(206, 20);
            this.txtBoxAppID.TabIndex = 4;
            // 
            // txtBoxTenantID
            // 
            this.txtBoxTenantID.Location = new System.Drawing.Point(132, 112);
            this.txtBoxTenantID.Name = "txtBoxTenantID";
            this.txtBoxTenantID.Size = new System.Drawing.Size(206, 20);
            this.txtBoxTenantID.TabIndex = 5;
            // 
            // txtBoxRedirectURI
            // 
            this.txtBoxRedirectURI.Enabled = false;
            this.txtBoxRedirectURI.Location = new System.Drawing.Point(132, 138);
            this.txtBoxRedirectURI.Name = "txtBoxRedirectURI";
            this.txtBoxRedirectURI.Size = new System.Drawing.Size(206, 20);
            this.txtBoxRedirectURI.TabIndex = 6;
            this.txtBoxRedirectURI.Text = "https://127.0.0.1/auth-response";
            // 
            // btnGetToken
            // 
            this.btnGetToken.Location = new System.Drawing.Point(263, 162);
            this.btnGetToken.Name = "btnGetToken";
            this.btnGetToken.Size = new System.Drawing.Size(75, 23);
            this.btnGetToken.TabIndex = 7;
            this.btnGetToken.Text = "Get Token";
            this.btnGetToken.UseVisualStyleBackColor = true;
            this.btnGetToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // rchTextBoxOauthAnounce
            // 
            this.rchTextBoxOauthAnounce.Enabled = false;
            this.rchTextBoxOauthAnounce.Location = new System.Drawing.Point(24, 13);
            this.rchTextBoxOauthAnounce.Name = "rchTextBoxOauthAnounce";
            this.rchTextBoxOauthAnounce.Size = new System.Drawing.Size(314, 37);
            this.rchTextBoxOauthAnounce.TabIndex = 8;
            this.rchTextBoxOauthAnounce.Text = ".Net Net.Mail library is not supporting OAUTH. Oauth functionality added with Mai" +
    "lKit and MimeKit GitHub libraries.";
            // 
            // FrmOAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 194);
            this.Controls.Add(this.rchTextBoxOauthAnounce);
            this.Controls.Add(this.btnGetToken);
            this.Controls.Add(this.txtBoxRedirectURI);
            this.Controls.Add(this.txtBoxTenantID);
            this.Controls.Add(this.txtBoxAppID);
            this.Controls.Add(this.lblRedirectURL);
            this.Controls.Add(this.lblTenantID);
            this.Controls.Add(this.lblClientAppID);
            this.Controls.Add(this.lnkLabelRegisterApp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OAuth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkLabelRegisterApp;
        private System.Windows.Forms.Label lblClientAppID;
        private System.Windows.Forms.Label lblTenantID;
        private System.Windows.Forms.Label lblRedirectURL;
        private System.Windows.Forms.TextBox txtBoxAppID;
        private System.Windows.Forms.TextBox txtBoxTenantID;
        private System.Windows.Forms.TextBox txtBoxRedirectURI;
        private System.Windows.Forms.Button btnGetToken;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox rchTextBoxOauthAnounce;
    }
}