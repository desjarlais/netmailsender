/****************************** Module Header ******************************\
Module Name:  DotNetVersion.cs
Project:      NetMailSample
Copyright (c) 2014 desjarlais

This module has functions for checking the installed .NET version of the
machine.

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
using System.Text;
using Microsoft.Win32;

namespace NetMailSample.Common
{
    class DotNetVersion
    {
        /// <summary>
        /// Find the installed .NET Framework versions by querying the registry
        /// </summary>
        public static string GetDotNetVerFromRegistry()
        {
            string dotNET45;

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                try
                {
                    int releaseKey = (int)ndpKey.GetValue("Release");
                    dotNET45 = CheckFor45DotVersion(releaseKey) + ndpKey.GetValue("Version").ToString();
                }
                catch (NullReferenceException)
                {
                    // added this .NET V4 check for Win7
                    // there is no Release key so just pulling the Version key and displaying that number
                    RegistryKey ndpv4Key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                        RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client\");
                    dotNET45 = "Installed .NET Framework version = " + ndpv4Key.GetValue("Version").ToString();
                }
            }

            return dotNET45;
        }

        // Checking the version using >= to enable forward compatibility
        public static string CheckFor45DotVersion(int releaseKey)
        {
            const string output = "Installed .NET Framework = ";

            if (releaseKey >= 461308)
            {
                return output + "4.7.1 or later ";
            }
            if (releaseKey >= 460798)
            {
                return output + "4.7 ";
            }
            if (releaseKey >= 394802)
            {
                return output + "4.6.2 ";
            }
            if (releaseKey >= 394254)
            {
                return output + "4.6.1 ";
            }
            if (releaseKey >= 393295)
            {
                return output + "4.6 ";
            }
            if ((releaseKey >= 379893))
            {
                return output + "4.5.2 ";
            }
            if ((releaseKey >= 378675))
            {
                return output + "4.5.1 ";
            }
            if ((releaseKey >= 378389))
            {
                return output + "4.5 ";
            }
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected. ";
        }
        
        /// <summary>
        ///  return the current runtime version by querying the Environment class in code
        /// </summary>
        public static string GetRuntimeVersionFromEnvironment()
        {
            return Environment.Version.ToString();
        }

        /// <summary>
        /// find the installed .NET Framework versions by querying the registry (versions 1-4)
        /// Note: currently not being used, more of a stub in case I need to include this later
        /// </summary>
        public static string GetPreV45FromRegistry()
        {
            StringBuilder preV45 = new StringBuilder();

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
            {
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {
                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();

                        if (install == "") //no install info, must be later
                            preV45.AppendLine((versionKeyName + "  " + name));
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                preV45.AppendLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                            if (install == "") //no install info, must be later
                                preV45.AppendLine(versionKeyName + "  " + name);
                            else
                            {
                                if (sp != "" && install == "1")
                                {
                                    preV45.AppendLine("  " + subKeyName + "  " + name + "  SP" + sp);
                                }
                                else if (install == "1")
                                {
                                    preV45.AppendLine("  " + subKeyName + "  " + name);
                                }
                            }
                        }
                    }
                }
            }

            return preV45.ToString();
        }
    }
}
