using MailKit.Security;
using NetMailSample.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetMailSample.Forms
{
    public partial class FrmOAuth : Form
    {
        public FrmOAuth()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://learn.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app");
        }

        private async void btnGetToken_Click(object sender, EventArgs e)
        {
            FrmMain f = Owner as FrmMain;
            f.oauthToken = await OAuth.OAuthToken(txtBoxAppID.Text, txtBoxTenantID.Text);
            Close();
                      
        }

    }
}
