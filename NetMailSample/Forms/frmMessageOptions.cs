using System;
using System.Windows.Forms;

namespace NetMailSample.Forms
{
    public partial class frmMessageOptions : Form
    {
        public string enBody, enBodyTransfer, enSubject, enHeaders;
        
        public frmMessageOptions()
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
                        cboMsgPriority.Text = "High";
                        break;
                    case "Low":
                        cboMsgPriority.Text = "Low";
                        break;
                    default:
                        cboMsgPriority.Text = "Normal";
                        break;
                }

                cboBodyEncoding.Text = Properties.Settings.Default.BodyEncoding;
                cboHeaderEncoding.Text = Properties.Settings.Default.HeaderEncoding;
                cboSubjectEncoding.Text = Properties.Settings.Default.SubjectEncoding;
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BodyEncoding = cboBodyEncoding.Text;
            Properties.Settings.Default.HeaderEncoding = cboHeaderEncoding.Text;
            Properties.Settings.Default.SubjectEncoding = cboSubjectEncoding.Text;
            Properties.Settings.Default.BodyHtml = chkBodyHtml.Checked;
            Properties.Settings.Default.ReadRcpt = chkReadRcpt.Checked;
            Properties.Settings.Default.MsgPriority = cboMsgPriority.Text;
            Properties.Settings.Default.DelNotifOnFailure = chkOnFailure.Checked;
            Properties.Settings.Default.DelNotifOnSuccess = chkOnSuccess.Checked;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
