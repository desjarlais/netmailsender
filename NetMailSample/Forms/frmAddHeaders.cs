using System;
using System.Windows.Forms;

namespace NetMailSample.Forms
{
    public partial class frmAddHeaders : Form
    {
        public frmAddHeaders()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// if the header and value both have data, then we can add that to the 
        /// data grid on the main form, otherwise just close out of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtValue.Text != "")
            {
                frmMain f = Owner as frmMain;
                f.hdrName = txtName.Text;
                f.hdrValue = txtValue.Text;
            }
            Close();
        }

        /// <summary>
        /// user cancelled form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave.PerformClick();
            }
        }
    }
}
