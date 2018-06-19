/****************************** Module Header ******************************\
Module Name:  FrmMessageOptions.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

This contains functions for dealing with the file attachments

The MIT License (MIT)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
\***************************************************************************/

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
