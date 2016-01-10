/****************************** Module Header ******************************\
Module Name:  ClassLogger.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

Error logging class

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
using System.IO;

namespace NetMailSample
{
    public class LoggerEventArgs : EventArgs
    {
        private DateTime _logTime;
        private string _logDetails;

        public LoggerEventArgs(DateTime LogTime, string LogDetails)
        {
            _logTime = LogTime;
            _logDetails = LogDetails;
        }

        public string LogDetails
        {
            get { return _logDetails; }
        }
    }

    public class ClassLogger : IDisposable
    {
        private StreamWriter _logStream = null;
        private string _logPath = "";
        private bool _logDateAndTime = true;
        private bool disposed = false;

        public delegate void LoggerEventHandler(object sender, LoggerEventArgs a);
        public event LoggerEventHandler LogAdded;

        public ClassLogger(string LogFile)
        {
            try
            {
                _logStream = File.AppendText(LogFile);
                _logPath = LogFile;
            }
            catch { }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            // Dispose of managed resources here. 
            if (disposing)
            {
                _logStream.Flush();
                _logStream.Close();
            }

            disposed = true;
        }  


        protected virtual void OnLogAdded(LoggerEventArgs e)
        {
            LoggerEventHandler handler = LogAdded;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Log(string Details, string Description = "", bool SuppressEvent = false)
        {
            try
            {
                DateTime oLogTime = DateTime.Now;

                if (String.IsNullOrEmpty(Description))
                {
                    if (_logDateAndTime)
                        _logStream.WriteLine(String.Format("{0:MM/dd/yy h:mm:ss tt}", oLogTime) + " ==> " + Details);
                }
                else
                {
                    _logStream.WriteLine("");
                    if (_logDateAndTime)
                        _logStream.WriteLine(String.Format("{0:MM/dd/yy h:mm:ss tt}", oLogTime) + " ==> " + Description);
                    _logStream.WriteLine(Details);
                }
                _logStream.Flush();

                if (!SuppressEvent)
                    OnLogAdded(new LoggerEventArgs(oLogTime, Description + Environment.NewLine + Details));
            }
            catch {}
        }
    }
}
