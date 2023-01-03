/****************************** Module Header ******************************\
Module Name:  MessageUtilities.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

Miscellaneous functions for dealing with the MailMessage object

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

using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using MimeKit;
using MailKit;

namespace NetMailSample.Common
{
    public static class MessageUtilities
    {
        // mail address message type enum
        public enum AddressType
        {
            To,
            Cc,
            Bcc
        };

        /// <summary>
        /// Depending on the mail address type, add each mail address from the collection to the mail message
        /// </summary>
        /// <param name="mail">This is the MailMessage object from the main form</param>
        /// <param name="mailAddrCol">This is the Collection of addresses that need to be added</param>
        /// <param name="mailAddressType">type of mail address to be added</param>
        public static void AddSmtpToMailAddressCollection(MailMessage mail, MailAddressCollection mailAddrCol, AddressType mailAddressType)
        {
            foreach (MailAddress ma in mailAddrCol)
            {
                if (mailAddressType == AddressType.To)
                {
                    mail.To.Add(ma.Address);
                }
                else if (mailAddressType == AddressType.Cc)
                {
                    mail.CC.Add(ma.Address);
                }
                else
                {
                    mail.Bcc.Add(ma.Address);
                }
            }
        }
        /// <summary>
        /// Depending on the mail address type, add each mail address from the collection to the mail message
        /// </summary>
        /// <param name="mail">This is the MailMessage object from the main form</param>
        /// <param name="mailAddrCol">This is the Collection of addresses that need to be added</param>
        /// <param name="mailAddressType">type of mail address to be added</param>
        public static void AddSmtpToMailAddressCollectionM(MimeMessage mail, MailAddressCollection mailAddrCol, AddressType mailAddressType)
        {
            foreach (MailboxAddress ma in mailAddrCol)
            {
                if (mailAddressType == AddressType.To)
                {
                    mail.To.Add(MimeKit.MailboxAddress.Parse(ma.Address));
                }
                else if (mailAddressType == AddressType.Cc)
                {
                    mail.Cc.Add(MimeKit.MailboxAddress.Parse(ma.Address));
                }
                else
                {
                    mail.Bcc.Add(MimeKit.MailboxAddress.Parse(ma.Address));
                }
            }
        }
        /// <summary>
        /// this function converts the Encoding type for the mail message
        /// </summary>
        /// <param name="encodingVal">string value to be converted</param>
        /// <returns></returns>
        public static Encoding GetEncodingValue(string encodingVal)
        {
            switch (encodingVal)
            {
                case "UTF8":
                    return Encoding.UTF8;
                case "Unicode":
                    return Encoding.Unicode;
                case "UTF32":
                    return Encoding.UTF32;
                case "UTF7":
                    return Encoding.UTF7;
                case "ASCII":
                    return Encoding.ASCII;
                case "BigEndianUnicode":
                    return Encoding.BigEndianUnicode;
                default:
                    return Encoding.Default;
            }
        }


        public static DeliveryStatusNotification? GetDeliveryStatusNotifications(MimeMessage message, MailboxAddress mailbox)
        {
            // In this example, we only want to be notified of failures to deliver to a mailbox.
            // If you also want to be notified of delays or successful deliveries, simply bitwise-or
            // whatever combination of flags you want to be notified about.
            return DeliveryStatusNotification.Success | DeliveryStatusNotification.Delay | DeliveryStatusNotification.Failure;
        }


        /// <summary>
        /// this function will convert the string value to the corresponding TransferEncoding type
        /// </summary>
        /// <param name="tEncoding">string value to be converted</param>
        /// <returns></returns>
        public static TransferEncoding GetTransferEncoding(string tEncoding)
        {
            switch (tEncoding)
            {
                case "QuotedPrintable":
                    return TransferEncoding.QuotedPrintable;
                case "SevenBit":
                    return TransferEncoding.SevenBit;
                case "EightBit":
                    return TransferEncoding.EightBit;
                case "Base64":
                    return TransferEncoding.Base64;
                default:
                    return TransferEncoding.Unknown;
            }
        }

        /// <summary>
        /// this function will return the status code description for an smtp exception
        /// </summary>
        /// <param name="sCode">this is the status code from the smtp exception</param>
        /// <returns></returns>
        public static string GetSmtpStatusCodeDescription(string sCode)
        {
            switch (sCode)
            {
                case "GeneralFailure":
                    return "The transaction could not occur. You receive this error when the specified SMTP host cannot be found.";
                case "BadCommandSequence":
                    return "The commands were sent in the incorrect sequence.";
                case "CannotVerifyUserWillAttemptDelivery":
                    return "The specified user is not local, but the receiving SMTP service accepted the message and attempted to deliver it. This status code is defined in RFC 1123, which is available at http://www.ietf.org.";
                case "ClientNotPermitted":
                    return "The client was not authenticated or is not allowed to send mail using the specified SMTP host.";
                case "CommandNotImplemented":
                    return "The SMTP service does not implement the specified command.";
                case "CommandParameterNotImplemented":
                    return "The SMTP service does not implement the specified command parameter.";
                case "CommandUnrecognized":
                    return "The SMTP service does not recognize the specified command.";
                case "ExceededStorageAllocation":
                    return "The message is too large to be stored in the destination mailbox.";
                case "HelpMessage":
                    return "A Help message was returned by the service.";
                case "InsufficientStorage":
                    return "The SMTP service does not have sufficient storage to complete the request.";
                case "LocalErrorInProcessing":
                    return "The SMTP service cannot complete the request. This error can occur if the client's IP address cannot be resolved (that is, a reverse lookup failed). You can also receive this error if the client domain has been identified as an open relay or source for unsolicited e-mail (spam). For details, see RFC 2505, which is available at http://www.ietf.org.";
                case "MailboxBusy":
                    return "The destination mailbox is in use.";
                case "MailboxNameNotAllowed":
                    return "The syntax used to specify the destination mailbox is incorrect.";
                case "MailboxUnavailable":
                    return "The destination mailbox was not found or could not be accessed.";
                case "MustIssueStartTlsFirst":
                    return "The SMTP server is configured to accept only TLS connections, and the SMTP client is attempting to connect by using a non-TLS connection. The solution is for the user to set EnableSsl=true on the SMTP Client.";
                case "ServiceClosingTransmissionChannel":
                    return "The SMTP service is closing the transmission channel.";
                case "ServiceNotAvailable":
                    return "The SMTP service is not available; the server is closing the transmission channel.";
                case "ServiceReady":
                    return "The SMTP service is ready.";
                case "StartMailInput":
                    return "The SMTP service is ready to receive the e-mail content.";
                case "SyntaxError":
                    return "The syntax used to specify a command or parameter is incorrect.";
                case "SystemStatus":
                    return "A system status or system Help reply.";
                case "TransactionFailed":
                    return "The transaction failed.";
                case "UserNotLocalTryAlternatePath":
                    return "The user mailbox is not located on the receiving server. You should resend using the supplied address information.";
                case "UserNotLocalWillForward":
                    return "The user mailbox is not located on the receiving server; the server forwards the e-mail.";
                case "Ok":
                    return "The email was successfully sent to the SMTP service.";
                default:
                    return "Undefined status code.";
            }
        }
    }
}