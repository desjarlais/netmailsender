using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NetMailSample.Common
{
    public class SerialHelper
    {
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
