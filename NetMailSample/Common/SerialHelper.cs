/****************************** Module Header ******************************\
Module Name:  SerialHelper.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

Helper class for serializing the xml settings

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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NetMailSample.Common
{
    public class SerialHelper
    {
        /// <summary>
        /// serialize connection settings object to a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjectToString<T>(T obj)
        {
            string sXML = string.Empty;
            MemoryStream oMemoryStream = null;
            XmlTextWriter oXmlTextWriter = null;
            UTF8Encoding oUTF8Encoding = null;
            XmlWriterSettings oXmlWriterSettings = new XmlWriterSettings();

            try
            {
                using (oMemoryStream = new MemoryStream())
                {
                    oXmlWriterSettings.Encoding = Encoding.UTF8;
                    oXmlWriterSettings.Indent = true;
                    oXmlWriterSettings.ConformanceLevel = ConformanceLevel.Document;

                    XmlSerializer oXmlSerializer = new XmlSerializer(typeof(T));
                    oXmlTextWriter = new XmlTextWriter(oMemoryStream, Encoding.UTF8);
                    oXmlSerializer.Serialize(oXmlTextWriter, obj);
                    oMemoryStream = (MemoryStream)oXmlTextWriter.BaseStream;
                    oUTF8Encoding = new UTF8Encoding();
                    sXML = oUTF8Encoding.GetString(oMemoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Serializing");
                sXML = string.Empty;
            }

            return sXML;
        }

        /// <summary>
        /// deserialize the connection settings text to a connectionsettings object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeObjectFromString<T>(string xml)
        {
            XmlSerializer oXmlSerializer = null;
            MemoryStream oMemoryStream = null;
            XmlTextWriter oXmlTextWriter = null;
            UTF8Encoding oUTF8Encoding = new UTF8Encoding();

            try
            {
                oXmlSerializer = new XmlSerializer(typeof(T));
                oMemoryStream = new MemoryStream(oUTF8Encoding.GetBytes(xml));
                oXmlTextWriter = new XmlTextWriter(oMemoryStream, Encoding.UTF8);
                return (T)oXmlSerializer.Deserialize(oMemoryStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Deserializing");
                return default(T);
            }
        }
    }
}
