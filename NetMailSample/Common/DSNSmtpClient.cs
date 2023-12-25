using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMailSample.Common
{
    class DSNSmtpClient : MailKit.Net.Smtp.SmtpClient
    {
        protected override DeliveryStatusNotification? GetDeliveryStatusNotifications(MimeMessage message, MailboxAddress mailbox)
        {
            if (Properties.Settings.Default.DelNotifOnFailure == true) { return DeliveryStatusNotification.Failure; };
            if (Properties.Settings.Default.DelNotifOnSuccess == true) { return DeliveryStatusNotification.Success; };
           // if (Properties.Settings.Default.DelNotifOnFailure == true) { return DeliveryStatusNotification.Delay; };
                 
            return null;
        }
    }
}
