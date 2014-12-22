using System;
using System.Text;
using Microsoft.Win32;

namespace NetMailSample.Common
{
    class DotNetVersion
    {
        /// <summary>
        /// Find the installed .NET Framework versions by querying the registry (versions 4.5 and later)
        /// Release key versions: (378389 = 4.5; 378675 = 4.5.x on Win8.1; 378758 = 4.5.x on Win8/Win7SP1/VistaSP2; 381024 = 4.5.x on Win10)
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
                    {
                        switch (releaseKey)
                        {
                            case 378389:
                                dotNET45 = "The .NET Framework version = " + ndpKey.GetValue("Version").ToString();
                                break;
                            case 378675:
                                dotNET45 = "The .NET Framework version = " + ndpKey.GetValue("Version").ToString();
                                break;
                            case 378758:
                                dotNET45 = "The .NET Framework version = " + ndpKey.GetValue("Version").ToString();
                                break;
                            case 381024:
                                dotNET45 = "The .NET Framework version = " + ndpKey.GetValue("Version").ToString();
                                break;
                            default:
                                dotNET45 = "The .NET Framework version 4.5 or higher is NOT installed.";
                                break;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    // added this .NET V4 check for Win7
                    // there is no Release key so just pulling the Version key and displaying that number
                    RegistryKey ndpv4Key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                        RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client\");
                    dotNET45 = ".NET Framework version " + ndpv4Key.GetValue("Version").ToString();
                }
            }

            return dotNET45;
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
