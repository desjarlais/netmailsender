using System;
using System.Windows.Forms;

/// <summary>
/// This displays the message options dialog/form
/// </summary>
namespace NetMailSample.Forms
{
    public partial class FrmMessageOptions : Form
    {
        public string enBody, enBodyTransfer, enSubject, enHeaders;
        
        public FrmMessageOptions()
        {
            InitializeComponent();
            try
            {
                // set the individual options for the form based on the app settings
                if (Properties.Settings.Default.BodyHtml == true) { chkBodyHtml.Checked = true; }
                if (Properties.Settings.Default.ReadRcpt == true) { chkReadRcpt.Checked = true; }
                if (Properties.Settings.Default.DelNotifOnSuccess == true) { chkOnSuccess.Checked = true; }
                if (Properties.Settings.Default.DelNotifOnFailure == true) { chkOnFailure.Checked = true; }

                switch (Properties.Settings.Default.MsgPriority)
                {
                    case "High":
                        cmbMsgPriority.Text = "High";
                        break;
                    case "Low":
                        cmbMsgPriority.Text = "Low";
                        break;
                    default:
                        cmbMsgPriority.Text = "Normal";
                        break;
                }

                cmbBodyEncoding.Text = Properties.Settings.Default.BodyEncoding;
                cmbHeaderEncoding.Text = Properties.Settings.Default.HeaderEncoding;
                cmbSubjectEncoding.Text = Properties.Settings.Default.SubjectEncoding;
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// set the encoding variables to the user provided data
        /// this will get added when the message is actually sent from the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BodyEncoding = cmbBodyEncoding.Text;
            Properties.Settings.Default.HeaderEncoding = cmbHeaderEncoding.Text;
            Properties.Settings.Default.SubjectEncoding = cmbSubjectEncoding.Text;
            Properties.Settings.Default.BodyHtml = chkBodyHtml.Checked;
            Properties.Settings.Default.ReadRcpt = chkReadRcpt.Checked;
            Properties.Settings.Default.MsgPriority = cmbMsgPriority.Text;
            Properties.Settings.Default.DelNotifOnFailure = chkOnFailure.Checked;
            Properties.Settings.Default.DelNotifOnSuccess = chkOnSuccess.Checked;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
