/****************************** Module Header ******************************\
Module Name:  FrmAbout.cs
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
