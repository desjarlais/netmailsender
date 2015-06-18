using System;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace NetMailSample.Forms
{
    public partial class frmAlternateView : Form
    {
        public string cid, cidPath, tempSubject, cellEdit;
        public DataTable inlineTable = new DataTable();

        /// <summary>
        /// form constructor, sets the initial tab control values
        /// </summary>
        public frmAlternateView()
        {
            InitializeComponent();
            cboTransferEncoding.Text = Properties.Settings.Default.htmlBodyTransferEncoding;
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
        private void btnAddAlternateViews_Click(object sender, EventArgs e)
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
                Properties.Settings.Default.vCalBodyTransferEncoding = cboTransferEncoding.Text;
            }

            if (txtHTMLAltViewBody.Text != null)
            {
                Properties.Settings.Default.AltViewHtml = txtHTMLAltViewBody.Text;
                Properties.Settings.Default.htmlBodyTransferEncoding = cboTransferEncoding.Text;
                AddInlineTableForAttachments();
            }

            if (txtPlainAltViewBody.Text != null)
            {
                Properties.Settings.Default.AltViewPlain = txtPlainAltViewBody.Text;
                Properties.Settings.Default.plainBodyTransferEncoding = cboTransferEncoding.Text;
            }

            this.Close();
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
                    inlineTable.Rows.Add(rowAtt.Cells[0].Value, rowAtt.Cells[1].Value, rowAtt.Cells[2].Value);
                }
            }
        }

        /// <summary>
        /// user cancelled the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// simple open file dialog to capture the file path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkedResBrowse_Click(object sender, EventArgs e)
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
        private void btnAddLR_Click(object sender, EventArgs e)
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
        /// check for the current location in the grid and delete the row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            try
            { 
                int cellRow = dGridInlineAttachments.CurrentCellAddress.Y;
                if (dGridInlineAttachments.CurrentCell.ColumnIndex >= 0) 
                { 
                    dGridInlineAttachments.Rows.RemoveAt(dGridInlineAttachments.Rows[cellRow].Index); 
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        /// <summary>
        /// this button will display a vCalendar sample in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalSample_Click(object sender, EventArgs e)
        {
            cboAltViewContentType.Text = "vCalendar";
            cboTransferEncoding.Text = "QuotedPrintable";

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
        private void btnConvertEncoding_Click(object sender, EventArgs e)
        {
            if (txtCalendarAltViewBody.Text != "" && tabControl1.SelectedTab == tabCalendar)
            {
                try
                {
                    byte[] encodedBytes = Convert.FromBase64String(txtCalendarAltViewBody.Text);
                    string result = Encoding.UTF8.GetString(encodedBytes);
                    txtCalendarAltViewBody.Text = result;
                    cboTransferEncoding.Text = "QuotedPrintable";
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
        private void btnInsertHTML_Click(object sender, EventArgs e)
        {
            cboAltViewContentType.Text = "HTML";
            cboTransferEncoding.Text = "QuotedPrintable";

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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Plain")
            {
                cboAltViewContentType.Text = "Plain Text";
            }
            else if (tabControl1.SelectedTab.Text == "Calendar")
            {
                cboAltViewContentType.Text = "vCalendar";
            }
            else
            {
                cboAltViewContentType.Text = "HTML";
            }
        }

        /// <summary>
        /// Encode the altview body text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncodeText_Click(object sender, EventArgs e)
        {
            if (txtCalendarAltViewBody.Text != "" && tabControl1.SelectedTab == tabCalendar)
            {
                txtCalendarAltViewBody.Text = EncodeBodyToBase64(txtCalendarAltViewBody.Text);
                cboTransferEncoding.Text = "Base64";
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

        private void editContentIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = dGridInlineAttachments.CurrentCellAddress.Y;
            dGridInlineAttachments.CurrentCell = dGridInlineAttachments.Rows[n].Cells[1];
            dGridInlineAttachments.BeginEdit(true);
        }
        
        private void deleteAttachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = dGridInlineAttachments.CurrentCellAddress.Y;
            dGridInlineAttachments.Rows.RemoveAt(dGridInlineAttachments.Rows[n].Index);
        }

        private void dGridInlineAttachments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dGridInlineAttachments.CurrentCell = dGridInlineAttachments[e.ColumnIndex, e.RowIndex];
            }
        }

        private void dGridInlineAttachments_CellClick(object sender, DataGridViewCellEventArgs e)
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
