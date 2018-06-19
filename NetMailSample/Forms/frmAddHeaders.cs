/****************************** Module Header ******************************\
Module Name:  FrmAddHeaders.cs
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
