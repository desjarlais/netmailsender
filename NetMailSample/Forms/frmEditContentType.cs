using System;
using System.Net.Mime;
using System.Windows.Forms;

namespace NetMailSample.Forms
{
    public partial class frmEditContentType : Form
    {
        public string newContentType, newCid;
        public string origContentType, origCid;
        public bool isInline, isCancelled;

        /// <summary>
        /// form constructor
        /// </summary>
        /// <param name="contentType">this is the original value of the attachment content type</param>
        /// <param name="altView">this determines if this form was opened from the main form or the altview</param>
        public frmEditContentType(string contentType, string cid, string isImageInline)
        {
            InitializeComponent();
            origContentType = contentType;
            origCid = cid;
            if (isImageInline == "True")
            {
                cboInline.Checked = true;
            }
            else
            {
                cboInline.Checked = false;
            }

            txtCid.Text = cid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            newContentType = Common.FileUtilities.GetContentType(cboContentType.Text);
            if (cboInline.Checked)
            {
                isInline = true;
                newCid = txtCid.Text;
                Properties.Settings.Default.BodyHtml = true;
            }
            else
            {
                isInline = false;
            }
            this.Close();
        }

        /// <summary>
        /// if we cancel the form, we need to return the original value to the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            newContentType = Common.FileUtilities.GetContentType(origContentType);
            isCancelled = true;
            this.Close();
        }

        private void cboInline_CheckedChanged(object sender, EventArgs e)
        {
            if (cboInline.Checked)
            {
                txtCid.Enabled = true;
            }
            else
            {
                txtCid.Enabled = false;
            }
        }
    }
}
