/****************************** Module Header ******************************\
Module Name:  UserIoHelper.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

IO Helper for dealing with the xml settings file in Save/Open scenarios

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NetMailSample.Common
{
    public class UserIoHelper
    {
        /// <summary>
        /// this function is used to get the save settings file location
        /// </summary>
        /// <param name="InitialDirectory"></param>
        /// <param name="SuggestedName"></param>
        /// <param name="SelectedFile"></param>
        /// <param name="FileFilter"></param>
        /// <returns></returns>
        public static bool PickSaveFileToFolder(string InitialDirectory, string SuggestedName, ref string SelectedFile, string FileFilter)
        {
            bool bRet = false;
            SaveFileDialog fsd = new SaveFileDialog();

            SelectedFile = SuggestedName;
            fsd.InitialDirectory = InitialDirectory;
            fsd.FileName = SuggestedName;
            fsd.Filter = FileFilter; 
            fsd.FilterIndex = 1;
            fsd.RestoreDirectory = false;
            fsd.Title = "Save Settings To File";

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                bRet = true;
                SelectedFile = fsd.FileName.Trim();
            }
            fsd = null;
            return bRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InitialDirectory"></param>
        /// <param name="SuggestedName"></param>
        /// <param name="SelectedFile"></param>
        /// <param name="FileFilter"></param>
        /// <returns></returns>
        public static bool PickLoadFromFile(string InitialDirectory, string SuggestedName, ref string SelectedFile, string FileFilter)
        {
            bool bRet = false;
            OpenFileDialog fsd = new OpenFileDialog();

            SelectedFile = SuggestedName;
            fsd.InitialDirectory = InitialDirectory;
            fsd.FileName = SuggestedName;
            fsd.Filter = FileFilter;
            fsd.FilterIndex = 1;
            fsd.RestoreDirectory = false;
            fsd.Title = "Select File";

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                bRet = true;
                SelectedFile = fsd.FileName.Trim();
            }
            fsd = null;
            return bRet;
        }
    }
}
