using System;
using System.Windows.Forms;

/// <summary>
/// This form allows adding message headers to the message
/// </summary>
namespace NetMailSample.Forms
{
    public partial class FrmAddHeaders : Form
    {
        public FrmAddHeaders()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// if the header and value both have data, then we can add that to the 
        /// data grid on the main form, otherwise just close out of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtValue.Text != "")
            {
                FrmMain f = Owner as FrmMain;
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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave.PerformClick();
            }
        }
    }
}
