/****************************** Module Header ******************************\
Module Name:  FrmMain.cs
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
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using NetMailSample.Common;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using MailKit;
using Microsoft.Identity.Client;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Authentication;
using MimeKit.Utils;
using MimeKit.Text;

/// <summary>
/// The main netmailsample form window
/// </summary>
namespace NetMailSample
{
    
    public partial class FrmMain : Form
    {
        public string hdrName, hdrValue, msgSubject, cellEdit;
        DataTable inlineAttachmentsTable = new DataTable();
        AlternateView plainView, htmlView, calView;
        bool continueTimerRun = false;
        bool formValidated = false;
        bool noErrFound = true;
        public AuthenticationResult oauthToken = null;
        ClassLogger logger = null;
        public System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar { get { return this.toolStripProgressBar1; } }

        public void RunAsync(Action action)
        {
            Task.Run(action);
        }




        public FrmMain()
        {
            InitializeComponent();

            // create the logger
            logger = new ClassLogger("NetMailErrors.log");
            logger.LogAdded += new ClassLogger.LoggerEventHandler(_logger_LogAdded);

            // log the .net version
            CheckDotNetVersion();
            txtBoxErrorLog.Clear();
        }

        void _logger_LogAdded(object sender, LoggerEventArgs a)
        {
            try
            {
                if (txtBoxErrorLog.InvokeRequired)
                {
                    // Need to invoke
                    txtBoxErrorLog.Invoke(new MethodInvoker(delegate()
                    {
                        txtBoxErrorLog.Text += "\r\n" + a.LogDetails;
                    }));
                }
                else
                {
                    txtBoxErrorLog.Text += "\r\n" + a.LogDetails;
                }
            }
            catch (Exception ex)
            {
                txtBoxErrorLog.Text += "\r\n" + ex.Message;
            }
        }

        /// <summary>
        /// check/display the version of .NET installed on the machine
        /// </summary>
        void CheckDotNetVersion()
        {
            try
            {
                // check for the installed .NET versions
                logger.Log("The .NET Runtime = " + DotNetVersion.GetRuntimeVersionFromEnvironment());
                logger.Log(DotNetVersion.GetDotNetVerFromRegistry());
                if (DotNetVersion.GetDotNetVerFromRegistry() == "The .NET Framework 4.5 or later NOT detected")
                {
                    logger.Log("Installed versions of the .NET Framework that are: \n");
                    logger.Log(DotNetVersion.GetPreV45FromRegistry());
                }
            }
            catch (Exception ex)
            {
                logger.Log("Error:" + ex.Message);
                logger.Log("Stack Trace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// This method takes the input from the form, creates a mail message and sends it to the smtp server
        /// </summary>
        

        private void SendEmail()
        {

            // make sure we have values in user, password and To
            if (ValidateForm() == false)
            {
                return;
            }

            // create mail, smtp and mailaddress objects
            MailMessage mail = new MailMessage();
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            MailAddressCollection mailAddrCol = new MailAddressCollection();

            try
            {
                // set the From email address information
                mail.From = new MailAddress(textBoxFrom.Text);

                // set the To email address information
                mailAddrCol.Clear();
                logger.Log("Adding To addresses: " + txtBoxTo.Text);
                mailAddrCol.Add(txtBoxTo.Text);
                MessageUtilities.AddSmtpToMailAddressCollection(mail, mailAddrCol, MessageUtilities.AddressType.To);

                // check for Cc and Bcc, which can be empty so we only need to add when the textbox contains a value
                if (txtBoxCC.Text.Trim() != "")
                {
                    mailAddrCol.Clear();
                    logger.Log("Adding Cc addresses: " + txtBoxCC.Text);
                    mailAddrCol.Add(txtBoxCC.Text);
                    MessageUtilities.AddSmtpToMailAddressCollection(mail, mailAddrCol, MessageUtilities.AddressType.Cc);
                }

                if (txtBoxBCC.Text.Trim() != "")
                {
                    mailAddrCol.Clear();
                    logger.Log("Adding Bcc addresses: " + txtBoxBCC.Text);
                    mailAddrCol.Add(txtBoxBCC.Text);
                    MessageUtilities.AddSmtpToMailAddressCollection(mail, mailAddrCol, MessageUtilities.AddressType.Bcc);
                }

                // set encoding for message
                // The value specified for the BodyEncoding property sets the character set field in the Content-Type header.
                // The default character set is "us-ascii".
                if (Properties.Settings.Default.BodyEncoding != "")
                {
                    mail.BodyEncoding = MessageUtilities.GetEncodingValue(Properties.Settings.Default.BodyEncoding);
                }
                if (Properties.Settings.Default.SubjectEncoding != "")
                {
                    mail.SubjectEncoding = MessageUtilities.GetEncodingValue(Properties.Settings.Default.SubjectEncoding);
                }
                if (Properties.Settings.Default.HeaderEncoding != "")
                {
                    mail.HeadersEncoding = MessageUtilities.GetEncodingValue(Properties.Settings.Default.HeaderEncoding);
                }

                // set priority for the message
                switch (Properties.Settings.Default.MsgPriority)
                {
                    case "High":
                        mail.Priority = MailPriority.High;
                        break;
                    case "Low":
                        mail.Priority = MailPriority.Low;
                        break;
                    default:
                        mail.Priority = MailPriority.Normal;
                        break;
                }

                // add HTML AltView
                if (Properties.Settings.Default.AltViewHtml != "")
                {
                    System.Net.Mime.ContentType ctHtml = new System.Net.Mime.ContentType("text/html");
                    htmlView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewHtml, ctHtml);

                    // add inline attachments / linked resource
                    if (inlineAttachmentsTable.Rows.Count > 0)
                    {
                        foreach (DataRow rowInl in inlineAttachmentsTable.Rows)
                        {
                            LinkedResource lr = new LinkedResource(rowInl.ItemArray[0].ToString())
                            {
                                ContentId = rowInl.ItemArray[1].ToString()
                            };
                            lr.ContentType.MediaType = rowInl.ItemArray[2].ToString();
                            htmlView.LinkedResources.Add(lr);
                            lr.Dispose();
                        }
                    }

                    // set transfer encoding
                    htmlView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.htmlBodyTransferEncoding);
                    mail.AlternateViews.Add(htmlView);
                }

                // add Plain Text AltView
                if (Properties.Settings.Default.AltViewPlain != "")
                {
                    System.Net.Mime.ContentType ctPlain = new System.Net.Mime.ContentType("text/plain");
                    plainView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewPlain, ctPlain);
                    plainView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.plainBodyTransferEncoding);
                    mail.AlternateViews.Add(plainView);
                }

                // add vCal AltView

                if (Properties.Settings.Default.AltViewCal != "")
                {
                    System.Net.Mime.ContentType ctCal = new System.Net.Mime.ContentType("text/calendar");
                    ctCal.Parameters.Add("method", "REQUEST");
                    ctCal.Parameters.Add("name", "meeting.ics");
                    calView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewCal, ctCal);
                    calView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.vCalBodyTransferEncoding);
                    mail.AlternateViews.Add(calView);
                }

                // add custom headers
                foreach (DataGridViewRow rowHdr in dgGridHeaders.Rows)
                {
                    if (rowHdr.Cells[0].Value != null)
                    {
                        mail.Headers.Add(rowHdr.Cells[0].Value.ToString(), rowHdr.Cells[1].Value.ToString());
                    }
                }

                // add attachements
                foreach (DataGridViewRow rowAtt in dgGridAttachments.Rows)
                {
                    if (rowAtt.Cells[0].Value != null)
                    {
                        Attachment data = new Attachment(rowAtt.Cells[0].Value.ToString(), FileUtilities.GetContentType(rowAtt.Cells[1].Value.ToString()));
                        if (rowAtt.Cells[4].Value.ToString() == "True")
                        {
                            data.ContentDisposition.Inline = true;
                            data.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                            data.ContentId = rowAtt.Cells[3].Value.ToString();
                            Properties.Settings.Default.BodyHtml = true;
                        }
                        else
                        {
                            data.ContentDisposition.Inline = false;
                            data.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
                        }
                        mail.Attachments.Add(data);
                    }
                }

                // add read receipt
                if (Properties.Settings.Default.ReadRcpt == true)
                {
                    mail.Headers.Add("Disposition-Notification-To", txtBoxEmailAddress.Text);
                }

                // set the content
                if (chkAutoSubjectAdd.Checked) {
                    DateTime serverTime = DateTime.Now;
                    msgSubject = txtBoxSubject.Text + " - " + serverTime.ToString("HH':'mm':'ss' 'dd'-'MM'-'yyyy");
                }
                else { 
                    msgSubject = txtBoxSubject.Text; 
                }

                mail.Subject = msgSubject;
                mail.Body = richTxtBody.Text;
                mail.IsBodyHtml = Properties.Settings.Default.BodyHtml;
                
                // add delivery notifications
                if (Properties.Settings.Default.DelNotifOnFailure == true)
                {
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                }

                if (Properties.Settings.Default.DelNotifOnSuccess == true)
                {
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                }

                // send by pickup folder?
                if (rdoSendByPickupFolder.Checked)
                {
                    if (chkBoxSpecificPickupFolder.Checked)
                    {
                        if (Directory.Exists(txtPickupFolder.Text))
                        {
                            smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                            smtp.PickupDirectoryLocation = txtPickupFolder.Text;
                        }
                        else
                        {
                            throw new DirectoryNotFoundException(@"The specified directory """ + txtPickupFolder.Text + @""" does not exist.");
                        }
                    }
                    else
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    }
                }

                // smtp client setup

                // this is for TLS enforcement -- is its true
                // STARTTLS will be utilized
                if (radioButtonTLS13.Checked && chkEnableSSL.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                }
                else if (radioButtonTLS12.Checked && chkEnableSSL.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                }
                else if (radioButtonTLS11.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                }
                else if (radioButtonTLS10.Checked) 
                { 
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls; 
                }

                
                smtp.EnableSsl = chkEnableSSL.Checked;

                // we are avoiding to carry out default logon credentials to smtp session
                smtp.UseDefaultCredentials = false;
                
                smtp.Port = Int32.Parse(cmbPort.Text.Trim());
                smtp.Host = cmbServer.Text;
                
                // settings is second, we have to translate milliseconds

                smtp.Timeout = Properties.Settings.Default.SendTimeout * 1000;

                // we are checking, if its office365.com or not because of specific settings on receive connectors 
                // for on premise exchange servers can cause exception
                if (smtp.Host == "smtp.office365.com")
                {
                    string targetname = "SMTPSVC/" + smtp.Host;
                    smtp.TargetName = targetname;
                }
                else
                {
                    smtp.TargetName = null;
                }
                
                
                // check for credentials
                // moved credential a bit low in the code flow becuase of I've seen a credential removal somehow
                string sUser = txtBoxEmailAddress.Text.Trim();
                string sPassword = mskPassword.Text.Trim();
                string sDomain = txtBoxDomain.Text.Trim();

                if (sUser.Length != 0)
                {
                    if (sDomain.Length != 0)
                    {
                        smtp.Credentials = new NetworkCredential(sUser, sPassword, sDomain);
                    }
                    else
                    {
                        smtp.Credentials = new NetworkCredential(sUser, sPassword);
                    }
                    
                }

               //  var tcs = new TaskCompletionSource<bool>();

                new Thread(() =>
                   {
                       try
                       {
                           smtp.Send(mail);
                       }
                       catch (SmtpException se)
                       {
                        if (InvokeRequired) 
                           {
                               this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                           }                                                   
                           noErrFound = false;
                           if (se.StatusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy || se.StatusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable)
                           {
                               /*
                                   logger.Log("Delivery failed - retrying in 5 seconds.");
                                   Thread.Sleep(5000);
                                   // cleanup resources
                                   mail.Dispose();
                                   mail = null;
                                   smtp.Dispose();
                                   smtp = null;
                                   this.SendEmail();
                                   */
                               logger.Log("Error: \r\n" + se.Message);
                               logger.Log("StackTrace: \r\n" + se.StackTrace);
                               logger.Log("Status Code: \r\n" + se.StatusCode);
                               logger.Log("Description: \r\n" + MessageUtilities.GetSmtpStatusCodeDescription(se.StatusCode.ToString()));
                               logger.Log("Inner Exception: \r\n" + se.InnerException);
                           }
                           else
                           {
                               logger.Log("Error: \r\n" + se.Message);
                               logger.Log("StackTrace: \r\n" + se.StackTrace);
                               logger.Log("Status Code: \r\n" + se.StatusCode);
                               logger.Log("Description: \r\n" + MessageUtilities.GetSmtpStatusCodeDescription(se.StatusCode.ToString()));
                               logger.Log("Inner Exception: \r\n" + se.InnerException);
                           }
                       }
                       catch (InvalidOperationException ioe)
                       {
                           // invalid smtp address used
                           if (InvokeRequired)
                           {
                               this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                           }
                           noErrFound = false;
                           logger.Log("Error: \r\n" + ioe.Message);
                           logger.Log("StackTrace: \r\n" + ioe.StackTrace);
                           logger.Log("Inner Exception: \r\n" + ioe.InnerException);
                       }
                       catch (FormatException fe)
                       {
                           // invalid smtp address used
                           if (InvokeRequired)
                           {
                               this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                           }
                           noErrFound = false;
                           logger.Log("Error: \r\n" + fe.Message);
                           logger.Log("StackTrace: \r\n" + fe.StackTrace);
                           logger.Log("Inner Exception: \r\n" + fe.InnerException);
                       }
                       catch (Exception ex)
                       {
                           if (InvokeRequired)
                           {
                               this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                           }
                           noErrFound = false;
                           logger.Log("Error: \r\n" + ex.Message);
                           logger.Log("StackTrace: \r\n" + ex.StackTrace);
                           logger.Log("Inner Exception: \r\n" + ex.InnerException);
                       }
                       finally
                       {
                           // log success
                           //if (formValidated == true && noErrFound == true)
                           if (noErrFound == true)
                           {
                              logger.Log("Message subject = " + msgSubject);
                              logger.Log("Message send = SUCCESS");
                           }

                           // cleanup resources
                           mail.Dispose();
                           mail = null;
                           smtp.Dispose();
                           smtp = null;

                           // reset variables
                           formValidated = false;
                           noErrFound = true;
                           if (InvokeRequired)
                           {
                               this.Invoke((MethodInvoker)delegate { inlineAttachmentsTable.Clear();  });
                           }
                           
                           hdrName = null;
                           hdrValue = null;
                           msgSubject = null;

                           this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                           this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                           this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                           this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });

                       }
                   }).Start();

                //if (tcs.Task.Result) { }

            }
            //*
            catch (Exception ex)
            {
               // txtBoxErrorLog.Clear();
                noErrFound = false;
                logger.Log("Error: \r\n" + ex.Message);
                logger.Log("StackTrace: \r\n" + ex.StackTrace);
                logger.Log("Inner Exception: \r\n" + ex.InnerException);
            }
            finally
            {
  
            }

        }


        //
        //
        // Another copy SEndMail function for Oauth authentication specifically becuase we are using MailKit library for this specific auth.
        // 


        private async void SendEmailM()
        {
            // make sure we have values in user, password and To
            if (ValidateForm() == false)
            {
                return;
            }

            // create mail, smtp and mailaddress objects
            MimeKit.MimeMessage mail = new MimeKit.MimeMessage();
            MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();
            MailAddressCollection mailAddrCol = new MailAddressCollection();
           
            
            try
            {
                // set the From email address information
                mail.From.Add(MimeKit.MailboxAddress.Parse(textBoxFrom.Text));
                
                // set the To email address information
                mailAddrCol.Clear();
                logger.Log("Adding To addresses: " + txtBoxTo.Text);
                mailAddrCol.Add(txtBoxTo.Text);
                MessageUtilities.AddSmtpToMailAddressCollectionM(mail, mailAddrCol, MessageUtilities.AddressType.To);

                // check for Cc and Bcc, which can be empty so we only need to add when the textbox contains a value
                if (txtBoxCC.Text.Trim() != "")
                {
                    mailAddrCol.Clear();
                    logger.Log("Adding Cc addresses: " + txtBoxCC.Text);
                    mailAddrCol.Add(txtBoxCC.Text);
                    MessageUtilities.AddSmtpToMailAddressCollectionM(mail, mailAddrCol, MessageUtilities.AddressType.Cc);
                }

                if (txtBoxBCC.Text.Trim() != "")
                {
                    mailAddrCol.Clear();
                    logger.Log("Adding Bcc addresses: " + txtBoxBCC.Text);
                    mailAddrCol.Add(txtBoxBCC.Text);
                    MessageUtilities.AddSmtpToMailAddressCollectionM(mail, mailAddrCol, MessageUtilities.AddressType.Bcc);
                }

                // set the content
                if (chkAutoSubjectAdd.Checked)
                {
                    DateTime serverTime = DateTime.Now;
                    msgSubject = txtBoxSubject.Text + " - " + serverTime.ToString("HH':'mm':'ss' 'dd'-'MM'-'yyyy");
                }
                else
                {
                    msgSubject = txtBoxSubject.Text;
                }
                var multipart = new Multipart("mixed");
                mail.Subject = msgSubject;
                

                if (Properties.Settings.Default.BodyHtml == true && Properties.Settings.Default.htmlBodyTransferEncoding == "Base64")
                {
                    var textPart = new TextPart(TextFormat.Html)
                    {
                        Text = "<b>" + richTxtBody.Text + "</b>",
                        ContentTransferEncoding = ContentEncoding.Base64,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == false && Properties.Settings.Default.htmlBodyTransferEncoding == "Base64")
                {
                    //builder.TextBody = richTxtBody.Text;
                    //mail.Body = builder.ToMessageBody();
                    var textPart = new TextPart(TextFormat.Text)
                    {
                        Text = richTxtBody.Text,
                        ContentTransferEncoding = ContentEncoding.Base64,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == true && Properties.Settings.Default.htmlBodyTransferEncoding == "QuotedPrintable")
                {
                    var textPart = new TextPart(TextFormat.Html)
                    {
                        Text = "<b>" + richTxtBody.Text + "</b>",
                        ContentTransferEncoding = ContentEncoding.QuotedPrintable,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == false && Properties.Settings.Default.htmlBodyTransferEncoding == "QuotedPrintable")
                {
                    //builder.TextBody = richTxtBody.Text;
                    //mail.Body = builder.ToMessageBody();
                    var textPart = new TextPart(TextFormat.Text)
                    {
                        Text = richTxtBody.Text,
                        ContentTransferEncoding = ContentEncoding.QuotedPrintable,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == true && Properties.Settings.Default.htmlBodyTransferEncoding == "SevenBit")
                {
                    var textPart = new TextPart(TextFormat.Html)
                    {
                        Text = "<b>" + richTxtBody.Text + "</b>",
                        ContentTransferEncoding = ContentEncoding.SevenBit,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == false && Properties.Settings.Default.htmlBodyTransferEncoding == "SevenBit")
                {
                    //builder.TextBody = richTxtBody.Text;
                    //mail.Body = builder.ToMessageBody();
                    var textPart = new TextPart(TextFormat.Text)
                    {
                        Text = richTxtBody.Text,
                        ContentTransferEncoding = ContentEncoding.SevenBit,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == true && Properties.Settings.Default.htmlBodyTransferEncoding == "EightBit")
                {
                    var textPart = new TextPart(TextFormat.Html)
                    {
                        Text = "<b>" + richTxtBody.Text + "</b>",
                        ContentTransferEncoding = ContentEncoding.EightBit,
                    };
                    multipart.Add(textPart);
                    mail.Body = multipart;
                }
                if (Properties.Settings.Default.BodyHtml == false && Properties.Settings.Default.htmlBodyTransferEncoding == "EightBit")
                {
                    //builder.TextBody = richTxtBody.Text;
                    //mail.Body = builder.ToMessageBody();
                    var textPart = new TextPart(TextFormat.Text)
                    {
                        Text = richTxtBody.Text,
                        ContentTransferEncoding = ContentEncoding.EightBit,
                    };
                    multipart.Add(textPart);
                    
                    mail.Body = multipart;
                }

                // set encoding for message
                var options = FormatOptions.Default.Clone();
                options.AllowMixedHeaderCharsets = false;
                
                // The value specified for the BodyEncoding property sets the character set field in the Content - Type header.
                // The default character set is "us-ascii".

                if (Properties.Settings.Default.BodyEncoding != "")
                {
                    int index = mail.Headers.IndexOf(HeaderId.ContentType);
                    int headercount = mail.Headers.Count;
                    if (index < 0) {

                        string cs = MessageUtilities.GetEncodingValue(Properties.Settings.Default.BodyEncoding).EncodingName.ToLower();
                        string mt = "";
                        if (Properties.Settings.Default.BodyHtml) { mt = "text/html"; } else { mt = "text/plain"; }
                        
                        mail.Headers.Add(HeaderId.ContentType, mt + "; charset=" + cs );//

                    }
                    else
                    {
                        var header = mail.Headers[index];
                        header.SetValue(options, MessageUtilities.GetEncodingValue(Properties.Settings.Default.BodyEncoding), mail.Body.ContentType.Charset);
                    }
                }
                if (Properties.Settings.Default.SubjectEncoding != "")
                {
                    int index = mail.Headers.IndexOf(HeaderId.Subject);
                    var header = mail.Headers[index];
                    header.SetValue(options, MessageUtilities.GetEncodingValue(Properties.Settings.Default.SubjectEncoding), mail.Subject);
                }
                // for custom headers
                // https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailmessage.headersencoding?view=net-7.0

                if (Properties.Settings.Default.HeaderEncoding != "")
                {

                    int index = mail.Headers.IndexOf(HeaderId.ContentType);
                    var header = mail.Headers[index];
                  //  header.SetValue(options, MessageUtilities.GetEncodingValue(Properties.Settings.Default.HeaderEncoding), mail);
                    
                 }
                
                // set priority for the message
                switch (Properties.Settings.Default.MsgPriority)
                {
                    case "High":
                        mail.Priority= MessagePriority.Urgent;
                        break;
                    case "Low":
                        mail.Priority = MessagePriority.NonUrgent;
                        break;
                    default:
                        mail.Priority = MessagePriority.Normal;
                        break;
                }
                /*
                // add HTML AltView
                if (Properties.Settings.Default.AltViewHtml != "")
                {
                    ContentType ctHtml = new ContentType("text/html");
                    htmlView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewHtml, ctHtml);

                    // add inline attachments / linked resource
                    if (inlineAttachmentsTable.Rows.Count > 0)
                    {
                        foreach (DataRow rowInl in inlineAttachmentsTable.Rows)
                        {
                            LinkedResource lr = new LinkedResource(rowInl.ItemArray[0].ToString())
                            {
                                ContentId = rowInl.ItemArray[1].ToString()
                            };
                            lr.ContentType.MediaType = rowInl.ItemArray[2].ToString();
                            htmlView.LinkedResources.Add(lr);
                            lr.Dispose();
                        }
                    }

                    // set transfer encoding
                    htmlView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.htmlBodyTransferEncoding);
                    mail.AlternateViews.Add(htmlView);
                }

                // add Plain Text AltView
                if (Properties.Settings.Default.AltViewPlain != "")
                {
                    ContentType ctPlain = new ContentType("text/plain");
                    plainView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewPlain, ctPlain);
                    plainView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.plainBodyTransferEncoding);
                    mail.AlternateViews.Add(plainView);
                }
                */
                
                /*
                // add vCal AltView
                if (Properties.Settings.Default.AltViewCal != "")
                {
                    ContentType ctCal = new ContentType("text/calendar");
                    ctCal.Parameters.Add("method", "REQUEST");
                    ctCal.Parameters.Add("name", "meeting.ics");
                    calView = AlternateView.CreateAlternateViewFromString(Properties.Settings.Default.AltViewCal, ctCal);
                    calView.TransferEncoding = MessageUtilities.GetTransferEncoding(Properties.Settings.Default.vCalBodyTransferEncoding);
                    mail.AlternateViews.Add(calView);
                }
                */
                // add custom headers
                foreach (DataGridViewRow rowHdr in dgGridHeaders.Rows)
                {
                    if (rowHdr.Cells[0].Value != null)
                    {
                        mail.Headers.Add(rowHdr.Cells[0].Value.ToString(), rowHdr.Cells[1].Value.ToString());
                    }
                }

                // add attachements
                foreach (DataGridViewRow rowAtt in dgGridAttachments.Rows)
                {
                    if (rowAtt.Cells[0].Value != null)
                    {
                        
                        Attachment data = new Attachment(rowAtt.Cells[0].Value.ToString(), FileUtilities.GetContentType(rowAtt.Cells[1].Value.ToString()));
                        if (rowAtt.Cells[4].Value.ToString() == "True")
                        {
                            data.ContentDisposition.Inline = true;
                            data.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                            data.ContentId = rowAtt.Cells[3].Value.ToString();
                            Properties.Settings.Default.BodyHtml = true;
                        }
                        else
                        {
                            data.ContentDisposition.Inline = false;
                            data.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
                        }

                        var attachmentPart = new MimePart(data.ContentType.MediaType)
                        {
                            Content = new MimeContent(data.ContentStream),
                            //ContentDisposition = new ContentDisposition (ContentDisposition.),
                            //ContentId = filename,
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = data.Name
                        };
                       
                        multipart.Add(attachmentPart);
                        mail.Body = multipart;
                    }
                }

                // add read receipt
                if (Properties.Settings.Default.ReadRcpt == true)
                {
                    mail.Headers.Add("Disposition-Notification-To", txtBoxEmailAddress.Text);
                }
                
                MailAddress address = new MailAddress(txtBoxEmailAddress.Text);
                mail.MessageId = MimeUtils.GenerateMessageId(address.Host);


                // add delivery notifications
                if (Properties.Settings.Default.DelNotifOnFailure == true)
                {
                 
                }

                if (Properties.Settings.Default.DelNotifOnSuccess == true)
                {

                    // smtp.DeliveryStatusNotificationType=MailKit.DeliveryStatusNotification.Success;
                }

                // send by pickup folder?
                if (rdoSendByPickupFolder.Checked)
                {
                    if (chkBoxSpecificPickupFolder.Checked)
                    {
                        if (Directory.Exists(txtPickupFolder.Text))
                        {
                          //  smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                          //  smtp.PickupDirectoryLocation = txtPickupFolder.Text;
                        }
                        else
                        {
                            throw new DirectoryNotFoundException(@"The specified directory """ + txtPickupFolder.Text + @""" does not exist.");
                        }
                    }
                    else
                    {
                      //  smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    }
                }

                // smtp client setup

                // this is for TLS enforcement -- is its true
                // STARTTLS will be utilized
                var tlsLayer = new System.Security.Authentication.SslProtocols();
                if (radioButtonTLS13.Checked && chkEnableSSL.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                    tlsLayer = SslProtocols.Tls13;
                    smtp.SslProtocols = tlsLayer;
                }
                else if (radioButtonTLS12.Checked && chkEnableSSL.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    tlsLayer = SslProtocols.Tls12;
                    smtp.SslProtocols = tlsLayer;
                }
                else if (radioButtonTLS11.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                    tlsLayer = SslProtocols.Tls11;
                    smtp.SslProtocols = tlsLayer;
                }
                else if (radioButtonTLS10.Checked)
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    tlsLayer = SslProtocols.Tls;
                    smtp.SslProtocols = tlsLayer;
                }
            

                // we are avoiding to carry out default logon credentials to smtp session
                smtp.AuthenticationMechanisms.Remove(CredentialCache.DefaultCredentials.ToString());

                var Port = Int32.Parse(cmbPort.Text.Trim());
                var Host = cmbServer.Text;

                //smtp.Connect(cmbServer.Text, Int32.Parse(cmbPort.Text.Trim()), chkEnableSSL);
                // settings is second, we have to translate milliseconds
                
                smtp.Timeout = Properties.Settings.Default.SendTimeout * 1000;

                // we are checking, if its office365.com or not because of specific settings on receive connectors 
                // for on premise exchange servers can cause exception
                               
        /*
                if (cmbServer.Text == "smtp.office365.com")
                {
                    string targetname = "SMTPSVC/" + smtp.Host;
                    smtp.TargetName = targetname;
                }
                else
                {
                    smtp.TargetName = null;
                }
          */      

                // check for credentials
                // moved credential a bit low in the code flow becuase of I've seen a credential removal somehow
                string sUser = txtBoxEmailAddress.Text.Trim();
                //string sPassword = mskPassword.Text.Trim();
                //string sDomain = txtBoxDomain.Text.Trim();
                
                var oauth2 = new SaslMechanismOAuth2(oauthToken.Account.Username, oauthToken.AccessToken);

                if (oauthToken.AccessToken != null)
                {
                    
                        await smtp.ConnectAsync(Host, Port, SecureSocketOptions.StartTls);
                        await smtp.AuthenticateAsync(oauth2);

                 }
                
                new Thread(() =>
                {
                    try
                    {
                      
                        smtp.Send(mail);
                    }
                    catch (SmtpCommandException sce)
                    {
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                            this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });
                        }
                        noErrFound = false;
                        if (sce.StatusCode == MailKit.Net.Smtp.SmtpStatusCode.MailboxBusy || sce.StatusCode == MailKit.Net.Smtp.SmtpStatusCode.MailboxUnavailable)
                        {
                            /*
                            logger.Log("Delivery failed - retrying in 5 seconds.");
                            Thread.Sleep(5000);
                            
                            // cleanup resources
                            mail.Dispose();
                            mail = null;
                            smtp.Dispose();
                            smtp = null;
                            this.SendEmailM();
                            Thread.ResetAbort();
                            */
                            logger.Log("Error: \r\n" + sce.Message);
                            logger.Log("StackTrace: \r\n" + sce.StackTrace);
                            logger.Log("Status Code: \r\n" + sce.StatusCode);
                            logger.Log("Description: \r\n" + MessageUtilities.GetSmtpStatusCodeDescription(sce.StatusCode.ToString()));
                            logger.Log("Inner Exception: \r\n" + sce.InnerException);
                        }
                        else
                        {
                            logger.Log("Error: \r\n" + sce.Message);
                            logger.Log("StackTrace: \r\n" + sce.StackTrace);
                            logger.Log("Status Code: \r\n" + sce.StatusCode);
                            logger.Log("Description: \r\n" + MessageUtilities.GetSmtpStatusCodeDescription(sce.StatusCode.ToString()));
                            logger.Log("Inner Exception: \r\n" + sce.InnerException);
                        }
                    }
                    catch (SmtpProtocolException spe)
                    {
                        // invalid smtp address used
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                            this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });
                        }
                        
                        noErrFound = false;
                        logger.Log("Error: \r\n" + spe.Message);
                        logger.Log("StackTrace: \r\n" + spe.StackTrace);
                        logger.Log("Inner Exception: \r\n" + spe.InnerException);

                    }
                    catch (InvalidOperationException ioe)
                    {
                        // invalid smtp address used
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                            this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });
                        }
                        noErrFound = false;
                        logger.Log("Error: \r\n" + ioe.Message);
                        logger.Log("StackTrace: \r\n" + ioe.StackTrace);
                        logger.Log("Inner Exception: \r\n" + ioe.InnerException);
                    }
                    catch (FormatException fe)
                    {
                        // invalid smtp address used
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear(); });
                            this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });
                        }
                        noErrFound = false;
                        logger.Log("Error: \r\n" + fe.Message);
                        logger.Log("StackTrace: \r\n" + fe.StackTrace);
                        logger.Log("Inner Exception: \r\n" + fe.InnerException);
                    }
                    catch (Exception ex)
                    {
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { txtBoxErrorLog.Clear();});
                            this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                            this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });
                        }
                        noErrFound = false;
                        logger.Log("Error: \r\n" + ex.Message);
                        logger.Log("StackTrace: \r\n" + ex.StackTrace);
                        logger.Log("Inner Exception: \r\n" + ex.InnerException);
                    }
                    finally
                    {
                        // log success
                        //if (formValidated == true && noErrFound == true)
                        if (noErrFound == true)
                        {
                            logger.Log("Message subject = " + msgSubject);
                            logger.Log("Message send = SUCCESS");
                        }

                        // cleanup resources
                        mail.Dispose();
                        mail = null;
                        smtp.Dispose();
                        smtp = null;

                        // reset variables
                        formValidated = false;
                        noErrFound = true;
                        if (InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate { inlineAttachmentsTable.Clear(); });
                        }

                        hdrName = null;
                        hdrValue = null;
                        msgSubject = null;

                        this.Invoke((MethodInvoker)delegate { btnSendEmail.Enabled = true; });
                        this.Invoke((MethodInvoker)delegate { btnStartSendLoop.Enabled = true; });
                        this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0; });
                        this.Invoke((MethodInvoker)delegate { toolStripProgressBar1.Style = ProgressBarStyle.Blocks; });

                    }
                }).Start();

                //if (tcs.Task.Result) { }

            }
            //*
            catch (Exception ex)
            {
                btnSendEmail.Enabled = true;
                btnStartSendLoop.Enabled = true;
                toolStripProgressBar1.ProgressBar.MarqueeAnimationSpeed = 0;
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                noErrFound = false;
                logger.Log("Error: \r\n" + ex.Message);
                logger.Log("StackTrace: \r\n" + ex.StackTrace);
                logger.Log("Inner Exception: \r\n" + ex.InnerException);
            }
            finally
            {

            }


        }


        /// <summary>
        /// This button calls the SendEmail method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSendEmail_Click(object sender, EventArgs e)
        {
            
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.MarqueeAnimationSpeed = 1;
            toolStripProgressBar1.Style= ProgressBarStyle.Marquee;

            
            //trying to disable send buttons from accidental multiple click as currently app is busy
            btnSendEmail.Enabled = false;
            btnStartSendLoop.Enabled = false;
            txtBoxErrorLog.Clear();
            txtBoxErrorLog.Refresh();
            // Adding Server name/fqdn to combobox temp list
            if (!cmbServer.Items.Contains(cmbServer.Text)) 
                    { 
                    cmbServer.Items.Add(cmbServer.Text);
                    }
            // Adding Server port to combobox temp list
            if (!cmbPort.Items.Contains(cmbPort.Text))
            {
                cmbPort.Items.Add(cmbPort.Text);
            }
            //calling send email function depends on the OAuth checkbox
            if (chkOAuth.Checked)
            {
                this.SendEmailM();
            }
            else {
                this.SendEmail();
            }
            
           
        }

        /// <summary>
        /// This button will allow the user to add an attachment to the mail message list
        /// but the send method handles actually adding the file to the mail message
        /// this just creates the file paths
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInsertAttachment_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBoxErrorLog.Clear();
                string file = openFileDialog1.FileName;
                FileInfo f = new FileInfo(file);

                try
                {
                    int n = dgGridAttachments.Rows.Add();
                    string size = FileUtilities.SizeSuffix(f.Length);
                    dgGridAttachments.Rows[n].Cells[0].Value = file;

                    switch (f.Extension)
                    {
                        case ".pdf":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Pdf";
                            break;
                        case ".txt":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Txt";
                            break;
                        case ".zip":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Zip";
                            break;
                        case ".html":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Html";
                            break;
                        case ".tiff":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Tiff";
                            break;
                        case ".gif":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Gif";
                            break;
                        case ".jpeg":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Jpeg";
                            break;
                        case ".rtf":
                            dgGridAttachments.Rows[n].Cells[1].Value = "Rtf";
                            break;
                        default:
                            dgGridAttachments.Rows[n].Cells[1].Value = "Octet";
                            break;
                    }
                    dgGridAttachments.Rows[n].Cells[2].Value = size;
                    dgGridAttachments.Rows[n].Cells[3].Value = "";
                    dgGridAttachments.Rows[n].Cells[4].Value = "False";
                }
                catch (IOException ioe)
                {
                    logger.Log("Error: " + ioe.Message);
                    logger.Log("StackTrace: " + ioe.StackTrace);
                }
                catch (Exception ex)
                {
                    logger.Log("Error: " + ex.Message);
                    logger.Log("StackTrace: " + ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// display the form to add custom headers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddHeaders_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.FrmAddHeaders aHdrForm = new Forms.FrmAddHeaders
                {
                    Owner = this
                };

                aHdrForm.ShowDialog(this);
                if (hdrName != null && hdrValue != null)
                {
                    int n = dgGridHeaders.Rows.Add();
                    dgGridHeaders.Rows[n].Cells[0].Value = hdrName;
                    dgGridHeaders.Rows[n].Cells[1].Value = hdrValue;
                }
            }
            catch (Exception ex)
            {
                logger.Log("Error: " + ex.Message);
                logger.Log("StackTrace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// delete the currently selected attachment in the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                int cellRow = dgGridAttachments.CurrentCellAddress.Y;
                if (dgGridAttachments.CurrentCell.ColumnIndex >= 0)
                {
                    dgGridAttachments.Rows.RemoveAt(dgGridAttachments.Rows[cellRow].Index);
                }
            }
            catch (NullReferenceException nre)
            {
                // if the attachment grid is empty, just return
                if (dgGridAttachments.CurrentCellAddress.Y< 1)
                {
                    return;
                }
                else
                {
                    // log any other null ref errors
                    logger.Log("Error: " + nre.Message);
                    logger.Log("StackTrace: " + nre.StackTrace);
                    logger.Log("Inner Exception: " + nre.InnerException);
                }
}
            catch (Exception ex)
            {
                logger.Log("Error: " + ex.Message);
                logger.Log("StackTrace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// delete the currently selected row for the header datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteHeader_Click(object sender, EventArgs e)
        {
            try
            {
                int cellRow = dgGridHeaders.CurrentCellAddress.Y;
                if (dgGridHeaders.CurrentCell.ColumnIndex >= 0)
                {
                    dgGridHeaders.Rows.RemoveAt(dgGridHeaders.Rows[cellRow].Index);
                }
            }
            catch (NullReferenceException nre)
            {
                // if the header grid is empty, just return
                if (dgGridHeaders.CurrentCellAddress.Y < 1)
                {
                    return;
                }
                else
                {
                    // log any other null ref errors
                    logger.Log("Error: " + nre.Message);
                    logger.Log("StackTrace: " + nre.StackTrace);
                    logger.Log("Inner Exception: " + nre.InnerException);
                }
            }
            catch (Exception ex)
            {
                logger.Log("Error: " + ex.Message);
                logger.Log("StackTrace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// send an email every x seconds, based on the value of the numUpDn control
        /// ContinueTimerRun is initially set to true and you need to press the stop button to set it to false
        /// which should stop the sending loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartSendLoop_Click(object sender, EventArgs e)
        {
            decimal msgCount = 0;
            continueTimerRun = true;

            btnStopSendLoop.Focus();

            if (ValidateForm() == false)
            {
                return;
            }

            while (continueTimerRun == true)
            {
                msgCount++;
                if (msgCount == 300)
                {
                    continueTimerRun = false;
                }
                logger.Log(string.Format("Sending Message {0}...\r\n", msgCount));
                    
                    if (chkOAuth.Checked)
                    {
                        this.SendEmailM();
                    }
                    else
                    {
                        this.SendEmail();
                    }

                txtBoxErrorLog.Text = "Sending message " + msgCount;
                
                WaitLoop((int)numUpDnSeconds.Value);
            }

            logger.Log("Finished timer based email send.\r\n");
            txtBoxErrorLog.Text = "Finished timer based email send.";
        }

        /// <summary>
        /// this button sets the ContinueTimerRun to false, which ends the sending loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopSendLoop_Click(object sender, EventArgs e)
        {
            continueTimerRun = false;
            logger.Log("User chose to stop email loop.\r\n");
        }

        /// <summary>
        /// sleep function to wait "numSeconds" before returning control back to the caller
        /// </summary>
        /// <param name="numSeconds">amount of time to wait</param>
        private void WaitLoop(int numSeconds)
        {
            for (int secondsLoop = 0; secondsLoop < numSeconds; secondsLoop++)
            {
                for (int Loop1 = 0; Loop1 < 10; Loop1++)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();

                    if (continueTimerRun == false)
                        break;
                }

                if (continueTimerRun == false)
                    break;
            }
        }

        /// <summary>
        /// function used to validate the User, Password and To fields before sending
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            bool bRet = true;

            if (txtBoxEmailAddress.Text.Trim() == "")
            {
                logger.Log("User is required.");
                bRet = false;
                btnSendEmail.Enabled = true;
                btnStartSendLoop.Enabled = true;
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;
            }

            if ((chkPasswordRequired.Checked && mskPassword.Text.Trim() == "") && (!chkOAuth.Checked))
            {
                logger.Log("Password is required.");
                bRet = false;
                btnSendEmail.Enabled = true;
                btnStartSendLoop.Enabled = true;
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;
            }

            if (txtBoxTo.Text.Trim() == "")
            {
                logger.Log("To address is required.");
                bRet = false;
                btnSendEmail.Enabled = true;
                btnStartSendLoop.Enabled = true;
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;

            }

            formValidated = bRet;
            return bRet;
        }

        /// <summary>
        /// display the add alt view form
        /// this sets altViewHtml and altViewPlain when it returns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAltView_Click(object sender, EventArgs e)
        {
            Forms.FrmAlternateView aAltViewForm = new Forms.FrmAlternateView
            {
                Owner = this
            };

            aAltViewForm.ShowDialog(this);
            richTxtBody.Text = Properties.Settings.Default.AltViewPlain;
        }

        // toggle the time based send feature
        private void ChkTimeBasedSend_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkTimeBasedSend.Checked)
            {
                btnSendEmail.Enabled = false;
                btnStartSendLoop.Enabled = true;
                btnStopSendLoop.Enabled = true;
                lblNumSeconds.Enabled = true;
                numUpDnSeconds.Enabled = true;
            }
            else
            {
                btnSendEmail.Enabled = true;
                btnStartSendLoop.Enabled = false;
                btnStopSendLoop.Enabled = false;
                lblNumSeconds.Enabled = false;
                numUpDnSeconds.Enabled = false;
            }
        }

        // toggle the pickup folder textbox
        private void ChkBoxSpecificPickupFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSpecificPickupFolder.Checked)
            {
                txtPickupFolder.Enabled = true;
            }
            else
            {
                txtPickupFolder.Enabled = false;
            }
        }

        // toggle the send by pickup checkbox
        private void RdoSendByPickupFolder_CheckedChanged(object sender, EventArgs e)
        {
            chkEnableSSL.Checked = false;
            if (rdoSendByPickupFolder.Checked)
            {
                chkBoxSpecificPickupFolder.Enabled = true;
            }
            else
            {
                chkBoxSpecificPickupFolder.Checked = false;
                chkBoxSpecificPickupFolder.Enabled = false;
                txtPickupFolder.Enabled = false;
            }
        }

        // form close event
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // clean up resources on exit
            logger.Dispose();
        }

        // enable ssl checkbox when port radio is clicked
        private void RdoSendByPort_CheckedChanged(object sender, EventArgs e)
        {
            chkEnableSSL.Checked = true;
        }

        // when the user changes the dropdown for server, automatically change the port number to a recommended value
        private void CboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServer.Text == "smtp.gmail.com" || cmbServer.Text == "smtp.mail.yahoo.com")
            {
                cmbPort.Text = "465";
            }
            else if (cmbServer.Text == "smtp.office365.com")
            {
                cmbPort.Text = "587";
            }
            else
            {
                cmbPort.Text = "25";
            }
        }

        /// <summary>
        /// open the log file in Notepad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenLogFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Notepad.exe", AppDomain.CurrentDomain.BaseDirectory + "NetMailErrors.log");
            }
            catch (Exception ex)
            {
                txtBoxErrorLog.Text = "Unable to open log file: " + ex.Message;
            }
        }

        /// <summary>
        /// this button handles displaying the File Open dialog and loading the settings from an existing xml file
        /// useriohelper is for displaying the dialog and serialhelper is for parsing out the xml for settings
        /// once the settings have been parsed from the xml file, setformfromconnectionsettings is called to populate the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuFileLoadSettings_Click(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            string sFilter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            string sConnectionSettings = string.Empty;

            ConnectionSettings oConnectionSetting = null;
            string sFileContents = string.Empty;

            if (UserIoHelper.PickLoadFromFile(AppDomain.CurrentDomain.BaseDirectory, "*.xml", ref sFile, sFilter))
            {
                try
                {
                    sFileContents = System.IO.File.ReadAllText(sFile);
                    oConnectionSetting = SerialHelper.DeserializeObjectFromString<ConnectionSettings>(sFileContents);
                    if (oConnectionSetting == null)
                        throw new Exception("Settings file cannot be deserialized.");
                    SetFormFromConnectionSettings(oConnectionSetting);
                }
                catch (Exception ex)
                {
                    txtBoxErrorLog.Clear();
                    txtBoxErrorLog.Text = ex.ToString() + "Error Loading File";
                }

            }
            oConnectionSetting = null;
        }

        /// <summary>
        /// save the current form settings to an xml file
        /// useriohelper is for displaying the save dialog
        /// setconnectionsettingsfromform handles which settings need to be saved
        /// then serialhelper streams that information to the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuFileSaveSettings_Click(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            string sFilter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            string sConnectionSettings = string.Empty;
            ConnectionSettings oConnectionSetting = new ConnectionSettings();

            SetConnectionSettingsFromForm(ref oConnectionSetting);

            if (UserIoHelper.PickSaveFileToFolder(AppDomain.CurrentDomain.BaseDirectory, "Email Settings.xml", ref sFile, sFilter))
            {
                sConnectionSettings = SerialHelper.SerializeObjectToString<ConnectionSettings>(oConnectionSetting);
                if (sConnectionSettings != string.Empty)
                {
                    try
                    {
                        File.WriteAllText(sFile, sConnectionSettings);
                    }
                    catch (Exception ex)
                    {
                        txtBoxErrorLog.Clear();
                        txtBoxErrorLog.Text = ex.Message + "Error Saving File";
                    }
                }
            }
        }

        // display File Options dialog
        private void MnuFileOptions_Click(object sender, EventArgs e)
        {
            Forms.FrmMessageOptions mEncoding = new Forms.FrmMessageOptions
            {
                Owner = this
            };
            mEncoding.ShowDialog(this);
        }

        // display File About dialog
        private void MnuFileAbout_Click(object sender, EventArgs e)
        {
            Forms.FrmAbout frm = new Forms.FrmAbout();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        // apply settings for the form
        private void SetFormFromConnectionSettings(ConnectionSettings oConnectionSetting)
        {
            try
            {
                txtBoxEmailAddress.Text = FixSetting(oConnectionSetting.User);
                txtBoxDomain.Text = FixSetting(oConnectionSetting.Domain);
                txtBoxSubject.Text = FixSetting(oConnectionSetting.MessageSubject);
                txtBoxTo.Text = FixSetting(oConnectionSetting.MessageTo);
                txtBoxCC.Text = FixSetting(oConnectionSetting.MessageCC);
                txtBoxBCC.Text = FixSetting(oConnectionSetting.MessageBcc);
                richTxtBody.Text = FixSetting(oConnectionSetting.MessageBody);

                if (oConnectionSetting.SendByPort == true)
                {
                    rdoSendByPort.Checked = true;
                    cmbPort.Text = oConnectionSetting.Port;
                    cmbServer.Text = oConnectionSetting.Server;
                }
                else
                {
                    rdoSendByPickupFolder.Checked = true;
                    chkBoxSpecificPickupFolder.Checked = oConnectionSetting.CustomPickupLocation;
                    txtPickupFolder.Text = FixSetting(oConnectionSetting.PickupLocation);
                }
            }
            catch (Exception ex)
            {
                txtBoxErrorLog.Clear();
                txtBoxErrorLog.Text = ex.Message + "Error loading settings into form";
            }
        }

        // string function to make sure we aren't using null values, empty values are fine
        private string FixSetting(string sSetting)
        {
            if (sSetting == null)
                return "";
            else
                return sSetting;
        }

        // specifiy the connection settings
        private void SetConnectionSettingsFromForm(ref ConnectionSettings oConnectionSetting)
        {
            oConnectionSetting.User = txtBoxEmailAddress.Text;
            oConnectionSetting.Domain = txtBoxDomain.Text;
            oConnectionSetting.UseSSL = chkEnableSSL.Checked;
            oConnectionSetting.PasswordRequired = chkPasswordRequired.Checked;
            oConnectionSetting.MessageTo = txtBoxTo.Text;
            oConnectionSetting.MessageCC = txtBoxCC.Text;
            oConnectionSetting.MessageBcc = txtBoxBCC.Text;
            oConnectionSetting.MessageSubject = txtBoxSubject.Text;
            oConnectionSetting.MessageBody = richTxtBody.Text;
            
            oConnectionSetting.Port = cmbPort.Text;
            oConnectionSetting.Server = cmbServer.Text;
            oConnectionSetting.SendByPort = rdoSendByPort.Checked;
            oConnectionSetting.CustomPickupLocation = chkBoxSpecificPickupFolder.Checked;
            oConnectionSetting.PickupLocation = txtPickupFolder.Text;
        }

        private void AboutToolStrip_Click(object sender, EventArgs e)
        {
            Forms.FrmAbout frm = new Forms.FrmAbout();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void FeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/desjarlais/netmailsender/issues");
        }

        private void EditNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginEditDataGridView(0, 2);
        }

        private void EditValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginEditDataGridView(1, 2);
        }

        private void EditContentIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginEditDataGridView(3, 1);
        }

        private void BtnTextToHeader_Click(object sender, EventArgs e)
        {
            Forms.FrmTextToHeader aTextToHeaderForm = new Forms.FrmTextToHeader();
            aTextToHeaderForm.Owner = this;
            aTextToHeaderForm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void txtBoxEmailAddress_TextChanged(object sender, EventArgs e)
        {
            textBoxFrom.Text = txtBoxEmailAddress.Text;
            mskPassword.Enabled = true;
            txtBoxDomain.Enabled = true;
        }

        private void chkEnableSSL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableSSL.CheckState == 0) 
            {
                radioButtonTLS10.Enabled = false;
                radioButtonTLS11.Enabled = false;
                radioButtonTLS12.Enabled = false;
                radioButtonTLS13.Enabled = false;
                chkOAuth.Enabled = false;
            }
            else
            {
                radioButtonTLS10.Enabled = true;
                radioButtonTLS11.Enabled = true;
                radioButtonTLS12.Enabled = true;
                radioButtonTLS13.Enabled = true;
                chkOAuth.Enabled = true;
            }
        }


        
        private void txtBoxEmailAddress_DoubleClick(object sender, EventArgs e)
        {
            mskPassword.Enabled = true;
            txtBoxDomain.Enabled = true;
        }
        // below varialble will be used for Oauth authentication in smtp send..
        // we will populate oauth token by calling another form
        // we will need to seperate variable
        private void chkBoxOAuh_CheckStateChanged(object sender, EventArgs e)
        {
            txtBoxErrorLog.Clear(); 
            if (chkOAuth.Checked)
            {
                Forms.FrmOAuth oauthForm = new Forms.FrmOAuth();
                oauthForm.Owner = this;

                try
                {
                    oauthForm.ShowDialog(this);
                    if (oauthToken != null)
                    {
                        txtBoxEmailAddress.Text = oauthToken.Account.Username.ToString();
                        txtBoxDomain.Enabled = false;
                        mskPassword.Enabled = false;
                        chkEnableSSL.Enabled = true;
                    }
                    else
                    {
                        
                        txtBoxErrorLog.Text = "Unable to get OAuth token.";
                        //as we did not get any token we have to enable classical auth ability
                        txtBoxDomain.Enabled = true;
                        mskPassword.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    txtBoxErrorLog.Text = "Unable to get OAuth token." + "\r\n" + ex.Message;
                    //as we did not get any token we have to enable classical auth ability
                    txtBoxDomain.Enabled = true;
                    mskPassword.Enabled = true;

                }
                            
            }
            else {
                //we have to enable classical auth ability
                txtBoxDomain.Enabled = true;
                mskPassword.Enabled = true;
            }

        }

        private void EditInlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginEditDataGridView(4, 1);
        }

        private void DGridHeaders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgGridHeaders.CurrentCell = dgGridHeaders[e.ColumnIndex, e.RowIndex];
            }
        }

        private void DGridAttachments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgGridAttachments.CurrentCell = dgGridAttachments[e.ColumnIndex, e.RowIndex];
            }
        }

        private void DGridAttachments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                BeginEditDataGridView(1, 1);
            }
            else if (e.ColumnIndex == 4)
            {
                BeginEditDataGridView(4, 1);
            }
        }

        /// <summary>
        /// function to cell edits in datagridview
        /// </summary>
        /// <param name="cell">the cell that needs to be edited</param>
        /// <param name="dGrid">1 = attachments datagridview, 2 = header datagridview</param>
        public void BeginEditDataGridView(int cell, int dGrid)
        {
            if (dGrid == 1)
            {
                int n = dgGridAttachments.CurrentCellAddress.Y;
                dgGridAttachments.CurrentCell = dgGridAttachments.Rows[n].Cells[cell];
                dgGridAttachments.BeginEdit(true);
            }
            else
            {
                int n = dgGridHeaders.CurrentCellAddress.Y;
                dgGridHeaders.CurrentCell = dgGridHeaders.Rows[n].Cells[cell];
                dgGridHeaders.BeginEdit(true);
            }

        }
    }
}