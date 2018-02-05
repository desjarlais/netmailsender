using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Use this form to handle adding alt views to the message
/// </summary>
namespace NetMailSample.Forms
{
    public partial class FrmAlternateView : Form
    {
        public string cid, cidPath, tempSubject, cellEdit;
        public DataTable inlineTable = new DataTable();

        /// <summary>
        /// form constructor, sets the initial tab control values
        /// </summary>
        public FrmAlternateView()
        {
            InitializeComponent();
            cmbTransferEncoding.Text = Properties.Settings.Default.htmlBodyTransferEncoding;
            txtCalendarAltViewBody.Text = Properties.Settings.Default.AltViewCal;
            txtHTMLAltViewBody.Text = Properties.Settings.Default.AltViewHtml;
            txtPlainAltViewBody.Text = Properties.Settings.Default.AltViewPlain;
        }

        /// <summary>
        /// This button adds the html, vCal and plain text Alt Views to 
        /// the main forms string values, which will get added when the message is sent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddAlternateViews_Click(object sender, EventArgs e)
        {
            if (txtCalendarAltViewBody.Text != null)
            {
                StringBuilder sb = new StringBuilder();
                string[] lines = txtCalendarAltViewBody.Lines;

                for (int i = 0; i < lines.GetUpperBound(0); i++)
                {
                    sb.AppendLine((lines[i]));
                }

                Properties.Settings.Default.AltViewCal = sb.ToString();
                Properties.Settings.Default.vCalBodyTransferEncoding = cmbTransferEncoding.Text;
            }

            if (txtHTMLAltViewBody.Text != null)
            {
                Properties.Settings.Default.AltViewHtml = txtHTMLAltViewBody.Text;
                Properties.Settings.Default.htmlBodyTransferEncoding = cmbTransferEncoding.Text;
                AddInlineTableForAttachments();
            }

            if (txtPlainAltViewBody.Text != null)
            {
                Properties.Settings.Default.AltViewPlain = txtPlainAltViewBody.Text;
                Properties.Settings.Default.plainBodyTransferEncoding = cmbTransferEncoding.Text;
            }

            Close();
        }

        /// <summary>
        /// add attachment to the grid
        /// </summary>
        private void AddInlineTableForAttachments()
        {
            inlineTable.Columns.Add("Path", typeof(string));
            inlineTable.Columns.Add("Cid", typeof(string));
            inlineTable.Columns.Add("ContentType", typeof(string));

            foreach (DataGridViewRow rowAtt in dGridInlineAttachments.Rows)
            {
                if (rowAtt.Cells[0].Value != null)
                {
                    inlineTable.Rows.Add(rowAtt.Cells[0].Value, rowAtt.Cells[1].Value, Common.FileUtilities.GetContentType(rowAtt.Cells[2].Value.ToString()));
                }
            }
        }

        /// <summary>
        /// user cancelled the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// simple open file dialog to capture the file path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLinkedResBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLinkedResPath.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// adds the linked resource / embedded file to the altview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddLR_Click(object sender, EventArgs e)
        {
            if (txtLinkedResPath.Text != "" && txtCid.Text != "")
            {
                int n = dGridInlineAttachments.Rows.Add();
                dGridInlineAttachments.Rows[n].Cells[0].Value = txtLinkedResPath.Text;
                dGridInlineAttachments.Rows[n].Cells[1].Value = txtCid.Text;
                dGridInlineAttachments.Rows[n].Cells[2].Value = "Octet";
                txtLinkedResPath.Text = "";
                txtCid.Text = "";
                Properties.Settings.Default.BodyHtml = true;
            }
            else
            {
                MessageBox.Show("Path and Content Id are required to add a linked resource.",
                "Invalid Linked Resource", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// this button will display a vCalendar sample in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalSample_Click(object sender, EventArgs e)
        {
            cmbAltViewContentType.Text = "vCalendar";
            cmbTransferEncoding.Text = "QuotedPrintable";

            DateTime dtStart = DateTime.Now.AddHours(1);
            DateTime dtEnd = DateTime.Now.AddHours(2);
            string msgBody = "Test Message Body";
            string msgSubject = "Test Subject";
            string msgTo = "ToEmail@email.com";
            string msgFrom = "FromEmail@email.com";
            string msgDispName = "FName LName";

            StringBuilder sbCal = new StringBuilder();
            sbCal.Append("BEGIN:VCALENDAR\r\n");
            sbCal.Append("METHOD:REQUEST\r\n");
            sbCal.Append("STATUS:CONFIRMED\r\n");
            sbCal.Append("BEGIN:VEVENT\r\n");

            sbCal.Append(string.Format("TZID:{0}", "US-Eastern\r\n"));
            sbCal.Append(string.Format("DTSTART:{0:yyyyMMddTHHmmss\r\n}", dtStart));
            sbCal.Append(string.Format("DTEND:{0:yyyyMMddTHHmmss\r\n}", dtEnd));
            sbCal.Append(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss\r\n}", DateTime.Now));

            sbCal.Append(string.Format("UID:{0}\r\n", Guid.NewGuid()));
            sbCal.Append(string.Format("DESCRIPTION:{0}\r\n", msgBody));
            sbCal.Append(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}\r\n", msgBody));
            sbCal.Append(string.Format("SUMMARY:{0}\r\n", msgSubject));
            sbCal.Append(string.Format("ORGANIZER:MAILTO:{0}\r\n", msgFrom));

            sbCal.Append(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}\r\n", msgDispName, msgTo));
            sbCal.Append("END:VEVENT\r\n");
            sbCal.Append("END:VCALENDAR\r\n");
            
            txtCalendarAltViewBody.Text = sbCal.ToString();
            tabControl1.SelectedTab = tabCalendar;
        }

        /// <summary>
        /// decode the alt view body 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertEncoding_Click(object sender, EventArgs e)
        {
            if (txtCalendarAltViewBody.Text != "" && tabControl1.SelectedTab == tabCalendar)
            {
                try
                {
                    byte[] encodedBytes = Convert.FromBase64String(txtCalendarAltViewBody.Text);
                    string result = Encoding.UTF8.GetString(encodedBytes);
                    txtCalendarAltViewBody.Text = result;
                    cmbTransferEncoding.Text = "QuotedPrintable";
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Insert a sample HTML body
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInsertHTML_Click(object sender, EventArgs e)
        {
            cmbAltViewContentType.Text = "HTML";
            cmbTransferEncoding.Text = "QuotedPrintable";

            string body = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
            body += "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\">";
            body += "</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>this is some HTML text";
            body += "</FONT></DIV></BODY></HTML>";

            txtHTMLAltViewBody.Text = body;
            tabControl1.SelectedTab = tabHTML;
        }

        /// <summary>
        /// adjust the content type dropdown based on the selected tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Plain")
            {
                cmbAltViewContentType.Text = "Plain Text";
            }
            else if (tabControl1.SelectedTab.Text == "Calendar")
            {
                cmbAltViewContentType.Text = "vCalendar";
            }
            else
            {
                cmbAltViewContentType.Text = "HTML";
            }
        }

        /// <summary>
        /// Encode the altview body text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEncodeText_Click(object sender, EventArgs e)
        {
            if (txtCalendarAltViewBody.Text != "" && tabControl1.SelectedTab == tabCalendar)
            {
                txtCalendarAltViewBody.Text = EncodeBodyToBase64(txtCalendarAltViewBody.Text);
                cmbTransferEncoding.Text = "Base64";
            }
        }

        /// <summary>
        /// convert the body to a base64 encoded string
        /// </summary>
        /// <param name="sBodyToEncode"></param>
        /// <returns></returns>
        static public string EncodeBodyToBase64(string sBodyToEncode)
        {
            byte[] EncodedBody = ASCIIEncoding.ASCII.GetBytes(sBodyToEncode);
            return Convert.ToBase64String(EncodedBody);
        }

        private void EditContentIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = dGridInlineAttachments.CurrentCellAddress.Y;
            dGridInlineAttachments.CurrentCell = dGridInlineAttachments.Rows[n].Cells[1];
            dGridInlineAttachments.BeginEdit(true);
        }

        /// <summary>
        /// check for the current location in the grid and delete the row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteAltViewAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                int cellRow = dGridInlineAttachments.CurrentCellAddress.Y;
                if (dGridInlineAttachments.CurrentCell.ColumnIndex >= 0)
                {
                    dGridInlineAttachments.Rows.RemoveAt(dGridInlineAttachments.Rows[cellRow].Index);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DeleteAttachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = dGridInlineAttachments.CurrentCellAddress.Y;
            dGridInlineAttachments.Rows.RemoveAt(dGridInlineAttachments.Rows[n].Index);
        }

        private void DGridInlineAttachments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dGridInlineAttachments.CurrentCell = dGridInlineAttachments[e.ColumnIndex, e.RowIndex];
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            
        }

        private void DGridInlineAttachments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int n = dGridInlineAttachments.CurrentCellAddress.Y;
                dGridInlineAttachments.CurrentCell = dGridInlineAttachments.Rows[n].Cells[2];
                dGridInlineAttachments.BeginEdit(true);
            }
        }
    }
}