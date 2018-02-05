using System;
using System.Windows.Forms;
using System.Diagnostics;

/// <summary>
/// This form is the File | About dialog 
/// </summary>
namespace NetMailSample.Forms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// populate the hyperlink for the website on load of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = "NetMail Sender Website";
            linkLabel1.Links.Add(0, 22, "http://github.com/desjarlais/netmailsender");
            lblVersion.Text = Application.ProductVersion.ToString();
        }

        /// <summary>
        /// process the user clicking the hyperlink in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
