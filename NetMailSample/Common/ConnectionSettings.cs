using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetMailSample.Common
{
    public class ConnectionSettings
    {
        public string User = string.Empty;
        public string Domain = string.Empty;
        
        public bool UseSSL = false;
        public bool PasswordRequired = false;
        public bool SendByPort = false;
        public bool CustomPickupLocation = false;
        
        public string Server = string.Empty;
        public string Port = string.Empty;
        public string PickupLocation = string.Empty;

        public string MessageTo = string.Empty;
        public string MessageCC = string.Empty;
        public string MessageBcc = string.Empty;
        public string MessageSubject = string.Empty;
        public string MessageBody = string.Empty;
    }
}
