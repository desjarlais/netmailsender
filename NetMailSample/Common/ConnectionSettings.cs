/****************************** Module Header ******************************\
Module Name:  ConnectiongSettings.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

class for holding connecting setting strings

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
