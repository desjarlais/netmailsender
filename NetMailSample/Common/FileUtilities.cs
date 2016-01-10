/****************************** Module Header ******************************\
Module Name:  FileUtilities.cs
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
using System.Net.Mime;

namespace NetMailSample.Common
{   
    public static class FileUtilities
    {
        static readonly string[] sizeSuffixes = { "bytes", "KB", "MB", "GB" };
        
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

            return string.Format("{0:n1} {1}", adjustedSize, sizeSuffixes[mag]);
        }

        /// <summary>
        /// this function converts a string to the corresponding mime content type
        /// typically this is for a file attachment
        /// </summary>
        /// <param name="value">string value to be converted</param>
        /// <returns></returns>
        public static string GetContentType(string value)
        {
            switch (value)
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
                    return value;
            }
        }
    }
}