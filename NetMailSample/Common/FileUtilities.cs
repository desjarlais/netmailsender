using System;
using System.Net.Mime;

namespace NetMailSample.Common
{   
    public static class FileUtilities
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB" };
        
        /// <summary>
        /// this function takes a file size in bytes and converts it to the equivalent file size label
        /// </summary>
        /// <param name="value">the size in bytes of the attached file being added</param>
        /// <returns></returns>
        public static string SizeSuffix(long value)
        {
            if (value < 0) 
            { 
                return "-" + SizeSuffix(-value); 
            }
            if (value == 0) 
            { 
                return "0.0 bytes"; 
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        /// <summary>
        /// this function converts a string to the corresponding mime content type
        /// typically this is for a file attachment
        /// </summary>
        /// <param name="val">string value to be converted</param>
        /// <returns></returns>
        public static string GetContentType(string val)
        {
            switch (val)
            {
                case "Octet":
                    return MediaTypeNames.Application.Octet.ToString();
                case "Pdf":
                    return MediaTypeNames.Application.Pdf.ToString();
                case "Rtf":
                    return MediaTypeNames.Application.Rtf.ToString();
                case "Soap":
                    return MediaTypeNames.Application.Soap.ToString();
                case "Zip":
                    return MediaTypeNames.Application.Zip.ToString();
                case "Gif":
                    return MediaTypeNames.Image.Gif.ToString();
                case "Jpeg":
                    return MediaTypeNames.Image.Jpeg.ToString();
                case "Tiff":
                    return MediaTypeNames.Image.Tiff.ToString();
                case "Html":
                    return MediaTypeNames.Text.Html.ToString();
                case "Plain":
                    return MediaTypeNames.Text.Plain.ToString();
                case "RichText":
                    return MediaTypeNames.Text.RichText.ToString();
                case "Xml":
                    return MediaTypeNames.Text.Xml.ToString();
                default:
                    return val;
            }
        }
    }
}